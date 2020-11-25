using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using TRPO_labe_6.Models;

namespace TRPO_labe_6_WPF.ViewModel
{
    public class ProductViewModel : ViewModelBase
    {
        private Product _innerProduct;
        private int _count;

        public ICommand IncrementProductCountCommand { get; }
        public ICommand DecrementProductCountCommand { get; }

        public Product InnerProductInstance
        {
            get => _innerProduct;
            set => SetValue(ref _innerProduct, value);
        }

        public int Count
        {
            get => _count;
            set
            {
                SetValue(ref _count, value);
                InnerProductInstance.Count = _count;
            }
        }

        private void OnIncrementProductCount()
        {
            Count += 1;
        }

        private bool CanDecrementProductCount(ShopAssistantViewModel shopAssistant) => Count > 0;

        private void OnDecrementProductCount(ShopAssistantViewModel shopAssistant)
        {
            if (Count == 0) return;
            if (shopAssistant == null) return;
            shopAssistant.InnerShopAssistant.SellProduct(InnerProductInstance);
            Count -= 1;
        }

        public ProductViewModel(Product product)
        {
            InnerProductInstance = product;
            Count = product.Count;
            IncrementProductCountCommand = new RelayCommand(OnIncrementProductCount);
            DecrementProductCountCommand = new RelayCommand<ShopAssistantViewModel>(OnDecrementProductCount, CanDecrementProductCount);
        }
    }
}
