using System;
using System.Collections.Generic;
using System.Text;

namespace pvsCollectorService.Models
{
    /*
     *
        /sys/livedata/backupTimeRemaining	uint32	N/A	livedata	Battery Backup Time Remaining (minutes)
        /sys/livedata/ess_en	            float	N/A	livedata	Battery Energy (kWh)
        /sys/livedata/ess_p	                float	N/A	livedata	Battery Power (kW)
        /sys/livedata/midstate	            int32	N/A	livedata	MID State
        /sys/livedata/net_en	            float	N/A	livedata	Net Consumption Energy (kWh)
        /sys/livedata/net_p	                float	N/A	livedata	Net Consumption Power (kW)
        /sys/livedata/pv_en	                float	N/A	livedata	Production Energy (kWh)
        /sys/livedata/pv_p	                float	N/A	livedata	Production Power (kW)
        /sys/livedata/site_load_en	        float	N/A	livedata	Site Load Energy (kWh)
        /sys/livedata/site_load_p	        float	N/A	livedata	Site Load Power (kW)
        /sys/livedata/soc	                float	N/A	livedata	Battery State of Charge (%)
        /sys/livedata/time	                int64	N/A	livedata	Telemetry Websockets timestamp
    */
    public class PVS6LiveData
    {
        /// <summary>
        /// Battery Backup Time Remaining (minutes)
        /// </summary>
        public uint backupTimeRemaining {get;set;}
        /// <summary>
        /// Battery Energy (kWh)
        /// </summary>
        public float ess_en {get;set;}
        /// <summary>
        /// Battery Power (kW)
        /// </summary>
        public float ess_p {get;set;}
        /// <summary>
        /// MID State
        /// </summary>
        public int midstate {get;set;}
        /// <summary>
        /// Net Consumption Energy (kWh)
        /// </summary>
        public float net_en {get;set;}
        /// <summary>
        /// Net Consumption Power (kW)
        /// </summary>
        public float net_p {get;set;}
        /// <summary>
        /// Production Energy (kWh)
        /// </summary>
        public float pv_en {get;set;}
        /// <summary>
        /// Production Power (kW)
        /// </summary>
        public float pv_p {get;set;}
        /// <summary>
        /// Site Load Energy (kWh)
        /// </summary>
        public float site_load_en {get;set;}
        /// <summary>
        /// Site Load Power (kW)
        /// </summary>
        public float site_load_p {get;set;}
        /// <summary>
        /// Battery State of Charge (%)
        /// </summary>
        public float soc {get;set;}
        /// <summary>
        /// Telemetry Websockets timestamp
        /// </summary>
        public long time { get; set; }
    }
}
