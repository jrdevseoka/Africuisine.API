using System;
namespace Africuisine.Domain.Entities
{
    public class BaseEntity : IDataEntity
    {
        public string Id { get; set; }
        public DateTime Creation { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LUserUpdate { get; set; }
        public int SeqNo { get; set; }
    }
}
