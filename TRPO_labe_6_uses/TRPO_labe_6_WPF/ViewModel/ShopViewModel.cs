using System.Collections.ObjectModel;
using TRPO_labe_6.Models;

namespace TRPO_labe_6_WPF.ViewModel
{
    public class ShopViewModel : ViewModelBase
    {
        private Shop _innerShop;
        private ObservableCollection<Product> _products;
        private ObservableCollection<ShopAssistant> _shopAssistants;

        public ObservableCollection<ShopAssistant> ShopAssistants
        {
            get => _shopAssistants;
            set => SetValue(ref _shopAssistants, value);
        }

        public ObservableCollection<Product> Products
        {
            get => _products;
            set => SetValue(ref _products, value);
        }

        public Shop InnerShopInstance
        {
            get => _innerShop;
            set => SetValue(ref _innerShop, value);
        }

        public ShopViewModel(Shop shop)
        {
            InnerShopInstance = shop;
            ShopAssistants = new ObservableCollection<ShopAssistant>(shop.Assistants);
            Products = new ObservableCollection<Product>(shop.Products);
        }
    }
}
