using AutoMapper;
using DesafioToro.Application.Contracts;
using DesafioToro.Domain;
using DesafioToro.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioToro.Application
{

    public class EventService : IEventService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly IOriginPersistence _originPersistence;
        private readonly ITargetPersistence _targetPersistence;
        private readonly IEventPersistence _eventPersistence;
        private readonly IMapper _mapper;

        public EventService(IGeralPersistence geralPersist, IOriginPersistence originPersist, ITargetPersistence targetPersistence, IEventPersistence eventPersistence, IMapper mapper)
        {
            _geralPersistence = geralPersist;
            _originPersistence = originPersist;
            _targetPersistence = targetPersistence;
            _eventPersistence = eventPersistence;
            _mapper = mapper;
        }

        public async Task<EventDto> AddEvent(EventDto model)
        {
            //Fetch amount current            
            var currentAccount = await _targetPersistence.GetAccount(model.Target.Account);
            if (currentAccount == null)
            {
                //Add event
                var eventFirstDeposit = _mapper.Map<Event>(model);
                _geralPersistence.Add<Event>(eventFirstDeposit);
                if (await _geralPersistence.SaveChangesAsync())
                {
                    return _mapper.Map<EventDto>(eventFirstDeposit);
                }
                return null;
            }
            else if (model.EventName == "DEPOSIT")            
            {
                //Fetch amount current                            
                var eventCurrent = await _eventPersistence.GetEvent(currentAccount.TargetId);
                //Sum new amount
                model.Amount += eventCurrent.Amount;
                //Add event
                var eventDeposit = _mapper.Map<Event>(model);
                _geralPersistence.Add<Event>(eventDeposit);
                if (await _geralPersistence.SaveChangesAsync())
                {
                    return _mapper.Map<EventDto>(eventDeposit);
                }
                return null;
            }
            else if (model.EventName == "TRANSFER")
            {
                //Fetch amount current                            
                var eventCurrent = await _eventPersistence.GetEvent(currentAccount.TargetId);
                //Sum new amount
                model.Amount += eventCurrent.Amount;

                //Add event
                var eventTransfer = _mapper.Map<Event>(model);
                _geralPersistence.Add<Event>(eventTransfer);
                if (await _geralPersistence.SaveChangesAsync())
                {
                    return _mapper.Map<EventDto>(eventTransfer);
                }
                return null;
            }
            return null;
        }

        public async Task<bool> CheckCPF(string cpf)
        {
            var cpfReturn = await _originPersistence.GetCPFOrigin(cpf);
            if (cpfReturn != null)
            {
                return true;
            }
            return false;
        }

        public async Task<Event> GetEventById(int idTarget)
        {
            var eventOne = await _eventPersistence.GetEvent(idTarget);
            if (eventOne != null)
            {
                return eventOne;
            }
            return null;
        }

        public async Task<EventDto> UpdateEvent(Event eventUpdate, double valueToSubstract)
        {
            var currrentEvent = await _eventPersistence.GetEvent(eventUpdate.Id);
            if (currrentEvent == null) return null;

            currrentEvent.Amount -= valueToSubstract;
            _geralPersistence.Update<Event>(currrentEvent);
            await _geralPersistence.SaveChangesAsync();
            return null;
        }
    }
}
