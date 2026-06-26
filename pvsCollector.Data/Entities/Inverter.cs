using Microsoft.EntityFrameworkCore;

namespace pvsCollector.Data.Entities
{
    [Index(nameof(sn))]
    public class Inverter
    {
        public int Id { get; set; }
        public DateTime WrittenAt { get; set; }
        /// <summary>
        /// Frequency in Hz dectected by the inverter
        /// </summary>
        public float freqHz { get; set; }
        /// <summary>
        /// Sum of phase currents in A
        /// </summary>
        public float i3phsumA { get; set; }
        /// <summary>
        /// Current of MPPT1 in A
        /// </summary>
        public float iMppt1A { get; set; }
        /// <summary>
        /// Lifetime sum of 3-phase energy in kWh
        /// </summary>
        public float ltea3phsum { get; set; }
        /// <summary>
        /// Timestamp of the last measurement
        /// </summary>
        public string msmtEps { get; set; }
        /// <summary>
        /// Sum of 3-phase power in kW
        /// </summary>
        public float p3phsumKw { get; set; }
        /// <summary>
        /// Power of MPPT1 in kW
        /// </summary>
        public float pMppt1Kw { get; set; }
        /// <summary>
        /// Product model name
        /// </summary>
        public string prodMdlNm { get; set; }
        /// <summary>
        /// Serial number of the inverter
        /// </summary>
        public string sn { get; set; }
        /// <summary>
        /// Temperature of the heat sink in °C
        /// </summary>
        public int tHtsnkDegc { get; set; }
        /// <summary>
        /// Voltage of MPPT1 in V
        /// </summary>
        public float vMppt1V { get; set; }
        /// <summary>
        /// Average line-to-neutral voltage of 3-phase system in V
        /// </summary>
        public float vln3phavgV { get; set; }
    }
}
