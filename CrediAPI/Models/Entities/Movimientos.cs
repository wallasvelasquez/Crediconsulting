using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrediAPI.Models.Entities
{
    [Table("Movimientos")]
    public class Movimientos
    {
        public Movimientos()
        {

        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int MovimientoID { get; set; }
        public int TarjetaID { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
    }
}
