using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace foodord_web.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool Spicy { get; set; }
        public bool Vegetarian { get; set; }
    }
}