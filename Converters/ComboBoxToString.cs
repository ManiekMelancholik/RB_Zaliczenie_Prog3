using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace RB_Zaliczenie_Prog3.Converters
{
    public class ComboBoxToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "something";
           
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ComboBoxItem cbi = (ComboBoxItem)value;
            if (cbi != null)
            {
                return cbi.Content.ToString();
            }
            return "Null";
        }
    }
}
