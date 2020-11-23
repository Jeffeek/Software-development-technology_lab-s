using System;
using System.Collections.Generic;
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
        private Product _selectedProduct;
        private ShopViewModel _selectedShop;
        private ObservableCollection<ShopViewModel> _shops;

        public ICommand LoadShopsCommand { get; }
        public ICommand SaveShopsCommand { get; }

        public ICommand AddShopCommand { get; }
        public ICommand RemoveShopCommand { get; }

        public ICommand AddAssistantCommand { get; }
        public ICommand FireAssistantCommand { get; }

        public ICommand AddProductCommand { get; }
        public ICommand SellProductCommand { get; }

        public ObservableCollection<ShopViewModel> Shops
        {
            get => _shops; 
            set => SetValue(ref _shops, value);
        }

        public Shop SelectedShop
        {
            get => _selectedShop;
            set
            {
                SetValue(ref _selectedShop, value);
            }
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
            var shopsList = deserializer.GetAll();
            var observableShopsList = new ObservableCollection<ShopViewModel>();
            foreach (var shop in shopsList)
            {
                observableShopsList.Add(new ShopViewModel(shop));
            }

            Shops = observableShopsList;
        }

        private void OnSaveShopsExecuted()
        {
            ShopsSerializer serializer = new ShopsSerializer($"{Directory.GetCurrentDirectory()}//Files//shops.json");
            var observableShopsList = Shops.ToList();
            var shopsList = new List<Shop>();
            foreach (var shop in observableShopsList)
            {
                shopsList.Add(shop.InnerShopInstance);
            }
            serializer.RewriteAll(shopsList);
        }

        private void OnAddShopExecuted()
        {
            Shops.Add(new ShopViewModel(new Shop("Shop")));
        }

        private void OnRemoveShopExecuted()
        {
            Shops.Remove(SelectedShop);
        }

        private bool CanRemoveShopExecute() => SelectedShop != null;

        private void OnAddShopAssistantExecuted()
        {
            var shopAssistant = new ShopAssistant() { Age = 18, HiringDate = DateTime.Now, Name = "Assistant" };
            ShopAssistants.Add(shopAssistant);
        }

        private void ShopAssistants_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            SelectedShop.Assistants = ShopAssistants.ToList();
        }

        private bool CanAddShopAssistantExecute() => SelectedShop != null;

        private void OnFireShopAssistantExecuted()
        {
            ShopAssistants.Remove(SelectedShopAssistant);
        }

        private bool CanFireShopAssistantExecute() => SelectedShopAssistant != null;

        public ShopsWindowViewModel()
        {
            Shops = new ObservableCollection<Shop>();
            ShopAssistants = new ObservableCollection<ShopAssistant>();
            ShopAssistants.CollectionChanged += ShopAssistants_CollectionChanged;
            LoadShopsCommand = new RelayCommand(OnLoadShopsExecuted);
            SaveShopsCommand = new RelayCommand(OnSaveShopsExecuted);
            AddShopCommand = new RelayCommand(OnAddShopExecuted);
            RemoveShopCommand = new RelayCommand(OnRemoveShopExecuted, CanRemoveShopExecute);
            AddAssistantCommand = new RelayCommand(OnAddShopAssistantExecuted, CanAddShopAssistantExecute);
            FireAssistantCommand = new RelayCommand(OnFireShopAssistantExecuted, CanFireShopAssistantExecute);
        }
    }
}
