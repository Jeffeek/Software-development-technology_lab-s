using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO_labe_6.Models;
using TRPO_labe_6_WPF.ViewModel;

namespace TRPO_labe_6_WPF.Model
{
    public class ShopViewModel : ViewModelBase
    {
        private Shop _innerShop;

        private ObservableCollection<ShopAssistant> _shopAssistants;
        public ObservableCollection<ShopAssistant> ShopAssistants
        {
            get => _shopAssistants;
            set => SetValue(ref _shopAssistants, value);
        }

        public Shop InnerShopInstance
        {
            get => _innerShop;
            set => SetValue(ref _innerShop, value);
        }

        public ShopViewModel(Shop shop)
        {
            InnerShopInstance = shop;
        }
    }
}
