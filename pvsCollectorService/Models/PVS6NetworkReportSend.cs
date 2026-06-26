using System;
using System.Collections.Generic;
using System.Text;

namespace pvsCollectorService.Models
{
    /*
     * https://github.com/SunStrong-Management/pypvs/blob/main/doc/varserver-variables-public-pvs6.csv
        /network/report/send	uint16	N/A	N/A	Trigger communicator to send a network interface report
    */
    public class PVS6NetworkReportSend
    {
        public ushort send { get; set; }
    }
}
