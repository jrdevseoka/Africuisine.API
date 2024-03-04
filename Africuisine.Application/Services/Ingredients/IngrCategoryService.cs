using Africuisine.Application.Data.Ingredients;
using Africuisine.Application.Interfaces.Ingredients;
using Africuisine.Domain.Repositories.Repository.Ingredients;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Africuisine.Application.Services.Ingredients
{
    public class IngrCategoryService : IIngrCategoryService
    {
        private readonly IIngrCategoryRepository IngrCategoryRepository;
        private readonly IMapper Mapper;

        public IngrCategoryService(IIngrCategoryRepository ingrCategoryRepository, IMapper mapper)
        {
            IngrCategoryRepository = ingrCategoryRepository;
            Mapper = mapper;
        }

        public async Task<List<IngredientCategoryDTO>> GetIngredientCategories()
        {
            var categories = await IngrCategoryRepository.GetIngredientCategories()
            .ProjectTo<IngredientCategoryDTO>(Mapper.ConfigurationProvider).ToListAsync();
            return categories;
        }
    }
}