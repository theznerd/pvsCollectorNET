using System;
using System.Collections.Generic;
using System.Text;

namespace pvsCollectorService.Models
{
    /*
     * https://github.com/SunStrong-Management/pypvs/blob/main/doc/varserver-variables-public-pvs6.csv
        /sys/toggle_cell/broadband_connected    uint16  0   netstats,toggle_cell Broadband connection status, 0=disconnected, 1=connected
        /sys/toggle_cell/cell_connected         uint16  0   netstats,toggle_cell Cell connection status, 0=disconnected, 1=connected
        /sys/toggle_cell/low_data_mode          uint32  0   netstats,toggle_cell toggle_cell low data mode status   
    */
    
    public class PVS6NetStatsToggleCell
    {
        /// <summary>
        /// Broadband connection status, 0=disconnected, 1=connected
        /// </summary>
        public ushort broadband_connected {get;set;}
        /// <summary>
        /// Cell connection status, 0=disconnected, 1=connected
        /// </summary>
        public ushort cell_connected {get;set;}
        /// <summary>
        /// toggle_cell low data mode status   
        /// </summary>
        public uint low_data_mode { get; set; }
    }
}
