using System;
using System.Collections.Generic;
using System.Linq;

namespace foodord_web.Models
{
    public class FoodService : IFoodService
    {
        private FoodOrderingContext entities;

        public FoodService()
        {
            entities = new FoodOrderingContext();
        }

        public List<Category> GetCategories()
        {
            return entities.Categories.ToList();
        }

        public List<Food> GetTopTenFoods()
        {
            return entities.OrderedFoods
                .GroupBy(orderedFood => orderedFood.Food)
                .OrderByDescending(group => group.Count())
                .Take(10)
                .Select(group => group.Key)
                .ToList();
        }

        public List<Food> GetFoodsByCategory(int category)
        {
            return entities.Foods.Where(food => food.Category.Id == category).ToList();
        }

        public string GetCategoryName(int id)
        {
            Category category = entities.Categories.Find(id);

            return category == null ? "" : category.Name;
        }

        public List<Food> GetFilteredFoodsByCategory(int category, string filter)
        {
            return entities.Foods
                .Where(food => food.Category.Id == category && (food.Name.Contains(filter) || food.Description.Contains(filter)))
                .ToList();
        }

        public Food GetFood(int foodId)
        {
            return entities.Foods.FirstOrDefault(food => food.Id == foodId);
        }

        public void PlaceOrder(string name, string address, string phone, IEnumerable<int> foods)
        {
            Order newOrder = entities.Orders.Create();
            newOrder.Name = name;
            newOrder.Address = address;
            newOrder.Phone = FormatPhone(phone);
            newOrder.OrderDate = DateTime.Now;
            newOrder.OrderedFoods = new List<OrderedFood>();
            foreach (int foodId in foods)
            {
                OrderedFood orderedFood = entities.OrderedFoods.Create();
                orderedFood.Food = GetFood(foodId);
                newOrder.OrderedFoods.Add(orderedFood);
            }
            entities.Orders.Add(newOrder);
            entities.SaveChanges();
        }

        public int GetPrice(List<int> foodList)
        {
            return entities.Foods.Sum(food => foodList.Contains(food.Id) ? food.Price : 0);
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