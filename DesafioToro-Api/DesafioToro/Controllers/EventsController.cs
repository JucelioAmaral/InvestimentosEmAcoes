using DesafioToro.Application;
using DesafioToro.Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DesafioToro.Api.Controllers
{
    [ApiController]
    [Route("spb/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit(EventDto model)
        {
            try
            {
                if (model.EventName == "DEPOSIT")
                {
                    var eventOne = await _eventService.AddEvent(model);
                    if (eventOne == null) return NoContent();

                    return Ok(eventOne);
                }
                return BadRequest("Campo ou valor do EventName informado incorretamente.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Post: Erro ao tentar adicionar event. Erro: {ex.Message}");
            }
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> Transfer(EventDto model)
        {
            try
            {
                //Check if already there is CPF
                if (await _eventService.CheckCPF(model.Origin.CPF))
                {
                    var eventOne = await _eventService.AddEvent(model);
                    if (eventOne == null) return NoContent();

                    return Ok(eventOne);
                }
                return NotFound($"CPF {model.Origin.CPF} não encontrado.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Post: Erro ao tentar adicionar event. Erro: {ex.Message}");
            }
        }
    }
}
