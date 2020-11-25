using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using TRPO_labe_6.Models;

namespace TRPO_labe_6_WPF.ViewModel
{
    public class ShopViewModel : ViewModelBase
    {
        private Shop _innerShop;
        private ObservableCollection<ProductViewModel> _products;
        private ObservableCollection<ShopAssistantViewModel> _shopAssistants;

        public ObservableCollection<ShopAssistantViewModel> ShopAssistants
        {
            get => _shopAssistants;
            set => SetValue(ref _shopAssistants, value);
        }

        public ObservableCollection<ProductViewModel> Products
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
            ShopAssistants = new ObservableCollection<ShopAssistantViewModel>();
            Products = new ObservableCollection<ProductViewModel>();
            FillProducts();
            FillShopAssistants();
            ShopAssistants.CollectionChanged += ShopAssistantsOnCollectionChanged;
            Products.CollectionChanged += ProductsOnCollectionChanged;
        }

        private void ProductsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            InnerShopInstance.Products = Products.Select(x => x.InnerProductInstance).ToList();
        }

        private void ShopAssistantsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            InnerShopInstance.Assistants = ShopAssistants.Select(x => x.InnerShopAssistant).ToList();
        }

        private void FillShopAssistants()
        {
            foreach (var shopAssistant in InnerShopInstance.Assistants)
            {
                ShopAssistants.Add(new ShopAssistantViewModel(shopAssistant));
            }
        }

        private void FillProducts()
        {
            foreach (var product in InnerShopInstance.Products)
            {
                Products.Add(new ProductViewModel(product));
            }
        }
    }
}
