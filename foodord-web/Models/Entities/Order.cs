using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace foodord_web.Models
{
    public class Order
    {
        [Key, ForeignKey("Basket")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [StringLength(11)]
        public string Phone { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual Basket Basket { get; set; }
        
        public static Order Create(FoodOrderingContext context, OrderForm formData, BasketModel basket)
        {
            Order order = context.Orders.Create();
            //order.Name = formData.Name;
            //order.Address = formData.ZipCode + " " + formData.City + " " + formData.Address;
            //order.Phone = FormatPhone(formData.Phone);
            //order.OrderDate = DateTime.Now;
            //foreach (Food food in basket.Foods)
            //{
            //    order.Foods.Add(context.Foods.FirstOrDefault(food2 => food2.Id == food.Id));
            //}

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