using System;
using System.Collections.Generic;

namespace Scaffolding.Models
{
    public partial class Ingredient
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UnitOfMeasure { get; set; }
        public decimal Amount { get; set; }
        public int DishId { get; set; }

        public virtual Dish Dish { get; set; }
    }
}
