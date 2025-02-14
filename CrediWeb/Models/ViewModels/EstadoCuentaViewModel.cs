﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrediWeb.Models.ViewModels
{
    public class EstadoCuentaViewModel
    {
        public string Titular { get; set; }
        public string NumeroTarjeta { get; set; }
        public decimal LimiteCredito { get; set; }
        public decimal SaldoActual { get; set; }
        public decimal SaldoDisponible { get; set; }
        public decimal MontoTotalMesActual { get; set; }
        public decimal MontoTotalMesAnterior { get; set; }
        public decimal PorcentajeInteresConfigurable { get; set; }
        public decimal PorcentajeConfigurableSaldoMinimo { get; set; }
        public decimal InteresBonificable { get; set; }
        public decimal CuotaMinima { get; set; }
        public decimal MontoTotalContadoInteres { get; set; }
    }
}
