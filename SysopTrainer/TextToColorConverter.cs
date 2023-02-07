using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SysopTrainer
{
    public class TextToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string text = (string)value;
            SolidColorBrush cb;

            if (text.Contains("Correct!"))
            {
                cb = new SolidColorBrush(Color.FromRgb(34, 139, 34));
            }
            else if (text.Contains("Incorrect!"))
            {
                cb = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
            else
            {
                cb = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }

            return cb;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}