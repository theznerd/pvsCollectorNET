using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace pvsCollectorService.Models
{
    /*
     * 
        /sys/info/active_interface	    str	    TBD	    diag	Current active network interface
        /sys/info/active_interface_mac	str	    TBD	    diag	Current active network interface mac address
        /sys/info/boardtype	            str	    TBD	    diag	PVS Board Type
        /sys/info/cpu_usage	            uint16	0	    diag	Current CPU usage in percentage
        /sys/info/finance_type	        str	    UNKNOWN	diag	Finance type for the site that this PVS is running at. Viable values are UNKNOWN, CASH, LEASE, and LOAN
        /sys/info/flash_usage	        uint16	0	    diag	Current Flash usage in percentage
        /sys/info/fwrev	                str	    TBD	    diag	PVS Firmware Revision
        /sys/info/hwrev	                str	    TBD	    diag	PVS Hardware Revision
        /sys/info/lmac	                str	    TBD	    diag	LAN0 MAC address
        /sys/info/model	                str	    TBD	    diag	PVS model number
        /sys/info/ram_usage	            uint16	0	    diag	Current RAM usage in percentage
        /sys/info/serialnum	            str	    TBD	    diag	PVS Serial Number
        /sys/info/ssid	                str	    TBD	    diag	PVS ssid
        /sys/info/sw_rev	            str	    TBD	    diag	SPWR Software Revision
        /sys/info/sys_type	            str	    Unknown	diag	system type (PV-only, storage)
        /sys/info/uptime	            str	    TBD 	diag	PVS uptime
        /sys/info/wpa_key	            str	    TBD 	diag	PVS wpa key
    */
    public class PVS6InfoDiag
    {
        /// <summary>
        /// Current active network interface
        /// </summary>
        public string? active_interface {get;set;}
        /// <summary>
        /// Current active network interface mac address
        /// </summary>
        public string? active_interface_mac {get;set;}
        /// <summary>
        /// PVS Board Type
        /// </summary>
        public string? boardtype {get;set;}
        /// <summary>
        /// Current CPU usage in percentage
        /// </summary>
        public short cpu_usage {get;set;}
        /// <summary>
        /// Finance type for the site that this PVS is running at. Viable values are UNKNOWN, CASH, LEASE, and LOAN
        /// </summary>
        public string? finance_type {get;set;}
        /// <summary>
        /// Current Flash usage in percentage
        /// </summary>
        public short flash_usage {get;set;}
        /// <summary>
        /// PVS Firmware Revision
        /// </summary>
        public string? fwrev {get;set;}
        /// <summary>
        /// PVS Hardware Revision
        /// </summary>
        public string? hwrev {get;set;}
        /// <summary>
        /// LAN0 MAC address
        /// </summary>
        public string? lmac {get;set;}
        /// <summary>
        /// PVS model number
        /// </summary>
        public string? model {get;set;}
        /// <summary>
        /// Current RAM usage in percentage
        /// </summary>
        public short ram_usage {get;set;}
        /// <summary>
        /// PVS Serial Number
        /// </summary>
        public string? serialnum {get;set;}
        /// <summary>
        /// PVS ssid
        /// </summary>
        public string? ssid {get;set;}
        /// <summary>
        /// SPWR Software Revision
        /// </summary>
        public string? sw_rev {get;set;}
        /// <summary>
        /// system type (PV-only, storage)
        /// </summary>
        public string? sys_type {get;set;}
        /// <summary>
        /// PVS uptime
        /// </summary>
        public string? uptime {get;set;}
        /// <summary>
        /// PVS wpa key
        /// </summary>
        public string? wpa_key { get; set; }
    }
}
