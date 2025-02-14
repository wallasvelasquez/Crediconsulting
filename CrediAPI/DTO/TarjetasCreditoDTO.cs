using System;

namespace CrediAPI.DTO
{
    public class TarjetasCreditoDTO
    {
        public int TarjetaID { get; set; }
        public int TitularID { get; set; }
        public string NumeroTarjeta { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public string CVV { get; set; }
        public decimal LimiteCredito { get; set; }
        public decimal PorcentajeInteresConfigurable { get; set; }
        public decimal PorcentajeConfigurableSaldoMinimo { get; set; }
    }
}
