using DesafioToro.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioToro.Application.Contracts
{
    public interface ITargetService
    {
        Task<Target> GetTargetByAccount(string account);
    }
}
