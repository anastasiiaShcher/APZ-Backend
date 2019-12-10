using System.Collections.Generic;

namespace Dvor.Common.Entities
{
    public class Dish
    {
        public string DishId { get; set; }

        public string Name { get; set; }

        public string CategoryId { get; set; }

        public Category Category { get; set; }

        public decimal Price { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<DishAllergy> Allergies { get; set; }
    }
}