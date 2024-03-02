using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Africuisine.Domain.Entities.User
{
    public class User : IdentityUser<Guid>, IAuditing
    {
        public DateTime Creation { get; set; }
        public DateTime LastUpdate { get; set; }
        public Guid LastUserUpdate { get; set; }
        public int SeqNo { get; set; }
        public string Name { get; set; }
        public Guid CulturalGroupId { get; set; }

    }
}
