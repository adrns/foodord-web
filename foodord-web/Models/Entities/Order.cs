using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

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
        public virtual ICollection<Food> Foods { get; set; }

        public Order()
        {
            Foods = new HashSet<Food>();
        }
        
        public static Order Create(DbSet<Order> orderSet, OrderForm formData, Basket basket)
        {
            Order order = orderSet.Create();
            order.Name = formData.Name;
            order.Address = formData.ZipCode + " " + formData.City + " " + formData.Address;
            order.Phone = FormatPhone(formData.Phone);
            order.OrderDate = DateTime.Now;
            foreach (Food food in basket.Foods)
            {
                order.Foods.Add(food);
            }

            return order;
        }

        private static string FormatPhone(string phone)
        {
            phone = phone.Replace(" ", "").Replace("-", "");
            if (phone.StartsWith("+"))
            {
                return phone.Substring(3);
            }
            else if (phone.Length >= 10)
            {
                return phone.Substring(2);
            }

            return phone;
        }
    }
}