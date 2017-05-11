using System.ComponentModel.DataAnnotations;

namespace foodord_web.Models
{
    public class FoodPack
    {
        [Key]
        public int Id { get; set; }
        public virtual Basket Basket { get; set; }
        public virtual Food Food { get; set; }
        public int Count { get; set; }
    }
}