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
    public class TargetService : ITargetService
    {
        private readonly ITargetPersistence _targetPersist;
        private readonly IMapper _mapper;

        public TargetService(IMapper mapper, ITargetPersistence targetPersist)
        {
            _mapper = mapper;
            _targetPersist = targetPersist;
        }

        public async Task<Target> GetTargetByAccount(string account)
        {
            var trend = await _targetPersist.GetAccount(account);
            if (trend != null)
            {
                return _mapper.Map<Target>(trend);
            }
            return null;
        }
    }
}
