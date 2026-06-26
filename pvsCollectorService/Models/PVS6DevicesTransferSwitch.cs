using System;
using System.Collections.Generic;
using System.Text;

namespace pvsCollectorService.Models
{
    /*
     * https://github.com/SunStrong-Management/pypvs/blob/main/doc/varserver-variables-public-pvs6.csv
        /sys/devices/transfer_switch/{index}/midStEnum	str	    n/a	telemetry,transfer_switch	MID state
        /sys/devices/transfer_switch/{index}/msmtEps	str	    n/a	telemetry,transfer_switch	Timestamp of the last measurement
        /sys/devices/transfer_switch/{index}/prodMdlNm	str	    n/a	telemetry,transfer_switch	Product model name
        /sys/devices/transfer_switch/{index}/pvd1StEnum	str	    n/a	telemetry,transfer_switch	PV Disconnect (PVD) state
        /sys/devices/transfer_switch/{index}/sn	        str	    n/a	telemetry,transfer_switch	Serial number of the transfer switch
        /sys/devices/transfer_switch/{index}/tDegc	    float	0	telemetry,transfer_switch	Temperature in degrees Celsius
        /sys/devices/transfer_switch/{index}/v1nGridV	float	0	telemetry,transfer_switch	Grid voltage for phase 1
        /sys/devices/transfer_switch/{index}/v1nV	    float	0	telemetry,transfer_switch	Voltage between phase 1 and neutral
        /sys/devices/transfer_switch/{index}/v2nGridV	float	0	telemetry,transfer_switch	Grid voltage between phase 2 and neutral
        /sys/devices/transfer_switch/{index}/v2nV	    float	0	telemetry,transfer_switch	Voltage between phase 2 and neutral
        /sys/devices/transfer_switch/{index}/vSpplyV	float	0	telemetry,transfer_switch	Supply voltage
    */
    public class PVS6DevicesTransferSwitch
    {
        // Dropping the index property as it is not needed for the current implementation. If needed in the future, it can be added back.
        /// <summary>
        /// Index of the transfer switch in the system
        /// </summary>
        //public int index { get; set; }
        /// <summary>
        /// MID state
        /// </summary>
        public string? midStEnum { get; set; }
        /// <summary>
        /// Timestamp of the last measurement
        /// </summary>
        public string? msmtEps {get;set;}
        /// <summary>
        /// Product model name
        /// </summary>
        public string? prodMdlNm {get;set;}
        /// <summary>
        /// PV Disconnect (PVD) state
        /// </summary>
        public string? pvd1StEnum {get;set;}
        /// <summary>
        /// Serial number of the transfer switch
        /// </summary>
        public string? sn {get;set;}
        /// <summary>
        /// Temperature in degrees Celsius
        /// </summary>
        public float tDegc {get;set;}
        /// <summary>
        /// Grid voltage for phase 1
        /// </summary>
        public float v1nGridV {get;set;}
        /// <summary>
        /// Voltage between phase 1 and neutral
        /// </summary>
        public float v1nV {get;set;}
        /// <summary>
        /// Grid voltage between phase 2 and neutral
        /// </summary>
        public float v2nGridV {get;set;}
        /// <summary>
        /// Voltage between phase 2 and neutral
        /// </summary>
        public float v2nV {get;set;}
        /// <summary>
        /// Supply voltage
        /// </summary>
        public float vSpplyV {get;set;}
    }
}
