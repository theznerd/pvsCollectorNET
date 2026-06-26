using System;
using System.Collections.Generic;
using System.Text;

namespace pvsCollectorService
{
    public class ApplicationSettings
    {
        public const string SectionName = "pvsSettings";

        public string pvsUri { get; set; } = string.Empty;
        public string pvsPassword { get; set; } = string.Empty;
        public string pvsUsername { get; set; } = string.Empty;
        public string dbType { get; set; } = "sqlite";
        public string dbConnectionString { get; set; } = "Data Source=./pvsCollector.db";
    }
}
