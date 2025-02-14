using System;

namespace CrediAPI.DTO
{
    public class PagosCatalogoDTO
    {
        public int PagoID { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; }
    }
}
