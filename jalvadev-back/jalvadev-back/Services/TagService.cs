using AutoMapper;
using jalvadev_back.DTOs;
using jalvadev_back.Models;
using jalvadev_back.Repositories.Interfaces;
using jalvadev_back.Services.Interfaces;
using jalvadev_back.Utils;

namespace jalvadev_back.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;
        public TagService(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public Result<List<TagDTO>> GetAllTags()
        {
            var result = _tagRepository.GetAllTags();
            if (!result.IsSuccess)
                return Result<List<TagDTO>>.Failure(result.Message);

            List<TagDTO> tags = _mapper.Map<List<Tag>, List<TagDTO>>(result.Value);

            return Result<List<TagDTO>>.Success(tags);
        }

        public Result<TagDTO> GetTagById(int id)
        {
            var result = _tagRepository.GetTagById(id);
            if(!result.IsSuccess)
                return Result<TagDTO>.Failure(result.Message);

            TagDTO tag = _mapper.Map<TagDTO>(result.Value);

            return Result<TagDTO>.Success(tag);
        }
    }
}
