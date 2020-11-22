using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TRPO_labe_6.Models;

namespace TRPO_labe_6_WPF.Converters
{
    class ValueTupleConverterT1 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var tuple = value as (Product, Int32)?;

            if (tuple == null)
                return null;

            return tuple.Value.Item1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
