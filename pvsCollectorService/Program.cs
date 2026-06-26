using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using pvsCollector.Data;
using pvsCollectorService;
using pvsCollectorService.Clients;
using pvsCollectorService.Handlers;
using pvsCollectorService.Workers;
using SQLitePCL;
using System.Net;

// Initialize the SQLite native provider (required when using Sqlite.Core + SourceGear.sqlite3)
raw.SetProvider(new SQLite3Provider_e_sqlite3());

var builder = Host.CreateApplicationBuilder(args);

// Get our logger
using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
});
var logger = loggerFactory.CreateLogger<Program>();

// Load in the super secret URI/Username/Password
builder.Services.Configure<ApplicationSettings>(
    builder.Configuration.GetSection(ApplicationSettings.SectionName));

// Bind settings for use during startup configuration
var pvsSettings = builder.Configuration
    .GetSection(ApplicationSettings.SectionName)
    .Get<ApplicationSettings>() ?? new ApplicationSettings();

// Register DbContext with provider chosen by dbType setting
builder.Services.AddDbContext<pvsCollectorContext>(options =>
{
    switch (pvsSettings.dbType.ToLowerInvariant())
    {
        case "sqlserver":
        case "mssql":
            logger.LogInformation("Using SQL Server database provider.");
            options.UseSqlServer(pvsSettings.dbConnectionString);
            break;
        default: // sqlite
            logger.LogInformation("Using SQLite database provider.");
            options.UseSqlite(pvsSettings.dbConnectionString);
            break;
    }
});

// Shared cookie container for all requests made by workers
builder.Services.AddSingleton<CookieContainer>();

// Configure the HttpClient with the SessionAuthHandler
builder.Services.AddTransient<SessionAuthHandler>();
builder.Services.AddHttpClient<PVS6APIClient>(client => {
    client.BaseAddress = new Uri(pvsSettings.pvsUri ?? throw new ArgumentNullException(nameof(ApplicationSettings.pvsUri), "PVS URI cannot be null."));
})
.AddHttpMessageHandler<SessionAuthHandler>()
.ConfigurePrimaryHttpMessageHandler(sp => new HttpClientHandler
{
    CookieContainer = sp.GetRequiredService<CookieContainer>(),
    UseCookies = true,
    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
});

// Load the Workers
builder.Services.AddHostedService<PowerDataWorker>();

var host = builder.Build();

// Migrate the database on startup
logger.LogInformation("Migrating database...");
using (var scope = host.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<pvsCollectorContext>();
    db.Database.Migrate();
}
logger.LogInformation("Starting the host...");

host.Run();