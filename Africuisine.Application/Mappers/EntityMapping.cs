using Africuisine.Application.Data;
using Africuisine.Application.Data.Ingredients;
using Africuisine.Application.Data.User;
using Africuisine.Domain.Entities;
using Africuisine.Domain.Entities.Ingredients;
using Africuisine.Domain.Entities.User;
using AutoMapper;

namespace Africuisine.Application.Mappers
{
    public class EntityMapping : Profile
    {
        public EntityMapping()
        {
            MappingBaseEntityToBaseDTO();
            MappingUserToUserDTO();
            MappingRoleToRoleDTO();
            MappingCulturalGroupToCulturalGroupDTO();
            MappingIngredientCategoryToIngredientCategoryDTO();
            MappingMeasurementToMeasurementDTO();
        }

        public void MappingBaseEntityToBaseDTO()
        {
            CreateMap<BaseEntity, BaseDTO>()
                .ForMember(dst => dst.Created, src => src.MapFrom(dst => dst.Creation))
                .ForMember(dst => dst.LastModified, src => src.MapFrom(dst => dst.LastUpdate));
        }

        public void MappingUserToUserDTO()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dst => dst.Created, src => src.MapFrom(dst => dst.Creation))
                .ForMember(dst => dst.FullName, src => src.MapFrom(dst => dst.Id))
                .ForMember(dst => dst.LastModified, src => src.MapFrom(dst => dst.LastUpdate))
                .ReverseMap();
        }

        public void MappingRoleToRoleDTO()
        {
            CreateMap<Role, RoleDTO>()
                .ForMember(dst => dst.Created, src => src.MapFrom(dst => dst.Creation))
                .ForMember(dst => dst.Name, src => src.MapFrom(dst => dst.Name))
                .ForMember(dst => dst.LastModified, src => src.MapFrom(dst => dst.LastUpdate))
                .ReverseMap();
        }

        public void MappingCulturalGroupToCulturalGroupDTO()
        {
            CreateMap<CulturalGroup, CulturalGroupDTO>()
                .IncludeBase<BaseEntity, BaseDTO>()
                .ForMember(dst => dst.Created, src => src.MapFrom(dst => dst.Creation))
                .ForMember(dst => dst.LastModified, src => src.MapFrom(dst => dst.LastUpdate));
        }
        public void MappingIngredientCategoryToIngredientCategoryDTO()
        {
            CreateMap<IngredientCategory, IngredientCategoryDTO>()
                .IncludeBase<BaseEntity, BaseDTO>();
        }
        public void MappingMeasurementToMeasurementDTO()
        {
            CreateMap<Measurement, MeasurementDTO>()
                .IncludeBase<BaseEntity, BaseDTO>();
        }
    }
}
