using System;
namespace Africuisine.Domain.Entities
{
    public class BaseEntity : IDataEntity
    {
        public Guid Id { get; set; }
        public DateTime Creation { get; set; }
        public DateTime LastUpdate { get; set; }
        public Guid LastUserUpdate { get; set; }
        public int SeqNo { get; set; }
    }
}
