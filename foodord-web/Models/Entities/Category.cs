using System.ComponentModel.DataAnnotations;

namespace foodord_web.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}