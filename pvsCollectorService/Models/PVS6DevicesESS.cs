using System;
using System.Collections.Generic;
using System.Text;

namespace pvsCollectorService.Models
{
    /*
     * https://github.com/SunStrong-Management/pypvs/blob/main/doc/varserver-variables-public-pvs6.csv
        /sys/devices/ess/{index}/chrgLimitPmaxKw	float	0	telemetry,ess	Maximum allowed charge power (kW)	
        /sys/devices/ess/{index}/customerSocVal	    float	0	telemetry,ess	Customer-reported state of charge (SOC) value	
        /sys/devices/ess/{index}/dischrgLimPmaxKw	float	0	telemetry,ess	Maximum allowed discharge power (kW)	
        /sys/devices/ess/{index}/maxTBattCellDegc	float	0	telemetry,ess	Maximum battery cell temperature (°C)	
        /sys/devices/ess/{index}/maxVBattCellV	    float	0	telemetry,ess	Maximum battery cell voltage (V)	
        /sys/devices/ess/{index}/minTBattCellDegc	float	0	telemetry,ess	Minimum battery cell temperature (°C)	
        /sys/devices/ess/{index}/minVBattCellV	    float	0	telemetry,ess	Minimum battery cell voltage (V)	
        /sys/devices/ess/{index}/msmtEps	        str	    n/a	telemetry,ess	Timestamp of the last measurement	
        /sys/devices/ess/{index}/negLtea3phsumKwh	float	0	telemetry,ess	Total negative energy (kWh) over 3 phases	
        /sys/devices/ess/{index}/opMode         	str	    n/a	telemetry,ess	Operating mode of the ESS	
        /sys/devices/ess/{index}/p3phsumKw	        float	0	telemetry,ess	Total real power (kW) over 3 phases	
        /sys/devices/ess/{index}/posLtea3phsumKwh	float	0	telemetry,ess	Total positive energy (kWh) over 3 phases	
        /sys/devices/ess/{index}/prodMdlNm	        str	    n/a	telemetry,ess	Product model name	
        /sys/devices/ess/{index}/sn	                str 	n/a	telemetry,ess	Device serial number	
        /sys/devices/ess/{index}/socVal	            float	0	telemetry,ess	State of charge (SOC) value	
        /sys/devices/ess/{index}/sohVal	            int16	0	telemetry,ess	State of health (SOH) value	
        /sys/devices/ess/{index}/tInvtrDegc	        float	0	telemetry,ess	Inverter temperature (°C)	
        /sys/devices/ess/{index}/v1nV	            float	0	telemetry,ess	Voltage between phase 1 and neutral (V)	
        /sys/devices/ess/{index}/v2nV	            float	0	telemetry,ess	Voltage between phase 2 and neutral (V)	
        /sys/devices/ess/{index}/vBattV	            float	0	telemetry,ess	Battery voltage (V)
    */
    public class PVS6DevicesESS
    {
        // Dropping the index property as it is not needed for the current implementation. If needed in the future, it can be added back.
        /// <summary>
        /// Index of the ESS in the system
        /// </summary>
        //public int index { get; set; }
        /// <summary>
        /// Maximum allowed charge power (kW)	
        /// </summary>
        public float chrgLimitPmaxKw {get; set;}
        /// <summary>
        /// Customer-reported state of charge (SOC) value
        /// </summary>
        public float customerSocVal {get; set;}
        /// <summary>
        /// Maximum allowed discharge power (kW)	
        /// </summary>
        public float dischrgLimPmaxKw {get; set;}
        /// <summary>
        /// Maximum battery cell temperature (°C)	
        /// </summary>
        public float maxTBattCellDegc {get; set;}
        /// <summary>
        /// Maximum battery cell voltage (V)	
        /// </summary>
        public float maxVBattCellV {get; set;}
        /// <summary>
        /// Minimum battery cell temperature (°C)	
        /// </summary>
        public float minTBattCellDegc {get; set;}
        /// <summary>
        /// Minimum battery cell voltage (V)
        /// </summary>
        public float minVBattCellV {get; set;}
        /// <summary>
        /// Timestamp of the last measurement	
        /// </summary>
        public string? msmtEps {get; set;}
        /// <summary>
        /// Total negative energy (kWh) over 3 phases	
        /// </summary>
        public float negLtea3phsumKwh {get; set;}
        /// <summary>
        /// Operating mode of the ESS	
        /// </summary>
        public string? opMode {get; set;}
        /// <summary>
        /// Total real power (kW) over 3 phases	
        /// </summary>
        public float p3phsumKw {get; set;}
        /// <summary>
        /// Total positive energy (kWh) over 3 phases
        /// </summary>
        public float posLtea3phsumKwh {get; set;}
        /// <summary>
        /// Product model name	
        /// </summary>
        public string? prodMdlNm {get; set;}
        /// <summary>
        /// Device serial number	
        /// </summary>
        public string? sn {get; set;}
        /// <summary>
        /// State of charge (SOC) value	
        /// </summary>
        public float socVal {get; set;}
        /// <summary>
        /// State of health (SOH) value	
        /// </summary>
        public short sohVal {get; set;}
        /// <summary>
        /// Inverter temperature (°C)	
        /// </summary>
        public float tInvtrDegc {get; set;}
        /// <summary>
        /// Voltage between phase 1 and neutral (V)
        /// </summary>
        public float v1nV {get; set;}
        /// <summary>
        /// Voltage between phase 2 and neutral (V)
        /// </summary>
        public float v2nV {get; set;}
        /// <summary>
        /// Battery voltage (V)
        /// </summary>
        public float vBattV { get; set; }
    }
}
