using CrediWeb.Models.Entities;
using CrediWeb.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using QuestPDF.Fluent;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace CrediWeb.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly IWebHostEnvironment path;
        public TransactionsController(IWebHostEnvironment _path)
        {
            path = _path;
        }

        //************************************************* COMPRAS ******************************************************//
        public async Task<IActionResult> Compras()
        {
            List<TarjetaCredito> listatarjetas = new List<TarjetaCredito>();
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://localhost:44340/api/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string url = "Tarjeta/GetAllTarjetas";
                HttpResponseMessage response = await cliente.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    listatarjetas = await response.Content.ReadFromJsonAsync<List<TarjetaCredito>>();
                }
            }
            return View("~/Views/Transactions/Compras.cshtml", listatarjetas);
        }

        public async Task<IActionResult> GetCompras()
        {
            List<Movimientos> compras = new List<Movimientos>();
            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri("https://localhost:44340/api/");
                    cliente.DefaultRequestHeaders.Accept.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string url = "Movimientos/GetAllCompras";
                    HttpResponseMessage response = await cliente.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        compras = await response.Content.ReadFromJsonAsync<List<Movimientos>>();
                    }
                }
                return Json(new { data = compras });
            }
            catch (Exception ex)
            {
                return Json(new { data = compras });
            }
        }

        public IActionResult AddCompra(IFormCollection Data)
        {
            try
            {
                Movimientos compra = new Movimientos()
                {
                    TarjetaID = Convert.ToInt32(Data["TarjetaID"]),
                    FechaMovimiento = DateTime.Now,
                    Descripcion = Data["Descripcion"].ToString(),
                    Monto = Convert.ToDecimal(Data["Monto"].ToString())
                };

                string jsonContent = JsonConvert.SerializeObject(compra);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                string messageResult = "";
                using (HttpClient cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri("https://localhost:44340/api/");
                    cliente.DefaultRequestHeaders.Accept.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = cliente.PostAsync("Movimientos/NewCompra", httpContent).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        messageResult = response.Content.ReadAsStringAsync().Result.Trim('"');
                    }
                }
                return Json(new { msg = messageResult, e = 1 });
            }
            catch (Exception e)
            {
                return Json(new { msg = "Error, no se pudo agregar la compra!" });
            }
        }

        //************************************************** PAGOS *******************************************************//

        public async Task<IActionResult> Pagos()
        {
            List<TarjetaCredito> listatarjetas = new List<TarjetaCredito>();
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://localhost:44340/api/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string url = "Tarjeta/GetAllTarjetas";
                HttpResponseMessage response = await cliente.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    listatarjetas = await response.Content.ReadFromJsonAsync<List<TarjetaCredito>>();
                }
            }
            return View("~/Views/Transactions/Pagos.cshtml", listatarjetas);
        }

        public async Task<IActionResult> GetPagos()
        {
            List<Pagos> pagos = new List<Pagos>();
            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri("https://localhost:44340/api/");
                    cliente.DefaultRequestHeaders.Accept.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string url = "Pagos/GetAllPagos";
                    HttpResponseMessage response = await cliente.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        pagos = await response.Content.ReadFromJsonAsync<List<Pagos>>();
                    }
                }
                return Json(new { data = pagos });
            }
            catch (Exception ex)
            {
                return Json(new { data = pagos });
            }
        }

        public IActionResult AddPago(IFormCollection Data)
        {
            try
            {
                Pagos pago = new Pagos()
                {
                    TarjetaID = Convert.ToInt32(Data["TarjetaID"]),
                    FechaPago = DateTime.Now,                    
                    Monto = Convert.ToDecimal(Data["Monto"].ToString()),
                    MetodoPago = Data["MetodoPago"].ToString()
                };

                string jsonContent = JsonConvert.SerializeObject(pago);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                string messageResult = "";
                using (HttpClient cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri("https://localhost:44340/api/");
                    cliente.DefaultRequestHeaders.Accept.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = cliente.PostAsync("Pagos/NewPago", httpContent).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        messageResult = response.Content.ReadAsStringAsync().Result.Trim('"');
                    }
                }
                return Json(new { msg = messageResult, e = 1 });
            }
            catch (Exception e)
            {
                return Json(new { msg = "Error, no se pudo efectuar el pago!" });
            }
        }

        //************************************************** HISTORIAL *******************************************************//
        public async Task<IActionResult> Historial()
        {
            List<TarjetaCredito> listatarjetas = new List<TarjetaCredito>();
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://localhost:44340/api/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string url = "Tarjeta/GetAllTarjetas";
                HttpResponseMessage response = await cliente.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    listatarjetas = await response.Content.ReadFromJsonAsync<List<TarjetaCredito>>();
                }
            }
            return View("~/Views/Transactions/Historial.cshtml", listatarjetas);
        }
        public async Task<IActionResult> GetTransaccionesTarjeta(int TarjetaID)
        {
            List<TransaccionesViewModel> transacciones = new List<TransaccionesViewModel>();
            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri("https://localhost:44340/api/");
                    cliente.DefaultRequestHeaders.Accept.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string url = $"Tarjeta/GetTransaccionesTarjeta/{TarjetaID}";
                    HttpResponseMessage response = await cliente.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        transacciones = await response.Content.ReadFromJsonAsync<List<TransaccionesViewModel>>();
                    }
                }
                return Json(new { data = transacciones , e = 1});
            }
            catch (Exception ex)
            {
                return Json(new { data = transacciones });
            }
        }
        //************************************************** ESTADO CUENTA ***************************************************//
        public async Task<IActionResult> EstadosCuenta()
        {
            List<TarjetaCredito> listatarjetas = new List<TarjetaCredito>();
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://localhost:44340/api/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string url = "Tarjeta/GetAllTarjetas";
                HttpResponseMessage response = await cliente.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    listatarjetas = await response.Content.ReadFromJsonAsync<List<TarjetaCredito>>();
                }
            }
            return View("~/Views/Transactions/EstadosCuenta.cshtml", listatarjetas);
        }
        public async Task<IActionResult> GetEstadoCuentaByTarjeta(int TarjetaID)
        {

            int Mes = DateTime.Now.Month;
            EstadoCuentaPorTarjetaViewModel model = new EstadoCuentaPorTarjetaViewModel();
            ViewBag.Tarjeta = TarjetaID;
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://localhost:44340/api/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string url1 = $"EstadoCuenta/GetEstadoCuentaByTarjeta/{TarjetaID}/{Mes}";
                HttpResponseMessage response1 = await cliente.GetAsync(url1);
                if (response1.IsSuccessStatusCode)
                {
                    model.EstadoCuentaTarjeta = await response1.Content.ReadFromJsonAsync<EstadoCuentaViewModel>();
                }
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string url2 = $"Movimientos/GetAllComprasByTarjeta/{TarjetaID}/{Mes}";
                HttpResponseMessage response2 = await cliente.GetAsync(url2);
                if (response2.IsSuccessStatusCode)
                {
                    model.ComprasMensuales = await response2.Content.ReadFromJsonAsync<List<ComprasPorMesViewModel>>();
                }
            }
            return PartialView("~/Views/Transactions/_EstadoCuentaPartial.cshtml", model);
        }

        public async Task<IActionResult> GenerarEstadoCuentaPDF(int TarjetaID)
        {
            int Mes = DateTime.Now.Month;
            EstadoCuentaPorTarjetaViewModel model = new EstadoCuentaPorTarjetaViewModel();
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://localhost:44340/api/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string url1 = $"EstadoCuenta/GetEstadoCuentaByTarjeta/{TarjetaID}/{Mes}";
                HttpResponseMessage response1 = await cliente.GetAsync(url1);
                if (response1.IsSuccessStatusCode)
                {
                    model.EstadoCuentaTarjeta = await response1.Content.ReadFromJsonAsync<EstadoCuentaViewModel>();
                }
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string url2 = $"Movimientos/GetAllComprasByTarjeta/{TarjetaID}/{Mes}";
                HttpResponseMessage response2 = await cliente.GetAsync(url2);
                if (response2.IsSuccessStatusCode)
                {
                    model.ComprasMensuales = await response2.Content.ReadFromJsonAsync<List<ComprasPorMesViewModel>>();
                }
            }            
            var documentPDF = Document.Create(document =>
            {
                document.Page(page =>
                {
                    page.Margin(30);
                    page.Content().PaddingVertical(10).Column(col1 =>
                    {
                        col1.Item().PaddingBottom(10).Column(txt =>
                        {
                            txt.Item().AlignCenter().AlignBottom().Text("Estado de Cuenta de Tarjeta de Credito").LetterSpacing(0.05f).Bold().FontSize(18).FontColor("#09092d");
                        });
                        col1.Item().Row(rw =>
                        {             
                            rw.RelativeItem(1).Column(cl1 =>
                            {
                                cl1.Item().Table(tb1 =>
                                {
                                    tb1.ColumnsDefinition(coldef1 =>
                                    {
                                        coldef1.RelativeColumn(5);
                                        coldef1.RelativeColumn(5); 
                                    });

                                    tb1.Cell().BorderLeft(0.5f).BorderColor("#D9D9D9").BorderTop(0.5f).BorderColor("#D9D9D9").Padding(5).Text("Titular: ").Bold().FontSize(10).FontColor("#09092d");
                                    tb1.Cell().BorderRight(0.5f).BorderColor("#D9D9D9").BorderTop(0.5f).BorderColor("#D9D9D9").Padding(5).Text(model.EstadoCuentaTarjeta.Titular).FontSize(10).FontColor("#09092d");
                                    tb1.Cell().BorderLeft(0.5f).BorderColor("#D9D9D9").Padding(5).Text("No. Tarjeta: ").Bold().FontSize(10).FontColor("#09092d");
                                    tb1.Cell().BorderRight(0.5f).BorderColor("#D9D9D9").Padding(5).Text(model.EstadoCuentaTarjeta.NumeroTarjeta).FontSize(10).FontColor("#09092d");
                                    tb1.Cell().BorderLeft(0.5f).BorderColor("#D9D9D9").Padding(5).Text("Limite de Credito: ").Bold().FontSize(10).FontColor("#09092d");
                                    tb1.Cell().BorderRight(0.5f).BorderColor("#D9D9D9").Padding(5).Text("$" + model.EstadoCuentaTarjeta.LimiteCredito.ToString()).FontSize(10).FontColor("#09092d");
                                    tb1.Cell().BorderLeft(0.5f).BorderColor("#D9D9D9").Padding(5).Text("Interes Configurable (%): ").Bold().FontSize(10).FontColor("#09092d");
                                    tb1.Cell().BorderRight(0.5f).BorderColor("#D9D9D9").Padding(5).Text(model.EstadoCuentaTarjeta.PorcentajeInteresConfigurable.ToString() + "%").FontSize(10).FontColor("#09092d");
                                    tb1.Cell().BorderLeft(0.5f).BorderColor("#D9D9D9").BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(5).Text("Saldo Minimo (%): ").Bold().FontSize(10).FontColor("#09092d");
                                    tb1.Cell().BorderRight(0.5f).BorderColor("#D9D9D9").BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(5).Text(model.EstadoCuentaTarjeta.PorcentajeConfigurableSaldoMinimo.ToString() + "%").FontSize(10).FontColor("#09092d");
                                });
                            });
                            rw.RelativeItem(1).Column(cl2 =>
                            {
                                cl2.Item().Table(tb2 =>
                                {
                                    tb2.ColumnsDefinition(coldef2 =>
                                    {
                                        coldef2.RelativeColumn(5);
                                        coldef2.RelativeColumn(5);
                                    });

                                    tb2.Cell().BorderLeft(0.5f).BorderColor("#D9D9D9").BorderTop(0.5f).BorderColor("#D9D9D9").Padding(5).Text("Saldo Actual: ").Bold().FontSize(10).FontColor("#09092d");
                                    tb2.Cell().BorderRight(0.5f).BorderColor("#D9D9D9").BorderTop(0.5f).BorderColor("#D9D9D9").Padding(5).Text("$" + model.EstadoCuentaTarjeta.SaldoActual.ToString()).FontSize(10).FontColor("#09092d");
                                    tb2.Cell().BorderLeft(0.5f).BorderColor("#D9D9D9").Padding(5).Text("Saldo Disponible: ").Bold().FontSize(10).FontColor("#09092d");
                                    tb2.Cell().BorderRight(0.5f).BorderColor("#D9D9D9").Padding(5).Text("$" + model.EstadoCuentaTarjeta.SaldoDisponible.ToString()).FontSize(10).FontColor("#09092d");
                                    tb2.Cell().BorderLeft(0.5f).BorderColor("#D9D9D9").Padding(5).Text("Interes Bonificable ($): ").Bold().FontSize(10).FontColor("#09092d");
                                    tb2.Cell().BorderRight(0.5f).BorderColor("#D9D9D9").Padding(5).Text("$" + model.EstadoCuentaTarjeta.InteresBonificable.ToString()).FontSize(10).FontColor("#09092d");
                                    tb2.Cell().BorderLeft(0.5f).BorderColor("#D9D9D9").Padding(5).Text("Cuota Minima: ").Bold().FontSize(10).FontColor("#09092d");
                                    tb2.Cell().BorderRight(0.5f).BorderColor("#D9D9D9").Padding(5).Text("$" + model.EstadoCuentaTarjeta.CuotaMinima.ToString()).FontSize(10).FontColor("#09092d");
                                    tb2.Cell().BorderLeft(0.5f).BorderColor("#D9D9D9").Padding(5).Text("Monto Total Mes Actual: ").Bold().FontSize(10).FontColor("#09092d");
                                    tb2.Cell().BorderRight(0.5f).BorderColor("#D9D9D9").Padding(5).Text("$" + model.EstadoCuentaTarjeta.MontoTotalMesActual.ToString()).FontSize(10).FontColor("#09092d");
                                    tb2.Cell().BorderLeft(0.5f).BorderColor("#D9D9D9").Padding(5).Text("Monto Total Mes Anterior: ").Bold().FontSize(10).FontColor("#09092d");
                                    tb2.Cell().BorderRight(0.5f).BorderColor("#D9D9D9").Padding(5).Text("$" + model.EstadoCuentaTarjeta.MontoTotalMesAnterior.ToString()).FontSize(10).FontColor("#09092d");
                                    tb2.Cell().BorderLeft(0.5f).BorderColor("#D9D9D9").BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(5).Text("Monto Total + Intereses: ").Bold().FontSize(10).FontColor("#09092d");
                                    tb2.Cell().BorderRight(0.5f).BorderColor("#D9D9D9").BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(5).Text("$" + model.EstadoCuentaTarjeta.MontoTotalContadoInteres.ToString()).FontSize(10).FontColor("#09092d");
                                });
                            });
                        });


                        col1.Item().AlignCenter().PaddingVertical(10).Text("Compras Realizadas").Bold().FontSize(12).FontColor("#09092d");
                        col1.Item().Table(tabla =>
                        {
                            tabla.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(6);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(3);
                            });
                            tabla.Header(header =>
                            {
                                header.Cell().Border(0.5f).BorderColor("#D9D9D9").Background("#09092d").AlignCenter().AlignMiddle().Padding(2).Text("Codigo").FontSize(10).SemiBold().FontColor("#ffffff");
                                header.Cell().Border(0.5f).BorderColor("#D9D9D9").Background("#09092d").AlignCenter().AlignMiddle().Padding(2).Text("Descripcion").FontSize(10).SemiBold().FontColor("#ffffff");
                                header.Cell().Border(0.5f).BorderColor("#D9D9D9").Background("#09092d").AlignCenter().AlignMiddle().Padding(2).Text("Monto").FontSize(10).SemiBold().FontColor("#ffffff");
                                header.Cell().Border(0.5f).BorderColor("#D9D9D9").Background("#09092d").AlignCenter().AlignMiddle().Padding(2).Text("Fecha").FontSize(10).SemiBold().FontColor("#ffffff");
                            });
                            foreach (var item in model.ComprasMensuales)
                            {
                                tabla.Cell().Border(0.5f).BorderColor("#D9D9D9").AlignCenter().AlignMiddle().Padding(2).Text(item.MovimientoID.ToString()).FontSize(10).FontColor("#09092d");
                                tabla.Cell().Border(0.5f).BorderColor("#D9D9D9").AlignCenter().AlignMiddle().Padding(2).Text(item.Descripcion).FontSize(10).FontColor("#09092d");
                                tabla.Cell().Border(0.5f).BorderColor("#D9D9D9").AlignCenter().AlignMiddle().Padding(2).Text("$" + item.Monto.ToString()).FontSize(10).FontColor("#09092d");
                                tabla.Cell().Border(0.5f).BorderColor("#D9D9D9").AlignCenter().AlignMiddle().Padding(2).Text(Convert.ToDateTime(item.FechaMovimiento).ToShortDateString()).FontSize(10).FontColor("#09092d");
                            }
                        });

                        col1.Spacing(10);
                    });
                    page.Footer().AlignRight().Text(txt =>
                    {
                        txt.Span("Page ").FontSize(10);
                        txt.CurrentPageNumber().FontSize(10);
                        txt.Span(" of ").FontSize(10);
                        txt.TotalPages().FontSize(10);
                    });
                });
            }).GeneratePdf();
            Stream stream = new MemoryStream(documentPDF);
            return File(stream, "application/pdf", "Estado de Cuenta - " + model.EstadoCuentaTarjeta.Titular + ".pdf");
        }
    }
    
}
