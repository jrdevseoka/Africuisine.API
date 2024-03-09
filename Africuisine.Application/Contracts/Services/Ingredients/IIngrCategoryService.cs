using Africuisine.Application.Data.Ingredients;

namespace Africuisine.Application.Contracts.Services.Ingredients
{
    public interface IIngrCategoryService
    {
        Task<List<IngredientCategoryDTO>> GetIngredientCategories();
    }
}