using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.Linq;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFDesigner
{

    public partial class Designer : UserControl
    {
        public static bool[] IsUIChecked = new bool[3];

        
        public static FrameworkElement FRAMEEL = null;

        public static List<DesignerComponent> frameworkElements = new List<DesignerComponent>();
        

        public Designer()
        {
            
            InitializeComponent();
            //MyStaticClass.DesignElement = frameworkElements;
        }

        public void Add(FrameworkElement item, UIElement UI, Point point)
        {
            DesignerComponent items = new DesignerComponent(item, UI, point);
            items.Height = 50;
            items.Width = 150;
            this.DesignArea.Children.Add(items);
            frameworkElements.Add(items);
        }

        /// <summary>
        /// 삭제하기
        /// </summary>
        /// <param name="item">삭제할 요소</param>
        public void DeleteElement(DesignerComponent item)
        {
            frameworkElements.Remove(item);
            this.DesignArea.Children.Remove(item);
            #region 예전 하드코딩 사용 금지
            //((DesignerComponent)item).FrameworkElementSetting.Height = 0;
            // ((DesignerComponent)item).FrameworkElementSetting.Width = 0;
            // ((DesignerComponent)item).IsSelected = false;
            //  item = null;
            #endregion
            ClearUIProPerty();
        }

        public void ClearUIProPerty()
        {
            MyStaticClass.ucp.UIKindSetting = "컨트롤";
            MyStaticClass.ucp.UI_NameSetting = string.Empty;
            MyStaticClass.ucp.UIWidth.Text = string.Empty;
            MyStaticClass.ucp.UIHeigth.Text = string.Empty;
            MyStaticClass.ucp.UI_Horizon.Text = string.Empty;
            MyStaticClass.ucp.UI_Vertical.Text = string.Empty;
            MyStaticClass.ucp.LB_Option1.Text = string.Empty;
            MyStaticClass.ucp.UI_Option1.Text = string.Empty;
            MyStaticClass.ucp.UI_Option1.Visibility = Visibility.Hidden;

            
           
        }

        public void ChangeImage(BitmapImage bitmap)
        {
            areabackground.Stretch = Stretch.Fill;
            areabackground.ImageSource = bitmap;
        }

        #region Event Handle
        /// <summary>
        /// 선택되었을때 선택영역을 제외한 모든곳 선택해제
        /// </summary>
        /// <param name="sender">이벤트</param>
        /// <param name="e">마우스 이벤트 이벤트</param>
        private void DesignArea_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            foreach (FrameworkElement fElem in DesignArea.Children)
            {
                ((DesignerComponent)fElem).IsSelected = false;

            }
            ClearUIProPerty();


        }
        #endregion

        private void OuterBorder_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MyStaticClass.IsMainGridClik = true;
            Point pt = e.GetPosition(this);
            pt.Y = pt.Y;
            if (MyStaticClass.ul.NewButton.IsSelected ||IsUIChecked[0]==true)
            {
                MyButton my = new MyButton("버튼", "이태릭체", "없음", 10);
                Rectangle r = new Rectangle();
                Button mq = new Button();
                r.RadiusX = 0;
                r.RadiusY = 0;
                //ImageBrush myBrush = new ImageBrush();
                //myBrush.ImageSource =
                //    new BitmapImage(new Uri(@"C:\Users\inhye\Desktop\1497330714590.jpg", UriKind.Relative));
                //r.Fill = myBrush;
                // r.Fill = new SolidColorBrush(Colors.Black);
                VisualBrush myBrush = new VisualBrush();
                StackPanel aPanel = new StackPanel();
                // Create a DrawingBrush and use it to
                // paint the panel.
                DrawingBrush myDrawingBrushBrush = new DrawingBrush();
                GeometryGroup aGeometryGroup = new GeometryGroup();
                aGeometryGroup.Children.Add(new RectangleGeometry(new Rect(0, 0, 50, 50)));
                //aGeometryGroup.Children.Add(new RectangleGeometry(new Rect(50, 50, 50, 50)));
                RadialGradientBrush checkerBrush = new RadialGradientBrush();
                checkerBrush.GradientStops.Add(new GradientStop(Colors.Gray, 0.0));
                //checkerBrush.GradientStops.Add(new GradientStop(Colors.White, 1.0));
                GeometryDrawing checkers = new GeometryDrawing(checkerBrush, null, aGeometryGroup);
                myDrawingBrushBrush.Drawing = checkers;
                aPanel.Background = myDrawingBrushBrush;

                // Create some text.
                TextBlock someText = new TextBlock();
                someText.Text = "버튼";
                FontSizeConverter fSizeConverter = new FontSizeConverter();
                someText.FontSize = (double)fSizeConverter.ConvertFromString("10pt");
                someText.Margin = new Thickness(10);
                aPanel.Children.Add(someText);
                myBrush.Visual = aPanel;
                r.Fill = myBrush;
                r.Fill.Opacity = 0.8;
                this.Add(r, my, pt);
                MyStaticClass.ul.NewButton.IsSelected = false;
            }

            else if ((MyStaticClass.ul.NewCheckBox.IsSelected) || IsUIChecked[1] == true)
            {
                MyTextBox my = new MyTextBox("텍스트박스", "이태릭체", "없음", 10);
                Rectangle r = new Rectangle();
                r.RadiusX = 0;
                r.RadiusY = 0;

                VisualBrush myBrush = new VisualBrush();
                StackPanel aPanel = new StackPanel();
                DrawingBrush myDrawingBrushBrush = new DrawingBrush();
                GeometryGroup aGeometryGroup = new GeometryGroup();
                aGeometryGroup.Children.Add(new RectangleGeometry(new Rect(0, 0, 50, 50)));
                RadialGradientBrush checkerBrush = new RadialGradientBrush();
                checkerBrush.GradientStops.Add(new GradientStop(Colors.LightCyan, 0.0));
                GeometryDrawing checkers = new GeometryDrawing(checkerBrush, null, aGeometryGroup);
                myDrawingBrushBrush.Drawing = checkers;
                aPanel.Background = myDrawingBrushBrush;

                // Create some text.
                TextBlock someText = new TextBlock();
                someText.Text = "텍스트박스";
                FontSizeConverter fSizeConverter = new FontSizeConverter();
                someText.FontSize = (double)fSizeConverter.ConvertFromString("10pt");
                someText.Margin = new Thickness(10);
                aPanel.Children.Add(someText);
                myBrush.Visual = aPanel;

                r.Fill = myBrush;
                r.Fill.Opacity = 0.8;
                this.Add(r, my, pt);
                MyStaticClass.ul.NewCheckBox.IsSelected = false;
              
               
            }
            for (int i = 0; i < IsUIChecked.Length; i++)
                IsUIChecked[i] = false;
            MyStaticClass.IsMainGridClik = false;
        }
    }
}
