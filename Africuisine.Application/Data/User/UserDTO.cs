using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Africuisine.Application.Data.User
{
    public class UserDTO : BaseDTO
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public bool EmailConfirmed { get; set; }
        public string CulturalGroupName { get; set; }
    }
}
