using CrediWeb.Models.Entities;
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

namespace CrediWeb.Controllers
{
    public class MaintenanceController : Controller
    {
        public IActionResult Titulares()
        {
            return View("~/Views/Maintenance/Titulares.cshtml");
        }
        public async Task<IActionResult> Tarjetas()
        {
            List<Titular> listatitulares = new List<Titular>();
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://localhost:44340/api/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string url = "Titular/GetAllTitulares";
                HttpResponseMessage response = await cliente.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    listatitulares = await response.Content.ReadFromJsonAsync<List<Titular>>();
                }
            }
            return View("~/Views/Maintenance/Tarjetas.cshtml", listatitulares);
        }
        public async Task<IActionResult> GetTitulares()
        {
            List<Titular> titulares = new List<Titular>();
            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri("https://localhost:44340/api/");
                    cliente.DefaultRequestHeaders.Accept.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string url = "Titular/GetAllTitulares";
                    HttpResponseMessage response = await cliente.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        titulares = await response.Content.ReadFromJsonAsync<List<Titular>>();
                    }
                }
                return Json(new { data = titulares });
            }
            catch (Exception ex)
            {
                return Json(new { data = titulares });
            }
        }

        public async Task<IActionResult> GetTarjetas()
        {
            List<TarjetaCredito> tarjetas = new List<TarjetaCredito>();
            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri("https://localhost:44340/api/");
                    cliente.DefaultRequestHeaders.Accept.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string url = "Tarjeta/GetAllTarjetas";
                    HttpResponseMessage response = await cliente.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        tarjetas = await response.Content.ReadFromJsonAsync<List<TarjetaCredito>>();
                    }
                }
                return Json(new { data = tarjetas });
            }
            catch (Exception ex)
            {
                return Json(new { data = tarjetas });
            }
        }

        public IActionResult AddTarjeta(IFormCollection Data)
        {
            try
            {
                TarjetaCredito tarjeta = new TarjetaCredito()
                {
                    TitularID = Convert.ToInt32(Data["TitularID"]),
                    NumeroTarjeta = Data["NumeroTarjeta"].ToString(),
                    FechaExpiracion = DateTime.Now.AddYears(5),
                    CVV = Data["CVV"].ToString(),
                    LimiteCredito = Convert.ToDecimal(Data["LimiteCredito"].ToString()),
                    PorcentajeInteresConfigurable = Convert.ToDecimal(Data["PorcentajeInteresConfigurable"].ToString()),
                    PorcentajeConfigurableSaldoMinimo = Convert.ToDecimal(Data["PorcentajeConfigurableSaldoMinimo"].ToString())
                };

                string jsonContent = JsonConvert.SerializeObject(tarjeta);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                string messageResult = "";
                using (HttpClient cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri("https://localhost:44340/api/");
                    cliente.DefaultRequestHeaders.Accept.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = cliente.PostAsync("Tarjeta/NewTarjeta", httpContent).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        messageResult = response.Content.ReadAsStringAsync().Result.Trim('"');
                    }
                }
                return Json(new { msg = messageResult, e = 1 });
            }
            catch (Exception e)
            {
                return Json(new { msg = "Error, no se pudo crear la tarjeta!" });
            }
        }

        public IActionResult AddTitular(IFormCollection Data)
        {
            try
            {
                Titular persona = new Titular()
                {
                    Nombres = Data["Nombres"].ToString(),
                    Apellidos = Data["Apellidos"].ToString(),
                    Correo = Data["Correo"].ToString()
                };

                string jsonContent = JsonConvert.SerializeObject(persona);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                string messageResult = "";
                using (HttpClient cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri("https://localhost:44340/api/");
                    cliente.DefaultRequestHeaders.Accept.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = cliente.PostAsync("Titular/NewTitular", httpContent).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        messageResult = response.Content.ReadAsStringAsync().Result.Trim('"');
                    }                    
                }
                return Json(new { msg = messageResult, e = 1 });
            }
            catch (Exception e)
            {
                return Json(new { msg = "Error, no se pudo crear el titular!" });
            }
        }

    }
}
