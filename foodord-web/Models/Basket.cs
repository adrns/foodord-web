using System.Collections.Generic;
using System.Linq;

namespace foodord_web.Models
{
    public class Basket
    {
        private FoodService foodService;
        private List<Food> items;

        public Basket(FoodService foodService)
        {
            this.foodService = foodService;
            items = new List<Food>();
        }

        public void Add(int foodId)
        {
            Food food = foodService.GetFood(foodId);

            if (null != food)
            {
                items.Add(food);
            }
        }

        public void Remove(int foodId)
        {
            Food food = foodService.GetFood(foodId);

            if (null != food)
            {
                items.Remove(food);
            }
        }

        public int Total()
        {
            int sum = 0;
            items.ForEach(food => sum += food.Price);

            return sum;
        }

        public int Count()
        {
            return items.Count();
        }
    }
}