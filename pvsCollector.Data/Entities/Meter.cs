using Microsoft.EntityFrameworkCore;

namespace pvsCollector.Data.Entities
{
    [Index(nameof(sn))]
    public class Meter
    {
        public int Id { get; set; }
        public DateTime WrittenAt { get; set; }
        /// <summary>
        /// CT scaling factor
        /// </summary>
        public int ctSclFctr { get; set; }
        /// <summary>
        /// Frequency in Hz
        /// </summary>
        public float freqHz { get; set; }
        /// <summary>
        /// Current in A for phase 1
        /// </summary>
        public float i1A { get; set; }
        /// <summary>
        /// Current in A for phase 2
        /// </summary>
        public float i2A { get; set; }
        /// <summary>
        /// Timestamp of the last measurement
        /// </summary>
        public string msmtEps { get; set; }
        /// <summary>
        /// Negative lifetime sum of 3-phase energy in kWh
        /// </summary>
        public float negLtea3phsumKwh { get; set; }
        /// <summary>
        /// Net lifetime sum of 3-phase energy in kWh
        /// </summary>
        public float netLtea3phsumKwh { get; set; }
        /// <summary>
        /// Power in kW for phase 1
        /// </summary>
        public float p1Kw { get; set; }
        /// <summary>
        /// Power in kW for phase 2
        /// </summary>
        public float p2Kw { get; set; }
        /// <summary>
        /// Sum of 3-phase power in kW
        /// </summary>
        public float p3phsumKw { get; set; }
        /// <summary>
        /// Positive lifetime sum of 3-phase energy in kWh
        /// </summary>
        public float posLtea3phsumKwh { get; set; }
        /// <summary>
        /// Product model name
        /// </summary>
        public string prodMdlNm { get; set; }
        /// <summary>
        /// Sum of 3-phase reactive power in kVar
        /// </summary>
        public float q3phsumKvar { get; set; }
        /// <summary>
        /// Sum of 3-phase apparent power in kVA
        /// </summary>
        public float s3phsumKva { get; set; }
        /// <summary>
        /// Serial number of the meter
        /// </summary>
        public string sn { get; set; }
        /// <summary>
        /// Total power factor ratio
        /// </summary>
        public float totPfRto { get; set; }
        /// <summary>
        /// Voltage between phase 1 and 2 in V
        /// </summary>
        public float v12V { get; set; }
        /// <summary>
        /// Voltage between phase 1 and neutral in V
        /// </summary>
        public float v1nV { get; set; }
        /// <summary>
        /// Voltage between phase 2 and neutral in V
        /// </summary>
        public float v2nV { get; set; }
    }
}
