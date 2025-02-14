using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrediAPI.Models.Entities
{
    [Table("TarjetaCredito")]
    public class TarjetaCredito
    {
        public TarjetaCredito()
        {

        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

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
