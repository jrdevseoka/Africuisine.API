using System;

namespace Africuisine.Domain.Entities
{
    public interface IAuditing
    {
        public DateTime Creation { get; set; }
        public DateTime LastUpdate { get; set; }
        public Guid LastUserUpdate { get; set; }
        public int SeqNo { get; set; }
    }
}
