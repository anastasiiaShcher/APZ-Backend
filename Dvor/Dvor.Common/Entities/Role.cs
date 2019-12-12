using System.Collections.Generic;

namespace Dvor.Common.Entities
{
    public class Role
    {
        public string RoleId { get; set; }

        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}