using AutoMapper;
using jalvadev_back.DTOs;
using jalvadev_back.Models;
using jalvadev_back.Repositories.Interfaces;
using jalvadev_back.Services.Interfaces;
using jalvadev_back.Utils;

namespace jalvadev_back.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public PostService(IPostRepository postRepository, IUserRepository userRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public Result<PostDetailDTO> GetPostDetail(int id)
        {
            var postResult = _postRepository.GetPostById(id);
            if(!postResult.IsSuccess)
                return Result<PostDetailDTO>.Failure(postResult.Message);

            Post post = postResult.Value;

            var userResult = _userRepository.GetUserById(post.UserId);
            if (!userResult.IsSuccess)
                return Result<PostDetailDTO>.Failure(userResult.Message);

            User user = userResult.Value;

            PostDetailDTO postDetail = _mapper.Map<PostDetailDTO>(post);
            UserMinimalDTO userMin = _mapper.Map<UserMinimalDTO>(user);

            postDetail.User = userMin;

            return Result<PostDetailDTO>.Success(postDetail);
        }
    }
}
