using Africuisine.Application.Data.Command.Users;
using Africuisine.Domain.Entities.User;
using AutoMapper;


namespace Africuisine.Application.Mappers
{
    public class CommandMapping : Profile
    {
        public CommandMapping()
        {
            MapUserCommandToUser();
            MapProfileCommadToProfile();
        }
        public void MapUserCommandToUser()
        {
            CreateMap<UserCommand, User>()
                .ForMember(dst => dst.Email, opts => opts.MapFrom(src => src.UserName))
                .ForMember(dst => dst.UserName, opts => opts.MapFrom(src => src.UserName))
                .ForMember(dst => dst.Name , opts => opts.MapFrom(src => src.FullName))
                .ForMember(dst => dst.LCulturalGroup, opts => opts.MapFrom(src => src.LCGroup))
                .AfterMap((src, dst) =>
                {
                    dst.Id = Guid.NewGuid().ToString();
                });
        }
        public  void MapProfileCommadToProfile()
        {
            CreateMap<ProfileCommand, Domain.Entities.Users.Profile>()
            .ForMember(dst => dst.LUser, opts => opts.MapFrom(src => src.UserId));
        }
    }
}
