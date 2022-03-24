using DesafioToro.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioToro.Application.Contracts
{
    public interface IEventService
    {
        Task<EventDto> AddEvent(EventDto model);
        Task<EventDto> UpdateEvent(Event eventUpdate, double valueToSubstract);
        Task<bool> CheckCPF(string cpf);
        Task<Event> GetEventById(int idTarget);
    }
}
