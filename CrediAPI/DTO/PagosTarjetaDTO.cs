using System;

namespace CrediAPI.DTO
{
    public class PagosTarjetaDTO
    {
        public int PagoID { get; set; }
        public int TarjetaID { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; }
    }
}
