using System;

namespace CrediAPI.DTO
{
    public class TransaccionesDTO
    {
        public int TransaccionID { get; set; }
        public string NumeroTarjeta { get; set; }
        public string TipoTransaccion { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; } 

    }
}
