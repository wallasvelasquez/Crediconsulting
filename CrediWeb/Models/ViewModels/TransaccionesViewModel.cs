using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrediWeb.Models.ViewModels
{
    public class TransaccionesViewModel
    {
        public int TransaccionID { get; set; }
        public string NumeroTarjeta { get; set; }
        public string TipoTransaccion { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
    }
}
