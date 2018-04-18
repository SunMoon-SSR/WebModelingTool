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

namespace WPFDesigner
{
    /// <summary>
    /// UserControlProperty.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 
    public partial class UserControlProperty : UserControl
    {
        public string UIKindSetting
        {
            get
            {
                return UIKinds.Text;
            }
            set
            {
                UIKinds.Text= value;
            }
        }

        public string UI_NameSetting
        {
            get
            {
                return UI_Name.Text;
            }
            set
            {
                UI_Name.Text = value;
            }
        }

        public double UIHeigthSetting
        {
            get
            {
                return double.Parse(UIHeigth.Text);
            }
            set
            {
                UIHeigth.Text = value.ToString();
            }
        }

        public double UIWidthSetting
        {
            get
            {
                return double.Parse(UIWidth.Text);
            }
            set
            {
                UIWidth.Text = value.ToString();
            }
        }

        public double UI_VerticalSetting
        {
            get
            {
                return double.Parse(UI_Vertical.Text);
            }
            set
            {
                UI_Vertical.Text = value.ToString();
            }
        }

        public double UI_HorizonSetting
        {
            get
            {
                return double.Parse(UI_Horizon.Text);
            }
            set
            {
                UI_Horizon.Text = value.ToString();
            }
        }

        public UserControlProperty()
        {
            InitializeComponent();
            OptiSlider.Minimum = 0;
            OptiSlider.Maximum = 100;
        }
        private void UI_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if(DesignerComponent.GetSellectedComponent()!=null)
            {
                DesignerComponent.GetSellectedComponent().MyUI.UIName = UI_Name.Text;
            }
        }

        private void UIHeigth_KeyDown(object sender, KeyEventArgs e)
        {
            if (DesignerComponent.GetSellectedComponent() != null)
            {
                double heigth = 0 ;
                if(double.TryParse(UIHeigth.Text,out heigth))
                {
                    DesignerComponent.GetSellectedComponent().Height = heigth;
                    DesignerComponent.GetSellectedComponent().updateUnit();
                }
            }
        }

        private void UIWidth_KeyDown(object sender, KeyEventArgs e)
        {
            if (DesignerComponent.GetSellectedComponent() != null)
            {
                double width = 0;
                if (double.TryParse(UIWidth.Text, out width))
                {
                    DesignerComponent.GetSellectedComponent().Width =width;
                    DesignerComponent.GetSellectedComponent().updateUnit();
                }
            }
        }

        private void UI_Horizon_KeyDown(object sender, KeyEventArgs e)
        {
            if (DesignerComponent.GetSellectedComponent() != null)
            {
                double Horizon = 0;
                if (double.TryParse(UI_Horizon.Text, out Horizon))
                {
                    DesignerComponent.GetSellectedComponent().UIHorizontal = Horizon;
                    DesignerComponent.GetSellectedComponent().UIPostionUpdate();
                }
            }
        }

        private void UI_Vertical_KeyDown(object sender, KeyEventArgs e)
        {
            if (DesignerComponent.GetSellectedComponent() != null)
            {
                double Vertical = 0;
                if (double.TryParse(UI_Vertical.Text, out Vertical))
                {
                    DesignerComponent.GetSellectedComponent().UIVertical = Vertical;
                    DesignerComponent.GetSellectedComponent().UIPostionUpdate();
                }
            }
        }
    }
}
