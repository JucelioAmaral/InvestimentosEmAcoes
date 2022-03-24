using AutoMapper;
using DesafioToro.Application.DTO;
using DesafioToro.Domain;

namespace DesafioToro.Application.Helpers
{
    public class DesafioToroMapping : Profile
    {

        public DesafioToroMapping()
        {
            //Events
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Target, TargetDto>().ReverseMap();
            CreateMap<Origin, OriginDto>().ReverseMap();

            //Actions
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Trend, TrendDto>().ReverseMap();

            //Users
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserDtoDataBase>().ReverseMap();            

            //Buy
            CreateMap<BuyOrder, BuyOrderDto>().ReverseMap();
        }
    }
}
