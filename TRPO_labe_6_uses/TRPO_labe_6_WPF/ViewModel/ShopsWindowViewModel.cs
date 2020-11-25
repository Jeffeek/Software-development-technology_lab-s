using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using TRPO_labe_6.Models;
using TRPO_labe_6_WPF.Model;

namespace TRPO_labe_6_WPF.ViewModel
{
    public class ShopsWindowViewModel : ViewModelBase //TODO: V3073 https://www.viva64.com/en/w/v3073/ Not all IDisposable members are properly disposed. Call 'Dispose' when disposing 'ShopsWindowViewModel' class. Inspect: _selectedProduct, _selectedShop.
    {
        private ShopAssistantViewModel _selectedShopAssistant;
        private ProductViewModel _selectedProduct;
        private ShopViewModel _selectedShop;
        private ObservableCollection<ShopViewModel> _shops;

        public ICommand LoadShopsCommand { get; }
        public ICommand SaveShopsCommand { get; }

        public ICommand AddShopCommand { get; }
        public ICommand RemoveShopCommand { get; }

        public ICommand AddAssistantCommand { get; }
        public ICommand FireAssistantCommand { get; }

        public ICommand AddProductCommand { get; }
        public ICommand RemoveProductCommand { get; }

        public ICommand DetermineTheCostOfAllPurchases { get; }
        public ICommand DetermineSalaryForSelectedAssistant{ get; }

        public ObservableCollection<ShopViewModel> Shops
        {
            get => _shops; 
            set => SetValue(ref _shops, value);
        }

        public ShopViewModel SelectedShop
        {
            get => _selectedShop;
            set => SetValue(ref _selectedShop, value);
        }

        public ShopAssistantViewModel SelectedShopAssistant
        {
            get => _selectedShopAssistant;
            set => SetValue(ref _selectedShopAssistant, value);
        }

        public ProductViewModel SelectedProduct
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
            var shopsList = Shops.Select(shop => shop.InnerShopInstance).ToList();
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
            var observableShopAssistant = new ShopAssistantViewModel(shopAssistant);
            SelectedShop.ShopAssistants.Add(observableShopAssistant);
        }

        private bool CanAddShopAssistantExecute() => SelectedShop != null;

        private void OnFireShopAssistantExecuted()
        {
            SelectedShop.ShopAssistants.Remove(SelectedShopAssistant);
        }

        private bool CanAddProductExecute() => SelectedShop != null;

        private void OnAddProductExecuted()
        {
            var product = new Product("Product", 0);
            var observableProduct = new ProductViewModel(product);
            SelectedShop.Products.Add(observableProduct);
        }

        private bool CanRemoveProductExecute() => SelectedProduct != null;

        private void OnRemoveProductExecuted()
        {
            SelectedShop.Products.Remove(_selectedProduct);
        }

        private bool CanFireShopAssistantExecute() => SelectedShopAssistant != null;

        private bool CanDetermineTheCostOfAllPurchases() => SelectedShop != null;

        private void OnDetermineTheCostOfAllPurchases()
        {
            var cost = SelectedShop.InnerShopInstance.CalculateOverall();
            MessageBox.Show($"${cost}");
        }

        private bool CanDetermineSalaryForSelectedAssistant() => SelectedShopAssistant != null;

        private void OnDetermineSalaryForSelectedAssistant()
        {
            var salary = SelectedShopAssistant.InnerShopAssistant.CalculateSalary();
            MessageBox.Show($"${salary}");
        }

        public ShopsWindowViewModel()
        {
            Shops = new ObservableCollection<ShopViewModel>();
            LoadShopsCommand = new RelayCommand(OnLoadShopsExecuted);
            SaveShopsCommand = new RelayCommand(OnSaveShopsExecuted);
            AddShopCommand = new RelayCommand(OnAddShopExecuted);
            RemoveShopCommand = new RelayCommand(OnRemoveShopExecuted, CanRemoveShopExecute);
            AddAssistantCommand = new RelayCommand(OnAddShopAssistantExecuted, CanAddShopAssistantExecute);
            FireAssistantCommand = new RelayCommand(OnFireShopAssistantExecuted, CanFireShopAssistantExecute);
            AddProductCommand = new RelayCommand(OnAddProductExecuted, CanAddProductExecute);
            RemoveProductCommand = new RelayCommand(OnRemoveProductExecuted, CanRemoveProductExecute);
            DetermineTheCostOfAllPurchases = new RelayCommand(OnDetermineTheCostOfAllPurchases, CanDetermineTheCostOfAllPurchases);
            DetermineSalaryForSelectedAssistant = new RelayCommand(OnDetermineSalaryForSelectedAssistant, CanDetermineSalaryForSelectedAssistant);
        }
    }
}
