using Africuisine.Domain.Entities;

namespace Africuisine.Domain.Entities.Ingredients
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}