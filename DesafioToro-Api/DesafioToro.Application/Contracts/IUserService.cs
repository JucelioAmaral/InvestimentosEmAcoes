using DesafioToro.Application.DTO;
using DesafioToro.Domain;
using System.Threading.Tasks;

namespace DesafioToro.Application.Contracts
{
    public interface IUserService
    {
        Task<UserDto> AddUser(UserDto model);
        Task<UserDtoDataBase> UpdateUser(string AccountUser, UserDtoDataBase updateUser);
        Task<double> SubstractAmount(string AccountUser, double valueSubstract);
    }
}
