using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrediWeb.Models.ViewModels
{
    public class ComprasPorMesViewModel
    {
        public int MovimientoID { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
    }
}
