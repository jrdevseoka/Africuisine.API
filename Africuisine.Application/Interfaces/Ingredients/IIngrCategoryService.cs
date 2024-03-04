using Africuisine.Application.Data.Ingredients;

namespace Africuisine.Application.Interfaces.Ingredients
{
    public interface IIngrCategoryService
    {
        Task<List<IngredientCategoryDTO>> GetIngredientCategories();
    }
}