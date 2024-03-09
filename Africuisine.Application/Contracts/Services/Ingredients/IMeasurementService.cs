using Africuisine.Application.Data.Ingredients;

namespace Africuisine.Application.Contracts.Services.Ingredients
{
    public interface IMeasurementService
    {
        Task<List<MeasurementDTO>> GetMeasurements();
    }
}