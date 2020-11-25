using System;
using System.Collections.Generic;
using TRPO_labe_6.Models;

namespace TRPO_labe_6_WPF.ViewModel
{
    public class ShopAssistantViewModel : ViewModelBase
    {
        private ShopAssistant _innerShopAssistant;

        public ShopAssistant InnerShopAssistant
        {
            get => _innerShopAssistant;
            set => SetValue(ref _innerShopAssistant, value);
        }

        public ShopAssistantViewModel(ShopAssistant product)
        {
            InnerShopAssistant = product;
        }
    }
}
