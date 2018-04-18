using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFDesigner;

namespace WPFDesigner
{
    /// <summary>
    /// UserControlList.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControlList : UserControl
    {
        Designer de;

        public UserControlList(Designer de)
        {
            this.de = de;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HtmlConverter ht = new HtmlConverter();
            ht.ShowDialog();
            //OpenFileDialog op = new OpenFileDialog();
            //if (op.ShowDialog() == false)
            //    return;

            //BitmapImage bitmapImage = new BitmapImage(new Uri(op.FileName, UriKind.RelativeOrAbsolute));

            //de.ChangeImage(bitmapImage);
        }

        private void ListBoxItem_Selected_button(object sender, RoutedEventArgs e)
        {

        }

        private void ListBoxItem_Selected_CheckBox(object sender, RoutedEventArgs e)
        {
            //  de.Add(r);
        }
    }
}
