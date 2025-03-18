using Assignment_NET104.DTO;
using Assignment_NET104.Models;

namespace Assignment_NET104.Services.Interfaces
{
    public interface IFoodItem
    {
        void CreateNew(FoodItem item);
        void Edit(FoodItem item);
        List<FoodItemDTO> GetList();
        FoodItemDTO GetOne(int foodItemId);
        void RemoveItem(int foodItemId);
    }
}
