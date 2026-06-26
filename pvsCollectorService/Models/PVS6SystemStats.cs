using System;
using System.Collections.Generic;
using System.Text;

namespace pvsCollectorService.Models
{
    /*
     * https://github.com/SunStrong-Management/pypvs/blob/main/doc/varserver-variables-public-pvs6.csv
        /sys/pvs/flashwear_type_b   uint16  0x05    sysstats Percentage lifetime estimation as HEX value(0x01 = 10%, 0x9 = 90%). E.g. 0x1 means that 10 % of the EMMC lifetime passed.This value holds current value for TYPE B cell.
        /sys/pvs/usb_erase_count    uint16	0	    sysstats SMART Attribute 229 Erase Count Usage which is a measurement to tell the health state of USB drive.
    */

    public class PVS6SystemStats
    {
        /// <summary>
        /// Percentage lifetime estimation as HEX value(0x01 = 10%, 0x9 = 90%). E.g. 0x1 means that 10 % of the EMMC lifetime passed.This value holds current value for TYPE B cell.
        /// </summary>
        public ushort flashwear_type_b { get; set; }
        /// <summary>
        /// SMART Attribute 229 Erase Count Usage which is a measurement to tell the health state of USB drive.
        /// </summary>
        public ushort usb_erase_count { get; set; }
    }
}
