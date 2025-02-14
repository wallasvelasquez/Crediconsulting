using System;

namespace CrediAPI.Models.Entities
{
    public class Transacciones
    {
        public int TransaccionID { get; set; }
        public string NumeroTarjeta { get; set; }
        public string TipoTransaccion { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
    }
}
