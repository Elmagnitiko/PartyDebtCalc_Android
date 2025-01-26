using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace PartyDebtCalc_Android
{
    public class MultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.All(v => (bool)v);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
