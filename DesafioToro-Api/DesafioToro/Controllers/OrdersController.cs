using AutoMapper;
using DesafioToro.Application;
using DesafioToro.Application.Contracts;
using DesafioToro.Application.DTO;
using DesafioToro.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioToro.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        private readonly ITrendService _trendService;
        private readonly ITargetService _targetService;
        private readonly IEventService _eventService;
        private readonly IUserService _userService;

        public OrdersController(IMapper mapper, IOrderService orderService, ITrendService trendService, ITargetService targetService, IEventService eventService, IUserService userService)
        {
            _mapper = mapper;
            _orderService = orderService;
            _trendService = trendService;
            _targetService = targetService;
            _eventService = eventService;
            _userService = userService;
        }

        [HttpPost("insertOrder")]
        public async Task<IActionResult> InsertOrder(OrderDto model)
        {
            try
            {
                var order = await _orderService.AddOrder(model);
                if (order == null) return NoContent();

                return Ok(order);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Post: Erro ao inserir o ativo. Erro: {ex.Message}");
            }
        }

        [HttpPost("buyOrder")]
        public async Task<BuyOrderDto> BuyOrder(BuyOrder model)
        {

            try
            {
                var trend = await _trendService.CheckPriceOrderByName(model.OrderName);
                if(trend == null) return null;
                var target = await _targetService.GetTargetByAccount(model.UserAccount);
                if (target == null) return null;

                double AmountTotal = model.OrderAmount * trend.CurrentPrice;

                var eventOne = await _eventService.GetEventById(target.TargetId);
                if (eventOne == null) return null;

                if (trend == null)
                {
                    var returnBuyOrder = new BuyOrderDto
                    {
                        UserAccount = model.UserAccount,
                        OrderName = model.OrderName,
                        OrderAmount = model.OrderAmount,
                        Amount = eventOne.Amount,
                        Message = "Ativo inválido."
                    };
                    return returnBuyOrder;
                }

                if(AmountTotal <= eventOne.Amount)
                {
                    var user = new UserDtoDataBase
                    {
                        Account = target.Account,
                        TrendId = trend.TrendId,
                        AmountOrder = model.OrderAmount
                    };

                    //Update table User
                    var userUpdated = await _userService.UpdateUser(target.Account, user);
                    if (userUpdated == null)
                    {
                        var returnUserUpdated = new BuyOrderDto
                        {
                            UserAccount = model.UserAccount,
                            OrderName = model.OrderName,
                            OrderAmount = model.OrderAmount,
                            Amount = eventOne.Amount,
                            Message = "Usuário não cadastrado."
                        };
                        return returnUserUpdated;
                    }

                    //Update table Order
                    var newOrder = new OrderDto
                    {
                        symbol = model.OrderName,
                        amount = model.OrderAmount
                    };
                    var order = await _orderService.AddOrder(newOrder);

                    //Substract Amount of User/Account
                    double amoutUser = await _userService.SubstractAmount(target.Account, AmountTotal);

                    //Update table eventt
                    await _eventService.UpdateEvent(eventOne, AmountTotal);

                    var returnBuyOrder = new BuyOrderDto
                    {
                        UserAccount = userUpdated.Account,
                        OrderName = model.OrderName,
                        OrderAmount = userUpdated.AmountOrder,
                        Amount = amoutUser,
                        Message = "Ativos comprados com sucesso."
                    };
                    return returnBuyOrder;
                }
                else
                {
                    var returnBuyOrder = new BuyOrderDto
                    {
                        UserAccount = model.UserAccount,
                        OrderName = model.OrderName,
                        OrderAmount = model.OrderAmount,
                        Amount = eventOne.Amount,
                        Message = "Saldo insuficiente."
                    };
                    return returnBuyOrder;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
