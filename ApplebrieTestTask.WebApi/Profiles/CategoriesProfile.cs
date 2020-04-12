using AutoMapper;

namespace ApplebrieTestTask.WebApi.Profiles
{
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            CreateMap<Dto.CategoryDto, Entitities.Category>();
            CreateMap<Entitities.Category, Dto.CategoryDto>();
        }
    }
}
