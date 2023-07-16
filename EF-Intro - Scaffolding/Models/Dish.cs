using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class Dish
    {
        public Dish()
        {
            Ingredients = new HashSet<Ingredient>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public int? Stars { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
