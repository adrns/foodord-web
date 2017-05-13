using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace foodord_web.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }
        public virtual Category Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool Spicy { get; set; }
        public bool Vegetarian { get; set; }
        public virtual ICollection<OrderedFood> OrderedFoods { get; set; }

        public Food()
        {
            OrderedFoods = new List<OrderedFood>();
        }
    }
}