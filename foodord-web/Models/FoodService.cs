using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace foodord_web.Models
{
    public class FoodService
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
            var foods = entities.Orders
                .SelectMany(order => order.Foods)
                .GroupBy(food => food.Id)
                .OrderByDescending(group => group.Count())
                .Take(10)
                .Select(group => group.FirstOrDefault());

            return foods.ToList();
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
    }
}