using Africuisine.Application.Contracts.Services.Ingredients;
using Africuisine.Application.Data.Command.Ingredients;
using Africuisine.Application.Data.Ingredients;
using Africuisine.Domain.Entities.Ingredients;
using Africuisine.Domain.Repositories.Repository.Ingredients;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Africuisine.Application.Services.Ingredients
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository IngredientRepository;
        private readonly IMapper Mapper;

        public IngredientService(IIngredientRepository ingredientRepository, IMapper mapper)
        {
            IngredientRepository = ingredientRepository;
            Mapper = mapper;
        }

        public async Task<IngredientDTO> Add(IngredientCommand command)
        {

            var ingredient = Mapper.Map<Ingredient>(command);
            ingredient = await IngredientRepository.Add(ingredient);
            return Mapper.Map<IngredientDTO>(ingredient);
        }

        public async Task<IngredientDTO> Delete(Ingredient ingredient)
        {
            ingredient = await IngredientRepository.Delete(ingredient);
            return Mapper.Map<IngredientDTO>(ingredient);
        }

        public async Task<IngredientDTO> GetIngredientById(string id)
        {
            var ingredient = await IngredientRepository.GetIngredientById(id);
            return Mapper.Map<IngredientDTO>(ingredient);
        }

        public async Task<List<IngredientDTO>> GetIngredients()
        {
            var ingredients = await IngredientRepository.GetIngredients()
            .ProjectTo<IngredientDTO>(Mapper.ConfigurationProvider).ToListAsync();
            return ingredients;

        }

        public async Task<bool> Update(UpdateIngredientCommand ingredient)
        {
            bool succeeded = await IngredientRepository.Update(ingredient);
            return succeeded;
        }
    }
}