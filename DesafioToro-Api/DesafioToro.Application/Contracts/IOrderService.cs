using DesafioToro.Application.DTO;
using System.Threading.Tasks;

namespace DesafioToro
{
    public interface IOrderService
    {
        Task<OrderDto> AddOrder(OrderDto model);      
    }
}