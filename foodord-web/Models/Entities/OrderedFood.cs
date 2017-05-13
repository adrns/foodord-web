using System.ComponentModel.DataAnnotations;

namespace foodord_web.Models
{
    public class OrderedFood
    {
        [Key]
        public int Id { get; set; }
        public Order Order { get; set; }
        public Food Food { get; set; }
    }
}