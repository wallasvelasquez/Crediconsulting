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
    public class TitularController : ControllerBase
    {
        private readonly IMediator mediator;
        public TitularController(IMediator _mediator)
        {
            mediator = _mediator; 
        }

        [HttpGet("GetTitular")]
        public async Task<IActionResult> GetTitular(int TitularID)
        {
            try
            {
                var result = await mediator.Send(new GetTitularByIDQuery(TitularID));
                if(result == null)
                {
                    return NotFound(new { message = $"Titular no encontrado en el sistema!" });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error! se genero un problema con el sistema, intente mas tarde!");
            }
        }

        [HttpGet("GetAllTitulares")]
        public async Task<IActionResult> GetAllTitulares()
        {
            try
            {
                return Ok(await mediator.Send(new GetAllTitularesQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest($"Error! se genero un problema con el sistema, intente mas tarde!");
            }
        }

        [HttpPost("NewTitular")]
        public async Task<IActionResult> NewTitular([FromBody] NewTitularCommand command)
        {
            try
            {
                var response = await mediator.Send(command);
                return response.Success ? Ok(response.Message) : BadRequest(response.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error! se genero un problema con el sistema, intente mas tarde");
            }
        }

    }
}
