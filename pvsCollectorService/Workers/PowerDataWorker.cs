using Microsoft.EntityFrameworkCore;
using pvsCollector.Data;
using pvsCollector.Data.Entities;
using pvsCollectorService.Clients;
using pvsCollectorService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace pvsCollectorService.Workers
{
    public class PowerDataWorker : BackgroundService
    {
        private readonly ILogger<PowerDataWorker> _logger;
        private readonly PVS6APIClient _api;
        private readonly IServiceScopeFactory _scopeFactory;

        public PowerDataWorker(ILogger<PowerDataWorker> logger,  PVS6APIClient api, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _api = api;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken ct)
        {
            // Loop until we're told to stop...
            while(!ct.IsCancellationRequested)
            {
                _logger.LogInformation("PowerDataWorker running at : {time}", DateTimeOffset.Now);

                // Capture the data from the PVS6 API
                Task<List<PVS6DevicesInverter>> invertersTask = _api.GetPVS6DevicesInverters(ct);
                Task<List<PVS6DevicesMeter>> metersTask = _api.GetPVS6DevicesMeters(ct);

                // Get the last recorded inverter and meter datas from the database
                await using var scope = _scopeFactory.CreateAsyncScope();
                var db = scope.ServiceProvider.GetRequiredService<pvsCollectorContext>();

                List<Inverter> latestInverterData = await db.Inverters
                    .GroupBy(i => i.sn)
                    .Select(g => g
                        .OrderByDescending(x => x.WrittenAt)
                        .ThenByDescending(x => x.Id)
                        .First())
                    .ToListAsync(ct);

                List<Meter> latestMeterData = await db.Meters
                    .GroupBy(m => m.sn)
                    .Select(g => g
                        .OrderByDescending(x => x.WrittenAt)
                        .ThenByDescending(x => x.Id)
                        .First())
                    .ToListAsync(ct);

                Task.WaitAll(invertersTask, metersTask);

                List<PVS6DevicesInverter> newInverters = invertersTask.Result;
                List<PVS6DevicesMeter> newMeters = metersTask.Result;

                // Compare and see what needs to be added to the database
                foreach(PVS6DevicesMeter m in newMeters)
                {
                    if(latestMeterData.Any(x => x.sn == m.sn && x.msmtEps == m.msmtEps))
                    {
                        _logger.LogInformation("Meter data for {sn} has not updated.", m.sn);
                        continue;
                    }
                    db.Meters.Add(new Meter
                    {
                        WrittenAt = DateTime.UtcNow,
                        ctSclFctr = m.ctSclFctr,
                        freqHz = m.freqHz,
                        i1A = m.i1A,
                        i2A = m.i2A,
                        msmtEps = m.msmtEps ?? string.Empty,
                        negLtea3phsumKwh = m.negLtea3phsumKwh,
                        netLtea3phsumKwh = m.netLtea3phsumKwh,
                        p1Kw = m.p1Kw,
                        p2Kw = m.p2Kw,
                        p3phsumKw = m.p3phsumKw,
                        posLtea3phsumKwh = m.posLtea3phsumKwh,
                        prodMdlNm = m.prodMdlNm ?? string.Empty,
                        q3phsumKvar = m.q3phsumKvar,
                        s3phsumKva = m.s3phsumKva,
                        sn = m.sn ?? string.Empty,
                        totPfRto = m.totPfRto,
                        v12V = m.v12V,
                        v1nV = m.v1nV,
                        v2nV = m.v2nV
                    });
                }

                foreach(PVS6DevicesInverter i in newInverters)
                {
                    if (latestInverterData.Any(x => x.sn == i.sn && x.msmtEps == i.msmtEps))
                    {
                        _logger.LogInformation("Inverter data for {sn} has not updated.", i.sn);
                        continue;
                    }
                    db.Inverters.Add(new Inverter
                    {
                        WrittenAt = DateTime.UtcNow,
                        freqHz = i.freqHz,
                        i3phsumA = i.i3phsumA,
                        iMppt1A = i.iMppt1A,
                        ltea3phsum = i.ltea3phsum,
                        msmtEps = i.msmtEps ?? string.Empty,
                        p3phsumKw = i.p3phsumKw,
                        pMppt1Kw = i.pMppt1Kw,
                        prodMdlNm = i.prodMdlNm ?? string.Empty,
                        sn = i.sn ?? string.Empty,
                        tHtsnkDegc = i.tHtsnkDegc,
                        vMppt1V = i.vMppt1V,
                        vln3phavgV = i.vln3phavgV
                    });
                }

                await db.SaveChangesAsync();

                // Only poll every 60 seconds, as the PVS6 API is not designed for high-frequency polling
                // and it appears that the Inverters and Power consumption/production data is only updated
                // every 5 minutes anyway.
                await Task.Delay(60000, ct);
            }
        }
    }
}
