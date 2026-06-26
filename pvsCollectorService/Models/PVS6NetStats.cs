using System;
using System.Collections.Generic;
using System.Text;

namespace pvsCollectorService.Models
{
    /*
     * https://github.com/SunStrong-Management/pypvs/blob/main/doc/varserver-variables-public-pvs6.csv
        /net/sta0/state	    str	N/A	netstats,network,toggle_cell	sta0 interface state
        /net/wan0/state	    str	N/A	netstats,network,toggle_cell	wan0 interface state
        /net/wan1/state	    str	N/A	netstats,network,toggle_cell	wan1 (USB dongle ethernet adapter) interface state
        /net/wwan0/state	str	N/A	netstats,network,toggle_cell	wwan0 interface state
    */
    public class PVS6NetStats
    {
        /// <summary>
        /// sta0 interface state
        /// </summary>
        public string? sta0_state { get; set; }
        /// <summary>
        /// wan0 interface state
        /// </summary>
        public string? wan0_state { get; set; }
        /// <summary>
        /// wan1 (USB dongle ethernet adapter) interface state
        /// </summary>
        public string? wan1_state { get; set; }
        /// <summary>
        /// wwan0 interface state
        /// </summary>
        public string? wwan0_state { get; set; }
    }
}
