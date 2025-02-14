using System;

namespace CrediAPI.DTO
{
    public class MovimientosCatalogoDTO
    {
        public int MovimientoID { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
    }
}
