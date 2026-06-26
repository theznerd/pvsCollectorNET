using System;
using System.Collections.Generic;
using System.Text;

namespace pvsCollectorService.Models
{
    /*
     * https://github.com/SunStrong-Management/pypvs/blob/main/doc/varserver-variables-public-pvs6.csv
       /metrics/network/interface_report_request	uint32	N/A	metrics,network	Count of Network Interface Report requests
    */
    public class PVS6MetricsNetwork
    {
        /// <summary>
        /// Count of Network Interface Report requests
        /// </summary>
        public uint interface_report_request { get; set; }
    }
}
