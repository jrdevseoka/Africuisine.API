﻿using Africuisine.Domain.Entities.Users;

namespace Africuisine.Application.Contracts.Repositories.Users
{
    public interface IProfileRepository
    {
        IQueryable<Profile> Profiles { get; set; }
        Task<Profile> Add(Profile profile);
        Task<Profile> Update(Profile profile);
        Task<Profile> GetProfileByUserId(string id);
    }
}
