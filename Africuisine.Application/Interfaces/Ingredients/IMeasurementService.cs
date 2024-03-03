using Africuisine.Application.Data.Ingredients;

namespace Africuisine.Application.Interfaces.Ingredients
{
    public interface IMeasurementService
    {
        Task<List<MeasurementDTO>> GetMeasurements();
    }
}