using System.Collections.Generic;
using System.Linq;

namespace foodord_web.Models
{
    public class BasketModel
    {
        const int PRICE_LIMIT = 20000;
        public enum BasketResult {Success, LimitReached, NoSuchFood};
        private IFoodService foodService;
        private List<int> foods;
        public int[] Foods { get { return foods.ToArray(); } }

        public BasketModel(IFoodService foodService)
        {
            this.foodService = foodService;
            foods = new List<int>();
        }

        public BasketModel(IFoodService foodService, int[] foods)
        {
            this.foodService = foodService;
            this.foods = new List<int>(foods);
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
                foods.Add(food.Id);

                return BasketResult.Success;
            }
        }

        public BasketResult Remove(int foodId)
        {
            Food food = foodService.GetFood(foodId);

            if (null != food && foods.Remove(food.Id))
            {
                return BasketResult.Success;
            }

            return BasketResult.NoSuchFood;
        }

        public int Total()
        {
            return foodService.GetPrice(foods);
        }

        public int Count()
        {
            return foods.Count;
        }

        public bool Empty()
        {
            return 0 == foods.Count;
        }

        public void Clear()
        {
            foods.Clear();
        }

        public IEnumerable<KeyValuePair<Food, int>> GroupFoodsByAmount()
        {
            return foods.GroupBy(foodId => foodId).Select(group => new KeyValuePair<Food, int>(foodService.GetFood(group.Key), group.Count()));
        }

        public object Json()
        {
            var foodCountPairs = GroupFoodsByAmount();
            var foodList = new List<object>();
            foreach (KeyValuePair<Food, int> pair in foodCountPairs)
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