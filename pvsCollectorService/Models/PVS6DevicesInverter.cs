using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace pvsCollectorService.Models
{
    /*
     * https://github.com/SunStrong-Management/pypvs/blob/main/doc/varserver-variables-public-pvs6.csv
           /sys/devices/inverter/{index}/freqHz	        float	0	telemetry,inverter	Frequency in Hz dectected by the inverter
           /sys/devices/inverter/{index}/i3phsumA	    float	0	telemetry,inverter	Sum of phase currents in A
           /sys/devices/inverter/{index}/iMppt1A	    float	0	telemetry,inverter	Current of MPPT1 in A
           /sys/devices/inverter/{index}/ltea3phsumKwh	float	0	telemetry,inverter	Lifetime sum of 3-phase energy in kWh
           /sys/devices/inverter/{index}/msmtEps	    str	    n/a	telemetry,inverter	Timestamp of the last measurement
           /sys/devices/inverter/{index}/p3phsumKw	    float	0	telemetry,inverter	Sum of 3-phase power in kW
           /sys/devices/inverter/{index}/pMppt1Kw	    float	0	telemetry,inverter	Power of MPPT1 in kW
           /sys/devices/inverter/{index}/prodMdlNm	    str	    n/a	telemetry,inverter	Product model name
           /sys/devices/inverter/{index}/sn	            str	    n/a	telemetry,inverter	Serial number of the inverter
           /sys/devices/inverter/{index}/tHtsnkDegc	    int32	0	telemetry,inverter	Temperature of the heat sink in °C
           /sys/devices/inverter/{index}/vMppt1V	    float	0	telemetry,inverter	Voltage of MPPT1 in V
           /sys/devices/inverter/{index}/vln3phavgV	    float	0	telemetry,inverter	Average line-to-neutral voltage of 3-phase system in V
    */
    public class PVS6DevicesInverter
    {
        // Dropping the index property as it is not needed for the current implementation. If needed in the future, it can be added back.
        /// <summary>
        /// Index of the inverter in the system
        /// </summary>
        //public int index { get; set; }
        /// <summary>
        /// Frequency in Hz dectected by the inverter
        /// </summary>
        public float freqHz { get; set; }
        /// <summary>
        /// Sum of phase currents in A
        /// </summary>
        public float i3phsumA {get;set;}
        /// <summary>
        /// Current of MPPT1 in A
        /// </summary>
        public float iMppt1A {get;set;}
        /// <summary>
        /// Lifetime sum of 3-phase energy in kWh
        /// </summary>
        public float ltea3phsum {get;set;}
        /// <summary>
        /// Timestamp of the last measurement
        /// </summary>
        public string? msmtEps {get;set;}
        /// <summary>
        /// Sum of 3-phase power in kW
        /// </summary>
        public float p3phsumKw {get;set;}
        /// <summary>
        /// Power of MPPT1 in kW
        /// </summary>
        public float pMppt1Kw {get;set;}
        /// <summary>
        /// Product model name
        /// </summary>
        public string? prodMdlNm {get;set;}
        /// <summary>
        /// Serial number of the inverter
        /// </summary>
        public string? sn {get;set;}
        /// <summary>
        /// Temperature of the heat sink in °C
        /// </summary>
        public int tHtsnkDegc {get;set;}
        /// <summary>
        /// Voltage of MPPT1 in V
        /// </summary>
        public float vMppt1V {get;set;}
        /// <summary>
        /// Average line-to-neutral voltage of 3-phase system in V
        /// </summary>
        public float vln3phavgV { get; set; }
    }
}
