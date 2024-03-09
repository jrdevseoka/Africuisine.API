using Africuisine.Application.Data.Command.Users;
using Africuisine.Application.Data.User;

namespace Africuisine.Application.Contracts.Services.Users
{
    public interface IProfileService
    {
        Task<ProfileDTO> Add(ProfileCommand request);
        Task<ProfileDTO> Update(ProfileCommand profile);
        Task<ProfileDTO> GetProfileByUserId(string id);
        Task<ProfileDTO> GetProfileById(string id);
    }
}
