using System;
using System.Collections.Generic;
using System.Text;

namespace pvsCollectorService.Models
{
    /*
     * https://github.com/SunStrong-Management/pypvs/blob/main/doc/varserver-variables-public-pvs6.csv
        /sys/telemetryws/enable	uint16	1	N/A	Variable to enable telemetry websockets
    */
    public class PVS6TelemetryEnable
    {
        /// <summary>
        /// Variable to enable telemetry websockets
        /// </summary>
        public ushort enable { get; set; }
    }
}
