using DesafioToro.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioToro.Persistence.Contracts
{
    public interface ITargetPersistence
    {
        Task<Target> GetAccount(string account);
        Task<Target> GetTargetIdByAccount(string account);        
    }
}
