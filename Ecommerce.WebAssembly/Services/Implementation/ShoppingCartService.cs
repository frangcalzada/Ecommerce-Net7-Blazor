using Ecommerce.WebAssembly.Services.Contract;
using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Services.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly ISyncLocalStorageService _syncLocalStorageService;
        private readonly IToastService _toastService;
        
        public ShoppingCartService(ILocalStorageService localStorageService, ISyncLocalStorageService syncLocalStorageService, IToastService toastService)
        {
            _localStorageService = localStorageService;
            _syncLocalStorageService = syncLocalStorageService;
            _toastService = toastService;
        }

        public event Action ShowItems;

        public async Task AddShoppingCart(ShoppingCartDTO model)
        {
            try
            {
                var shoppingCart = await _localStorageService.GetItemAsync<List<ShoppingCartDTO>>("shoppingcart");
                if (shoppingCart == null)
                    shoppingCart = new List<ShoppingCartDTO>();

                var itemFound = shoppingCart.FirstOrDefault(s => s.Product == model.Product);

                if(itemFound != null)
                    shoppingCart.Remove(itemFound);

                shoppingCart.Add(model);
                //updating shoppingCart
                await _localStorageService.SetItemAsync("shoppingCart", shoppingCart);

                if (itemFound != null)
                    _toastService.ShowSuccess("Product updated to cart");
                else
                    _toastService.ShowSuccess("Product added to cart");

                //Updating View
                ShowItems.Invoke();
            }
            catch
            {
                _toastService.ShowError("Could not be added to cart");
            }
        }

        public async Task CleanShoppingCart()
        {
            await _localStorageService.RemoveItemAsync("shoppingcart");
            ShowItems.Invoke();
        }

        public async Task<List<ShoppingCartDTO>> GetAllShoppingCarts()
        {
            var shoppingCart = await _localStorageService.GetItemAsync<List<ShoppingCartDTO>>("shoppingcart");
            if(shoppingCart == null)
                shoppingCart= new List<ShoppingCartDTO>();

            return shoppingCart;
        }

        public int ProductsAmount()
        {
            var shoppingCart = _syncLocalStorageService.GetItem<List<ShoppingCartDTO>>("shoppingcart");
            return shoppingCart  == null ? 0 : shoppingCart.Count();
        }

        public async Task RemoveShoppingCart(int idProduct)
        {
            try
            {
                var shoppingCart = await _localStorageService.GetItemAsync<List<ShoppingCartDTO>>("shoppingcart");
                if(shoppingCart != null)
                {
                    var element = shoppingCart.FirstOrDefault(s => s.Product?.IdProduct == idProduct);
                    if(element != null)
                    {
                        shoppingCart.Remove(element);
                        await _localStorageService.SetItemAsync("shoppingcart", shoppingCart);
                        ShowItems.Invoke();
                    }

                }
            }
            catch
            {
                _toastService.ShowError("Could not delete product from cart");
            }
        }
    }
}
