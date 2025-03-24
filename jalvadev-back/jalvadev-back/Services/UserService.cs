using AutoMapper;
using jalvadev_back.DTOs;
using jalvadev_back.Repositories.Interfaces;
using jalvadev_back.Services.Interfaces;
using jalvadev_back.Utils;

namespace jalvadev_back.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Result<UserDTO> GetUserById(int id)
        {
            var userResult = _userRepository.GetUserById(id);
            if (!userResult.IsSuccess)
                return Result<UserDTO>.Failure(userResult.Message);

            UserDTO userDTO = _mapper.Map<UserDTO>(userResult.Value);

            return Result<UserDTO>.Success(userDTO);
        }
    }
}
