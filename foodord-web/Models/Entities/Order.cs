using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace foodord_web.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        [StringLength(11)]
        public string Phone { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual ICollection<Food> Foods { get; set; }

        public Order()
        {
            Foods = new HashSet<Food>();
        }
    }
}