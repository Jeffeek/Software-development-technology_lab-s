using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using TRPO_labe_6.Models;
using TRPO_labe_6_WPF.Model;

namespace TRPO_labe_6_WPF.ViewModel
{
    public class ShopsWindowViewModel : ViewModelBase
    {
        private ShopAssistant _selectedShopAssistant;
        private Shop _selectedShop;
        private Product _selectedProduct;

        public ICommand LoadShopsCommand { get; }
        public ICommand SaveShopsCommand { get; }


        public ObservableCollection<Shop> Shops { get; set; }

        public Shop SelectedShop
        {
            get => _selectedShop;
            set => SetValue(ref _selectedShop, value);
        }

        public ShopAssistant SelectedShopAssistant
        {
            get => _selectedShopAssistant;
            set => SetValue(ref _selectedShopAssistant, value);
        }

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set => SetValue(ref _selectedProduct, value);
        }

        private void OnLoadShopsExecuted()
        {
            ShopsDeserializer deserializer = new ShopsDeserializer($"{Directory.GetCurrentDirectory()}//Files//shops.json");
            Shops = new ObservableCollection<Shop>(deserializer.GetAll());
        }

        private void OnSaveShopsExecuted()
        {
            ShopsSerializer serializer = new ShopsSerializer($"{Directory.GetCurrentDirectory()}//Files//shops.json");
            serializer.RewriteAll(Shops.ToList());
        }


        public ShopsWindowViewModel()
        {
            LoadShopsCommand = new RelayCommand(OnLoadShopsExecuted);
            SaveShopsCommand = new RelayCommand(OnSaveShopsExecuted);
        }
    }
}
