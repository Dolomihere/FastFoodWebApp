using Assignment_NET104.DataContext;
using Assignment_NET104.DTO;
using Assignment_NET104.Models;
using Assignment_NET104.Services.Interfaces;

namespace Assignment_NET104.Services
{
    public class FoodItemsvc : IFoodItem
    {
        protected WebContext _context;
        public FoodItemsvc(WebContext context)
        {
            _context = context;
        }

        public void CreateNew(FoodItem item)
        {
            if (item != null)
            {
                _context.FoodItems.Add(item);
                _context.SaveChanges();
            }
        }

        public void Edit(FoodItem item)
        {
            if (item != null)
            {
                var food = _context.FoodItems.Find(item.FoodItemId);

                if (food != null)
                {
                    food.Name = item.Name;
                    food.ImagePath = item.ImagePath;
                    food.Category = item.Category;
                    food.ImageFile = item.ImageFile;
                    food.Price = item.Price;
                    food.Status = item.Status;

                    _context.SaveChanges();
                }
            }
        }

        public List<FoodItemDTO> GetList()
        {
            var list = _context.FoodItems.ToList();

            if (list != null)
            {
                List<FoodItemDTO> foods = new List<FoodItemDTO>();

                foreach (var item in list)
                {
                    foods.Add(new FoodItemDTO
                    {
                        FoodItemId = item.FoodItemId,
                        Name = item.Name,
                        Category = item.Category,
                        ImagePath = item.ImagePath,
                        Price = item.Price,
                        Status = item.Status,
                    });
                }
                return foods;
            }
            return new List<FoodItemDTO>();
        }

        public FoodItemDTO GetOne(int foodItemId)
        {
            var item = _context.FoodItems.Find(foodItemId);

            if (item != null)
            {
                return new FoodItemDTO
                {
                    FoodItemId = item.FoodItemId,
                    Name = item.Name,
                    Category = item.Category,
                    ImagePath = item.ImagePath,
                    Price = item.Price,
                    Status = item.Status,
                };
            }
            return new FoodItemDTO();
        }

        public void RemoveItem(int foodItemId)
        {
            var item = _context.FoodItems.Find(foodItemId);

            if (item != null)
            {
                _context.FoodItems.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}
