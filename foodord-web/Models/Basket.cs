using System.Collections.Generic;
using System.Linq;

namespace foodord_web.Models
{
    public class Basket
    {
        const int PRICE_LIMIT = 20000;
        public enum BasketResult {Success, LimitReached, NoSuchFood};
        private FoodService foodService;
        private List<Food> items;

        public Basket(FoodService foodService)
        {
            this.foodService = foodService;
            items = new List<Food>();
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
                items.Add(food);
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

            return items.Remove(food) ? BasketResult.Success : BasketResult.NoSuchFood;
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