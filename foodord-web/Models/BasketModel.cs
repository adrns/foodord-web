using System.Collections.Generic;
using System.Linq;

namespace foodord_web.Models
{
    public class BasketModel
    {
        const int PRICE_LIMIT = 20000;
        public enum BasketResult {Success, LimitReached, NoSuchFood};
        private FoodService foodService;
        private Basket basket;
        public int Id { get { return basket.Id; } }
        public ICollection<FoodPack> FoodPacks { get { return basket.FoodPacks; } }

        public BasketModel(FoodService foodService)
        {
            this.foodService = foodService;
            basket = foodService.NewBasket();
        }

        public BasketModel(FoodService foodService, int basketId)
        {
            this.foodService = foodService;
            basket = foodService.GetBasket(basketId);
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
                FoodPack foodPack = basket.FoodPacks.FirstOrDefault(pack => pack.Food.Id == food.Id);
                if (null == foodPack)
                {
                    basket.FoodPacks.Add(new FoodPack { Food = food, Count = 1 });
                }
                else
                {
                    foodPack.Count++;
                }

                return BasketResult.Success;
            }
        }

        public BasketResult Remove(int foodId)
        {
            Food food = foodService.GetFood(foodId);

            if (null != food)
            {
                FoodPack foodPack = basket.FoodPacks.FirstOrDefault(pack => pack.Food.Id == food.Id);
                if (foodPack.Count == 1)
                {
                    basket.FoodPacks.Remove(foodPack);
                }
                else
                {
                    foodPack.Count--;
                }

                return BasketResult.Success;
            }

            return BasketResult.NoSuchFood;
        }

        public int Total()
        {
            return basket.FoodPacks.Select(pack => pack.Food.Price * pack.Count).Sum();
        }

        public int Count()
        {
            return basket.FoodPacks.Select(pack => pack.Count).Sum();
        }

        public bool Empty()
        {
            return 0 == basket.FoodPacks.Count;
        }

        public void Clear()
        {
            basket.FoodPacks.Clear();
        }

        public object Json()
        {
            List<object> foodList = new List<object>();
            foreach (FoodPack pack in basket.FoodPacks)
            {
                Food food = pack.Food;
                int count = pack.Count;
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