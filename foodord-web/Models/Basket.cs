using System.Collections.Generic;
using System.Linq;

namespace foodord_web.Models
{
    public class Basket
    {
        const int PRICE_LIMIT = 20000;
        public enum BasketResult {Success, LimitReached, NoSuchFood};
        private FoodService foodService;
        private List<Food> foods;

        public Basket(FoodService foodService)
        {
            this.foodService = foodService;
            foods = new List<Food>();
        }

        public BasketResult Add(int foodId)
        {
            Food food = foodService.GetFood(foodId);

            if (null == food)
            {
                return BasketResult.NoSuchFood;
            }

            if (PRICE_LIMIT < Total() + food.Price)
            {
                return BasketResult.LimitReached;
            }
            else
            {
                foods.Add(food);
                return BasketResult.Success;
            }
        }

        public BasketResult Remove(int foodId)
        {
            Food food = foodService.GetFood(foodId);

            if (null == food)
            {
                return BasketResult.NoSuchFood;
            }

            return foods.Remove(food) ? BasketResult.Success : BasketResult.NoSuchFood;
        }

        public int Total()
        {
            int sum = 0;
            foods.ForEach(food => sum += food.Price);

            return sum;
        }

        public int Count()
        {
            return foods.Count();
        }

        public Dictionary<Food, int> GetFoodsByCount()
        {
            return foods
                .GroupBy(food => food)
                .ToDictionary(group => group.Key, group => group.Count());
        }

        public bool Empty()
        {
            return 0 == foods.Count;
        }

        public bool Contains(Food food)
        {
            return foods.Contains(food);
        }

        public void Clear()
        {
            foods.Clear();
        }

        public object Json()
        {
            List<object> foodList = new List<object>();
            foreach (KeyValuePair<Food, int> pair in GetFoodsByCount())
            {
                Food food = pair.Key;
                int count = pair.Value;
                int cost = count * food.Price;
                foodList.Add(new
                {
                    foodId = food.Id,
                    count = count,
                    cost = cost
                });
            }

            object basketJson = new
            {
                total = Total(),
                count = Count(),
                foods = foodList.ToArray()
            };

            return basketJson;
        }
    }
}