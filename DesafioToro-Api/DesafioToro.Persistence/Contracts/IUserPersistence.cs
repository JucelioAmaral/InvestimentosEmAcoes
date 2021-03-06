using DesafioToro.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioToro.Persistence.Contracts
{
    public interface IUserPersistence
    {
        Task<User> GetUserByAccount(string account);
    }
}
