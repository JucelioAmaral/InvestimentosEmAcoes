using AutoMapper;
using DesafioToro.Application.Contracts;
using DesafioToro.Application.DTO;
using DesafioToro.Domain;
using DesafioToro.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioToro.Application
{
    public class TrendService : ITrendService
    {
        private readonly IGeralPersistence _geralPersist;
        private readonly ITrendPersistence _trendPersistence;
        private readonly IOrderPersistence _orderPersistence;
        private readonly IMapper _mapper;

        public TrendService(IMapper mapper, ITrendPersistence trendPersistence, IGeralPersistence geralPersist, IOrderPersistence orderPersistence)
        {
            _mapper = mapper;
            _trendPersistence = trendPersistence;
            _orderPersistence = orderPersistence;
            _geralPersist = geralPersist;
        }

        public async Task<TrendDto> AddTrend(TrendDto model)
        {
            //Add trend
            var trend = _mapper.Map<Trend>(model);
            _geralPersist.Add<Trend>(trend);
            if (await _geralPersist.SaveChangesAsync())
            {
                return _mapper.Map<TrendDto>(trend);
            }
            return null;
        }

        public async Task<TrendDto[]> GetFiveTrendsInSevenDays()
        {
            TrendDto trendDto = null;
            List<TrendDto> listTrends = null;

            var trends = await _trendPersistence.GetTrends();
            var orders = await _orderPersistence.GetTopFiveOrdersInSevensDays();

            listTrends = new List<TrendDto>();

            foreach (var o in orders)
            {
                foreach(var t in trends)
                {
                    if(o.Symbol == t.Symbol)
                    {
                        trendDto = new TrendDto
                        {
                            symbol = t.Symbol,
                            currentPrice = t.CurrentPrice
                        };
                        listTrends.Add(trendDto);
                        break;
                    }
                }
            }

            return _mapper.Map<TrendDto[]>(listTrends);
        }

        public async Task<Trend> CheckPriceOrderByName(string orderName)
        {
            var trend = await _trendPersistence.GetTrendByName(orderName);
            if (trend != null)
            {
                return _mapper.Map<Trend>(trend);
            }
            return null;
        }
    }
}
