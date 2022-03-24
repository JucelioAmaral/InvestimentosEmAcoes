using DesafioToro.Application.DTO;
using DesafioToro.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioToro.Application.Contracts
{
    public interface ITrendService
    {
        Task<TrendDto> AddTrend(TrendDto model);
        Task<TrendDto[]> GetFiveTrendsInSevenDays ();
        Task<Trend> CheckPriceOrderByName(string orderName);             
    }
}
