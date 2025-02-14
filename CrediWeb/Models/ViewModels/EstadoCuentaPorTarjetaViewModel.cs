using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrediWeb.Models.ViewModels
{
    public class EstadoCuentaPorTarjetaViewModel
    {
        public List<ComprasPorMesViewModel> ComprasMensuales { get; set; }
        public EstadoCuentaViewModel EstadoCuentaTarjeta { get; set; }
    }
}
