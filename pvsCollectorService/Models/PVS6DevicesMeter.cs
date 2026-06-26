using System;
using System.Collections.Generic;
using System.Text;

namespace pvsCollectorService.Models
{
    /*
     * https://github.com/SunStrong-Management/pypvs/blob/main/doc/varserver-variables-public-pvs6.csv
        /sys/devices/meter/{index}/ctSclFctr	    int32	0	telemetry,meter	CT scaling factor
        /sys/devices/meter/{index}/freqHz	        float	0	telemetry,meter	Frequency in Hz
        /sys/devices/meter/{index}/i1A	            float	0	telemetry,meter	Current in A for phase 1
        /sys/devices/meter/{index}/i2A	            float	0	telemetry,meter	Current in A for phase 2
        /sys/devices/meter/{index}/msmtEps	        str 	n/a	telemetry,meter	Timestamp of the last measurement
        /sys/devices/meter/{index}/negLtea3phsumKwh	float	0	telemetry,meter	Negative lifetime sum of 3-phase energy in kWh
        /sys/devices/meter/{index}/netLtea3phsumKwh	float	0	telemetry,meter	Net lifetime sum of 3-phase energy in kWh
        /sys/devices/meter/{index}/p1Kw         	float	0	telemetry,meter	Power in kW for phase 1
        /sys/devices/meter/{index}/p2Kw	            float	0	telemetry,meter	Power in kW for phase 2
        /sys/devices/meter/{index}/p3phsumKw	    float	0	telemetry,meter	Sum of 3-phase power in kW
        /sys/devices/meter/{index}/posLtea3phsumKwh	float	0	telemetry,meter	Positive lifetime sum of 3-phase energy in kWh
        /sys/devices/meter/{index}/prodMdlNm	    str	    n/a	telemetry,meter	Product model name
        /sys/devices/meter/{index}/q3phsumKvar  	float	0	telemetry,meter	Sum of 3-phase reactive power in kVar
        /sys/devices/meter/{index}/s3phsumKva   	float	0	telemetry,meter	Sum of 3-phase apparent power in kVA
        /sys/devices/meter/{index}/sn	            str	    n/a	telemetry,meter	Serial number of the meter
        /sys/devices/meter/{index}/totPfRto	        float	0	telemetry,meter	Total power factor ratio
        /sys/devices/meter/{index}/v12V	            float	0	telemetry,meter	Voltage between phase 1 and 2 in V
        /sys/devices/meter/{index}/v1nV	            float	0	telemetry,meter	Voltage between phase 1 and neutral in V
        /sys/devices/meter/{index}/v2nV	            float	0	telemetry,meter	Voltage between phase 2 and neutral in V
    */
    public class PVS6DevicesMeter
    {
        // Dropping the index property as it is not needed for the current implementation. If needed in the future, it can be added back.
        /// <summary>
        /// Index of the meter in the system
        /// </summary>
        //public int index { get; set; }
        /// <summary>
        /// CT scaling factor
        /// </summary>
        public int ctSclFctr {get;set;}
        /// <summary>
        /// Frequency in Hz
        /// </summary>
        public float freqHz {get;set;}
        /// <summary>
        /// Current in A for phase 1
        /// </summary>
        public float i1A {get;set;}
        /// <summary>
        /// Current in A for phase 2
        /// </summary>
        public float i2A {get;set;}
        /// <summary>
        /// Timestamp of the last measurement
        /// </summary>
        public string? msmtEps {get;set;}
        /// <summary>
        /// Negative lifetime sum of 3-phase energy in kWh
        /// </summary>
        public float negLtea3phsumKwh {get;set;}
        /// <summary>
        /// Net lifetime sum of 3-phase energy in kWh
        /// </summary>
        public float netLtea3phsumKwh {get;set;}
        /// <summary>
        /// Power in kW for phase 1
        /// </summary>
        public float p1Kw {get;set;}
        /// <summary>
        /// Power in kW for phase 2
        /// </summary>
        public float p2Kw {get;set;}
        /// <summary>
        /// Sum of 3-phase power in kW
        /// </summary>
        public float p3phsumKw {get;set;}
        /// <summary>
        /// Positive lifetime sum of 3-phase energy in kWh
        /// </summary>
        public float posLtea3phsumKwh {get;set;}
        /// <summary>
        /// Product model name
        /// </summary>
        public string? prodMdlNm {get;set;}
        /// <summary>
        /// Sum of 3-phase reactive power in kVar
        /// </summary>
        public float q3phsumKvar {get;set;}
        /// <summary>
        /// Sum of 3-phase apparent power in kVA
        /// </summary>
        public float s3phsumKva {get;set;}
        /// <summary>
        /// Serial number of the meter
        /// </summary>
        public string? sn {get;set;}
        /// <summary>
        /// Total power factor ratio
        /// </summary>
        public float totPfRto {get;set;}
        /// <summary>
        /// Voltage between phase 1 and 2 in V
        /// </summary>
        public float v12V {get;set;}
        /// <summary>
        /// Voltage between phase 1 and neutral in V
        /// </summary>
        public float v1nV {get;set;}
        /// <summary>
        /// Voltage between phase 2 and neutral in V
        /// </summary>
        public float v2nV { get; set; }
    }
}
