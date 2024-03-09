using Africuisine.Application.Data.Command.Ingredients;
using Africuisine.Domain.Entities.Ingredients;
using Africuisine.Domain.Repositories.Repository.Ingredients;
using Africuisine.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Africuisine.Domain.Repositories.Repository
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly AfricuisineDbContext DataContext;

        public IngredientRepository(AfricuisineDbContext dataContext)
        {
            DataContext = dataContext;
        }

        public async Task<Ingredient> Add(Ingredient ingredient)
        {
            var entry = DataContext.Ingredients.Add(ingredient);
            await DataContext.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<Ingredient> Delete(Ingredient ingredient)
        {
            var entry = DataContext.Ingredients.Remove(ingredient);
            await DataContext.SaveChangesAsync();
            return entry.Entity;
        }

        public Task<Ingredient> GetIngredientById(string id)
        {
            var ingredient = DataContext.Ingredients.FirstOrDefaultAsync(c => c.Id == id);
            return ingredient;
        }

        public IQueryable<Ingredient> GetIngredients()
        {
           var ingredients = DataContext.Ingredients.AsQueryable();
           return ingredients;
        }

        public async Task<bool> Update(UpdateIngredientCommand ingredient)
        {
            DataContext.Ingredients
            .Where(i => i.Id == ingredient.Id)
            .ExecuteUpdate(i => i.SetProperty(i => i.Name, ingredient.Name)
            .SetProperty(i => i.Description, ingredient.Description));

            return await DataContext.SaveChangesAsync() > 0; 
        }
    }
}