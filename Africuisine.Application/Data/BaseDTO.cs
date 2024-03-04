using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Africuisine.Application.Data
{
    public class BaseDTO : IAuditingDTO
    {
        public string Id { get; set; }
        public DateTime Created {get; set; }
        public DateTime LastModified {get; set; }
        public int SeqNo {get; set; }
        public string LUserUpdate {get; set; }
    }
}
