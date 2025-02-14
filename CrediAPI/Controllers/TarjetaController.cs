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
    public class TarjetaController : ControllerBase
    {
        private readonly IMediator mediator;
        public TarjetaController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpGet("GetTarjetaByNumero")]
        public async Task<IActionResult> GetTarjetaByNumero(string NumeroTarjeta)
        {
            try
            {
                var result = await mediator.Send(new GetTarjetaByIDQuery(NumeroTarjeta));
                if (result == null)
                {
                    return NotFound(new { message = $"Tarjeta no encontrada en el sistema!" });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error! se genero un problema con el sistema, intente mas tarde!");
            }
        }

        [HttpGet("GetTarjetaByTitular")]
        public async Task<IActionResult> GetTarjetaByTitular(int TitularID)
        {
            try
            {
                return Ok(await mediator.Send(new GetTarjetaByTitularQuery(TitularID)));
            }
            catch (Exception ex)
            {
                return BadRequest($"Error! se genero un problema con el sistema, intente mas tarde!");
            }
        }

        [HttpGet("GetAllTarjetas")]
        public async Task<IActionResult> GetAllTarjetas()
        {
            try
            {
                return Ok(await mediator.Send(new GetAllTarjetasQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest($"Error! se genero un problema con el sistema, intente mas tarde!");
            }
        }

        [HttpGet("GetAllTarjetasByTitular")]
        public async Task<IActionResult> GetAllTarjetasByTitular(int TitularID)
        {
            try
            {
                return Ok(await mediator.Send(new GetAllTarjetaByTitularQuery(TitularID)));
            }
            catch (Exception ex)
            {
                return BadRequest($"Error! se genero un problema con el sistema, intente mas tarde!");
            }
        }

        [HttpPost("NewTarjeta")]
        public async Task<IActionResult> NewTarjeta([FromBody] NewTarjetaCreditoCommand command)
        {
            try
            {
                var response = await mediator.Send(command);
                return response.Success ? Ok(response.Message) : BadRequest(response.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error! se genero un problema con el sistema, intente mas tarde!");
            }
        }

        [HttpGet("GetTransaccionesTarjeta/{TarjetaID}")]
        public async Task<IActionResult> GetTransaccionesTarjeta(int TarjetaID)
        {
            try
            {
                var result = await mediator.Send(new GetTransaccionesTarjetaQuery(TarjetaID));
                if (result == null)
                {
                    return NotFound(new { message = $"Transacciones no encontradas para la tarjeta en el sistema!" });
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
