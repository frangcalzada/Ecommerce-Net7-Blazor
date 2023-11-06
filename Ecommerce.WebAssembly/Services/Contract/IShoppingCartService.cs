using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Services.Contract
{
    public interface IShoppingCartService
    {
        //Shows items added to cart
        event Action ShowItems;
        int ProductsAmount();
        Task AddShoppingCart(ShoppingCartDTO model);
        Task RemoveShoppingCart(int idProduct);
        Task<List<ShoppingCartDTO>> GetAllShoppingCarts();
        Task CleanShoppingCart();

    }
}
