using System.Collections.Generic;
using System.Linq;

namespace foodord_web.Models
{
    public class FoodService
    {
        private FoodOrderingContext entities;
        public FoodOrderingContext Entities { get { return entities; } }

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
            //var foods = entities.Orders
            //    .SelectMany(order => order.OrderedFoodStacks)
            //    .GroupBy(foodStack => foodStack.Food);
            //
            //return foods.ToList();
            return entities.Foods.ToList();
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

        public void PlaceOrder(Order order)
        {
            entities.Orders.Add(order);
            entities.SaveChanges();
        }

        public Basket NewBasket()
        {
            Basket basket = entities.Baskets.Create();
            entities.Baskets.Add(basket);
            return basket;
        }

        public Basket GetBasket(int basketId)
        {
            return entities.Baskets.FirstOrDefault(basket => basket.Id == basketId);
        }

        public void SaveChanges()
        {
            entities.SaveChanges();
        }
    }
}