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
            return entities.Foods.ToList(); //TODO do a real query
        }

        public List<Food> GetFoodsByCategory(int category)
        {
            return entities.Foods.Where(food => food.Category.Id == category).ToList();
        }

        public String GetCategoryName(int id)
        {
            Category category = entities.Categories.Find(id);

            return category == null ? "" : category.Name;
        }
    }
}