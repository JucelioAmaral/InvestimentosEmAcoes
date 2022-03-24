using AutoMapper;
using DesafioToro.Application.Contracts;
using DesafioToro.Application.DTO;
using DesafioToro.Domain;
using DesafioToro.Persistence.Contracts;
using System.Threading.Tasks;

namespace DesafioToro.Application
{
    public class UserService : IUserService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly IUserPersistence _userPersistence;
        private readonly ITargetPersistence _targetPersistence;
        private readonly IEventPersistence _eventPersistence;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IGeralPersistence geralPersistence,  IUserPersistence userPersistence, ITargetPersistence targetPersistence, IEventPersistence eventPersistence)
        {            
            _mapper = mapper;
            _geralPersistence = geralPersistence;
            _userPersistence = userPersistence;
            _targetPersistence = targetPersistence;
            _eventPersistence = eventPersistence;
        }

        public async Task<UserDto> AddUser(UserDto model)
        {
            var user = _mapper.Map<User>(model);
            _geralPersistence.Add<User>(user);
            if (await _geralPersistence.SaveChangesAsync())
            {
                return _mapper.Map<UserDto>(user);
            }
            return null;
        }

        public async Task<UserDtoDataBase> UpdateUser(string AccountUser, UserDtoDataBase model)
        {
            var userSelected = await _userPersistence.GetUserByAccount(AccountUser);
            if (userSelected == null) return null;

            model.Id = userSelected.Id;
            _mapper.Map(model, userSelected);
            _geralPersistence.Update<User>(userSelected);
            if (await _geralPersistence.SaveChangesAsync())
            {
                var userReturn = await _userPersistence.GetUserByAccount(AccountUser);
                return _mapper.Map<UserDtoDataBase>(userReturn); ;
            }
            return null;
        }
      
        public async Task<double> SubstractAmount(string AccountUser, double valueSubstract)
        {
            var target = await _targetPersistence.GetTargetIdByAccount(AccountUser);
            if (target == null) return 0;
            var eventUser = await _eventPersistence.GetEvent(target.TargetId);
            if (eventUser == null) return 0;

            eventUser.Amount -= valueSubstract;

            return eventUser.Amount;
        }
    }
}
