using Africuisine.Domain.Entities.User;

namespace Africuisine.Application.Contracts.Repositories.Users
{
    public interface ICulturalGroupRepository
    {
        Task<CulturalGroup> GetCulturalGroupById(string id);
        Task<List<CulturalGroup>> GetCulturalGroups(string id);
    }
}