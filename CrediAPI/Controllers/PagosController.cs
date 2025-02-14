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
    public class PagosController : ControllerBase
    {        
        private readonly IMediator mediator;
        public PagosController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpGet("GetPagoByID")]
        public async Task<IActionResult> GetPagoByID(int PagoID)
        {
            try
            {
                var result = await mediator.Send(new GetPagoByIDQuery(PagoID));
                if (result == null)
                {
                    return NotFound(new { message = $"Pago no encontrado en el sistema!" });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error! se genero un problema con el sistema, intente mas tarde!");
            }
        }

        [HttpGet("GetAllPagos")]
        public async Task<IActionResult> GetAllPagos()
        {
            try
            {
                return Ok(await mediator.Send(new GetAllPagosQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest($"Error! se genero un problema con el sistema, intente mas tarde!");
            }
        }

        [HttpGet("GetAllPagosByTitular")]
        public async Task<IActionResult> GetAllPagosByTitular(int TitularID)
        {
            try
            {
                var result = await mediator.Send(new GetPagosByTitularQuery(TitularID));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error! se genero un problema con el sistema, intente mas tarde!");
            }
        }

        [HttpGet("GetAllPagosByTarjeta")]
        public async Task<IActionResult> GetAllPagosByTarjeta(int tarjetaID, int mes)
        {
            try
            {
                var result = await mediator.Send(new GetPagosByTarjetaQuery(tarjetaID, mes));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error! se genero un problema con el sistema, intente mas tarde!");
            }
        }

        [HttpPost("NewPago")]
        public async Task<IActionResult> NewPago([FromBody] NewPagoCommand command)
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
    }
}

