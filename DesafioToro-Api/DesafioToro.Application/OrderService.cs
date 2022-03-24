using AutoMapper;
using DesafioToro.Application.DTO;
using DesafioToro.Domain;
using DesafioToro.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioToro.Application
{
    public class OrderService : IOrderService
    {
        private readonly IGeralPersistence _geralPersist;
        private readonly IOrderPersistence _orderPersistence;
        private readonly IMapper _mapper;

        public OrderService(IMapper mapper, IOrderPersistence orderPersistence, IGeralPersistence geralPersist)
        {
            _mapper = mapper;
            _orderPersistence = orderPersistence;
            _geralPersist = geralPersist;
        }

        public async Task<OrderDto> AddOrder(OrderDto model)
        {
            //Add order
            var order = _mapper.Map<Order>(model);
            order.DateOrder = DateTime.Now;
            _geralPersist.Add<Order>(order);
            if (await _geralPersist.SaveChangesAsync())
            {
                return _mapper.Map<OrderDto>(order);
            }
            return null;
        }
    }
}
