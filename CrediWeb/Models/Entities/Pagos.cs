using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CrediWeb.Models.Entities
{
    [Table("Pagos")]
    public class Pagos
    {
        public Pagos()
        {

        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int PagoID { get; set; }
        public int TarjetaID { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; }
    }
}
