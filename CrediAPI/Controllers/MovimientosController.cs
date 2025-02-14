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
    public class MovimientosController : ControllerBase
    {
        private readonly IMediator mediator;
        public MovimientosController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpGet("GetCompraByID")]
        public async Task<IActionResult> GetCompra(int CompraID)
        {
            try
            {
                var result = await mediator.Send(new GetCompraByIDQuery(CompraID));
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

        [HttpGet("GetAllCompras")]
        public async Task<IActionResult> GetAllCompras()
        {
            try
            {
                return Ok(await mediator.Send(new GetAllComprasQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest($"Error! se genero un problema con el sistema, intente mas tarde!");
            }
        }

        [HttpGet("GetAllComprasByTitular")]
        public async Task<IActionResult> GetAllComprasByTitular(int TitularID)
        {
            try
            {
                var result = await mediator.Send(new GetComprasByTitularQuery(TitularID));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error! se genero un problema con el sistema, intente mas tarde!");
            }
        }

        [HttpGet("GetAllComprasByTarjeta/{TarjetaID}/{Mes}")]
        public async Task<IActionResult> GetAllComprasByTarjeta(int TarjetaID, int Mes)
        {
            try
            {
                var result = await mediator.Send(new GetComprasByTarjetaQuery(TarjetaID, Mes));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error! se genero un problema con el sistema, intente mas tarde!");
            }
        }

        [HttpPost("NewCompra")]
        public async Task<IActionResult> NewCompra([FromBody] NewCompraCommand command)
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
