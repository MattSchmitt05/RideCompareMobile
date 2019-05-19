using System;
using System.Globalization;
using Xamarin.Forms;

namespace RideCompare.Converters
{
    public class FocusedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var eventArgs = value as FocusEventArgs;
            return eventArgs.IsFocused;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
