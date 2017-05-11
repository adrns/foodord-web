using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace foodord_web.Models
{
    public class Basket
    {
        [Key]
        public int Id { get; set; }
        public virtual Order Order { get; set; }
        public virtual ICollection<FoodPack> FoodPacks { get; set; }

        public Basket()
        {
            FoodPacks = new List<FoodPack>();
        }
    }
}