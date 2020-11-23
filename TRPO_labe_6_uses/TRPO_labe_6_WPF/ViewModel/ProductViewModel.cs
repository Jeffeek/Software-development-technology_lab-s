using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO_labe_6.Models;

namespace TRPO_labe_6_WPF.ViewModel
{
    public class ProductViewModel : ViewModelBase
    {
        private Product _innerProduct;
        private int _count;

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


        public ProductViewModel(Product product)
        {
            InnerProductInstance = product;
            Count = product.Count;
        }
    }
}
