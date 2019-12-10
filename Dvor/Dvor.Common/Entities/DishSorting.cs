using Dvor.Common.Enums;
using System.Collections.Generic;

namespace Dvor.Common.Entities
{
    public class DishSorting
    {
        public SortingMethod SortingMethod { get; set; }

        public string Search { get; set; }

        public decimal? PriceFrom { get; set; }

        public decimal? PriceTo { get; set; }

        public IEnumerable<string> Allergies { get; set; }
    }
}