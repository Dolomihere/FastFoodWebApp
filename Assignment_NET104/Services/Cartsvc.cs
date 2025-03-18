using Assignment_NET104.DataContext;
using Assignment_NET104.DTO;
using Assignment_NET104.Models;
using Assignment_NET104.Services.Interfaces;

namespace Assignment_NET104.Services
{
    public class Cartsvc : ICart
    {
        protected WebContext _context;
        public Cartsvc(WebContext context)
        {
            _context = context;
        }

        public CartDTO GetCart(string id)
        {
            if (int.TryParse(id, out var value))
            {
                int key = int.Parse(id);
                var cart = _context.Carts.FirstOrDefault(c => c.CustomerId == key);

                if (cart != null)
                {
                    return new CartDTO
                    {
                        CartId = cart.CartId,
                        CreatedDate = cart.CreatedDate,
                        UpdatedDate = cart.UpdatedDate
                    };
                }
            }
            else
            {
                var cart = _context.Carts.FirstOrDefault(c => c.SessionId == id);

                if (cart != null)
                {
                    return new CartDTO
                    {
                        CartId = cart.CartId,
                        CreatedDate = cart.CreatedDate,
                        UpdatedDate = cart.UpdatedDate
                    };
                }
            }
            return new CartDTO();
        }

        public void AddToCart(string id, CartItem item)
        {
            if (int.TryParse(id, out var value))
            {
                int key = int.Parse(id);
                var cart = _context.Carts.FirstOrDefault(c => c.CustomerId == key);

                if (cart != null)
                {
                    var foodItem = _context.CartItems.Where(ci => ci.CartId == cart.CartId);
                    var cartItem = foodItem.FirstOrDefault(ci => ci.FoodItemId == item.FoodItemId);

                    if (cartItem == null)
                    {
                        cart.CartItems.Add(item);
                    }
                    else
                    {
                        CartItem curItem = cartItem;
                        curItem.Quantity++;
                        cart.CartItems.Add(curItem);
                    }
                    _context.SaveChanges();
                }
            }
            else
            {
                var cart = _context.Carts.FirstOrDefault(c => c.SessionId == id);

                if (cart != null)
                {
                    var foodItem = _context.CartItems.Where(ci => ci.CartId == cart.CartId);
                    var cartItem = foodItem.FirstOrDefault(ci => ci.FoodItemId == item.FoodItemId);

                    if (cartItem == null)
                    {
                        cart.CartItems.Add(item);
                    }
                    else
                    {
                        CartItem curItem = cartItem;
                        curItem.Quantity++;
                        cart.CartItems.Add(curItem);
                    }
                    _context.SaveChanges();
                }
            }
        }

        public void CreateNew(Cart cart)
        {
            _context.Carts.Add(cart);
            _context.SaveChanges();
        }

        public void RemoveFromCart(string id, CartItem item)
        {
            if (int.TryParse(id, out var value))
            {
                int key = int.Parse(id);
                var cart = _context.Carts.FirstOrDefault(c => c.CustomerId == key);

                if (cart != null)
                {
                    cart.CartItems.Remove(item);
                    _context.SaveChanges();
                }
            }
            else
            {
                var cart = _context.Carts.FirstOrDefault(c => c.SessionId == id);

                if (cart != null)
                {
                    cart.CartItems.Remove(item);
                    _context.SaveChanges();
                }
            }
        }

        public List<CartItemDTO> ViewCart(string id)
        {
            if (int.TryParse(id, out var value))
            {
                int key = int.Parse(id);
                var cart = _context.Carts.FirstOrDefault(c => c.CustomerId == key);

                if (cart != null)
                {
                    var foodItem = _context.CartItems.Where(ci => ci.CartId == cart.CartId);
                    List<CartItemDTO> items = new List<CartItemDTO>();

                    foreach (var item in foodItem)
                    {
                        items.Add(new CartItemDTO
                        {
                            FoodItemId = item.FoodItemId,
                            FoodItemName = item.FoodItemName,
                            Quantity = item.Quantity,
                            Price = item.Price,
                            FoodItemImage = item.FoodItemImage,
                        });
                    }
                    return items;
                }
            }
            else
            {
                var cart = _context.Carts.FirstOrDefault(c => c.SessionId == id);

                if (cart != null)
                {
                    var foodItem = _context.CartItems.Where(ci => ci.CartId == cart.CartId);
                    List<CartItemDTO> items = new List<CartItemDTO>();

                    foreach (var item in foodItem)
                    {
                        items.Add(new CartItemDTO
                        {
                            FoodItemId = item.FoodItemId,
                            FoodItemName = item.FoodItemName,
                            Quantity = item.Quantity,
                            Price = item.Price,
                            FoodItemImage = item.FoodItemImage,
                        });
                    }
                    return items;
                }
            }
            return new List<CartItemDTO>();
        }
    }
}
