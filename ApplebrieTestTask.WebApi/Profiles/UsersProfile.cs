using AutoMapper;

namespace ApplebrieTestTask.WebApi.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<Entitities.User, Dto.UserDto>();
            CreateMap<Dto.UserDto,Entitities.User>();


        }
    }
}
