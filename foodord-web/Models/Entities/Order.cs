using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace foodord_web.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [StringLength(11)]
        public string Phone { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual ICollection<OrderedFood> OrderedFoods { get; set; }

        public Order()
        {
            OrderedFoods = new List<OrderedFood>();
        }
    }
}