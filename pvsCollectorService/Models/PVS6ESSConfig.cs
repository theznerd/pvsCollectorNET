using System;
using System.Collections.Generic;
using System.Text;

namespace pvsCollectorService.Models
{
    /*
     * https://github.com/SunStrong-Management/pypvs/blob/main/doc/varserver-variables-public-pvs6.csv
        /ess/config/dcm/control_param/min_customer_soc	float	0.30	ess,config	Minimal customer SoC is used to calculate corresponding system soc threshold min_soc, should be between 0.0 and 1.0 including borders
        /ess/config/dcm/mode_param/control_mode	        str	    STANDBY	ess,config	ESS control mode
    */
    public class PVS6ESSConfig
    {
        /// <summary>
        /// Minimal customer SoC is used to calculate corresponding system soc threshold min_soc, should be between 0.0 and 1.0 including borders
        /// </summary>
        public float min_customer_soc { get; set; }
        /// <summary>
        /// ESS control mode
        /// </summary>
        public string? control_mode { get; set; }
    }
}
