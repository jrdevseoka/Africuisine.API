using Africuisine.Application.Data.Command.Ingredients;
using Africuisine.Application.Data.Ingredients;
using Africuisine.Domain.Entities.Ingredients;

namespace Africuisine.Application.Contracts.Services.Ingredients
{
    public interface IIngredientService
    {
        Task<IngredientDTO> Add(IngredientCommand command);
        Task<IngredientDTO> Delete(Ingredient ingredient);
        Task<List<IngredientDTO>> GetIngredients();
        Task<IngredientDTO> GetIngredientById(string id);
        Task<bool> Update(UpdateIngredientCommand command);

    }
}