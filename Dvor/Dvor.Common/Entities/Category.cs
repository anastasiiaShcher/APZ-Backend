using System.Collections.Generic;

namespace Dvor.Common.Entities
{
    public class Category
    {
        public string CategoryId { get; set; }

        public string Name { get; set; }

        public ICollection<Dish> Dishes { get; set; }
    }
}