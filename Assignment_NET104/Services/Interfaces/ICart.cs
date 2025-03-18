using Assignment_NET104.DTO;
using Assignment_NET104.Models;

namespace Assignment_NET104.Services.Interfaces
{
    public interface ICart
    {
        //For creation
        void CreateNew(Cart cart);
        public CartDTO GetCart(string id);

        //For user side
        void AddToCart(string id, CartItem item);
        List<CartItemDTO> ViewCart(string id);
        void RemoveFromCart(string id, CartItem item);
    }
}
