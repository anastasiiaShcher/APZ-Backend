﻿using System.Collections.Generic;

namespace Dvor.Common.Entities
{
    public class User
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public bool IsBanned { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string RoleId { get; set; }

        public Role Role { get; set; }

        public ICollection<Order> Orders { get; set; }

        public bool IsDeleted { get; set; }
    }
}