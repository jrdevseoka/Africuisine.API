using Africuisine.Application.Config;
using Africuisine.Application.Contracts.Services.Ingredients;
using Africuisine.Application.Data.Command.Ingredients;
using Africuisine.Application.Data.Ingredients;
using Africuisine.Application.Data.Res;
using Africuisine.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Africuisine.API.Controllers.Ingredients
{
    public class IngredientsController : APIBaseController
    {
        private readonly IIngredientService IngredientService;

        public IngredientsController(IIngredientService ingredientService)
        {
            IngredientService = ingredientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetIngredients()
        {
            var ingredients = await IngredientService.GetIngredients();
            return Ok(new ItemsResponse<IngredientDTO> { Items = ingredients, Succeeded = ingredients is not null });
        }
        [HttpPost]
        public async Task<IActionResult> InsertIngredient(IngredientCommand command)
        {
            var ingredient = await IngredientService.Add(command);
            return Ok(new Response { Message = "You have successfully added your ingredient", Succeeded = !string.IsNullOrEmpty(ingredient.Id) });
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteIngredient([FromQuery] string id)
        {
            var ingredient = await IngredientService.GetIngredientById(id) ??
            throw new NotFoundException($"Ingredient with {id} does not exist.");
            return Ok(new ItemResponse<IngredientDTO>
            {
                Message = "You have successfully added your ingredient",
                Succeeded = !string.IsNullOrEmpty(ingredient.Id),
                Item = ingredient
            });
        }
        [HttpPut]
        public async Task<IActionResult> UpdateIngredient([FromQuery]UpdateIngredientCommand command)
        {
           var succeeded = await IngredientService.Update(command);
            return succeeded ? Ok(new Response { Message = "You have successfully updated ingredient", Succeeded = succeeded }) :
                throw new BadRequestException($"An error occured while attempting to update an ingredient with {command.Id}");
        }
    }
}