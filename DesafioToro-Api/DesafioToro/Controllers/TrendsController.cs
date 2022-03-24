using AutoMapper;
using DesafioToro.Application.Contracts;
using DesafioToro.Application.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DesafioToro.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrendsController : ControllerBase
    {
        private readonly ITrendService _trendService;
        private readonly IMapper _mapper;

        public TrendsController(ITrendService trendService, IMapper mapper)
        {
            _trendService = trendService;
            _mapper = mapper; ;
        }

        [HttpGet("trends")]
        public async Task<IActionResult> TrendsMoreTrated()
        {
            try
            {
                var trends = await _trendService.GetFiveTrendsInSevenDays();
                if (trends == null) return null;

                return Ok(trends);
                 
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Post: Erro ao buscar os 5 ativos mais negociados nos últimos 7 dias. Erro: {ex.Message}");
            }
        }

        [HttpPost("insertTrend")]
        public async Task<IActionResult> InsertTrend(TrendDto model)
        {
            try
            {
                var trend = await _trendService.AddTrend(model);
                if (trend == null) return NoContent();

                return Ok(trend);                
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Post: Erro ao inserir ativo. Erro: {ex.Message}");
            }
        }
    }
}
