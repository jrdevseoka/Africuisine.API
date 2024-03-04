
using Africuisine.Application.Data.User;
using Africuisine.Domain.Entities.Users;
using Africuisine.Domain.Repositories.Repository;
using Africuisine.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Africuisine.Infrastructure.Persistence.Repositories.Users
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly UserDbContext DataContext;
        public IQueryable<Profile> Profiles { get; set; }

        public ProfileRepository(UserDbContext dataContext)
        {
            DataContext = dataContext;
            Profiles = DataContext.Profiles;
        }

        public async Task<Profile> Add(Profile profile)
        {
            var entry = DataContext.Profiles.Add(profile);
            await DataContext.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<Profile> GetProfileByUserId(string id)
        {
            var profile = await DataContext.Profiles.FirstOrDefaultAsync(c => c.LUser == id);
            return profile;
        }

        public async Task<Profile> Update(Profile profile)
        {
            await DataContext.Profiles.Where(p => p.LUser == profile.LUser && p.Id == profile.LUser)
                 .ExecuteUpdateAsync(c =>  
                 c.SetProperty(p => p.Bio, profile.Bio)
                 .SetProperty(p => p.Uri, profile.Uri));
            await DataContext.SaveChangesAsync();
            return profile;
        }
    }
}
