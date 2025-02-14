using CrediAPI.CQRS.Commands;
using CrediAPI.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CrediAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoCuentaController : ControllerBase
    {
        private readonly IMediator mediator;
        public EstadoCuentaController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpGet("GetEstadoCuentaByTarjeta/{TarjetaID}/{Mes}")]
        public async Task<IActionResult> GetEstadoCuentaByTarjeta(int TarjetaID, int Mes)
        {
            try
            {
                var result = await mediator.Send(new GetEstadoCuentaByTarjetaCreditoQuery(TarjetaID, Mes));
                if (result == null)
                {
                    return NotFound(new { message = $"Estado de cuenta no encontrado en el sistema!" });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error! se genero un problema con el sistema, intente mas tarde!");
            }
        }
    }
}
