using System.Collections.Generic;

namespace foodord_web.Models
{
    public interface IFoodService
    {
        List<Category> GetCategories();
        string GetCategoryName(int id);
        List<Food> GetFilteredFoodsByCategory(int category, string filter);
        Food GetFood(int foodId);
        List<Food> GetFoodsByCategory(int category);
        int GetPrice(List<int> foodList);
        List<Food> GetTopTenFoods();
        void PlaceOrder(string name, string address, string phone, IEnumerable<int> foods);
    }
}