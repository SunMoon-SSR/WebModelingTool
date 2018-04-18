using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;
using System.ComponentModel;

namespace WPFDesigner
{
    class MultiVisibilityConverter : IMultiValueConverter
    {
        #region IMultiValueConverter Members

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
                return Visibility.Visible;

            bool b1 = (bool)values[0];
            bool b2 = false;
            if (values.Length >= 2)
                b2 = (bool)values[1];
            if (values.Length == 3)
                b2 = b2 && (bool)values[2];
            if (!b2)
                return Visibility.Collapsed;
            return b1 ? Visibility.Visible : Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
