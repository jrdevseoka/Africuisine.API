using Africuisine.Application.Data.Command.Ingredients;
using Africuisine.Domain.Entities.Ingredients;

namespace Africuisine.Domain.Repositories.Repository.Ingredients
{
    public interface IIngredientRepository
    {
        Task<Ingredient> Add(Ingredient ingredient);
        Task<Ingredient> Delete(Ingredient ingredient);
        IQueryable<Ingredient> GetIngredients();
        Task<Ingredient> GetIngredientById(string id);
        Task<bool> Update(UpdateIngredientCommand ingredient);
    }
}