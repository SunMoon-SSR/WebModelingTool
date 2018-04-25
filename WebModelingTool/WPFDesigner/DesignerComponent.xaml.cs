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
using System.Windows.Controls.Primitives;

namespace WPFDesigner
{
    public partial class DesignerComponent : UserControl
    {
        private static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool), typeof(DesignerComponent), new FrameworkPropertyMetadata(false));

        public double UIHorizontal;
        public double UIVertical;

        //개체를 보내주는것
        public static DesignerComponent StDeCompon = null;
        //개체 랙탱글 위치
        public FrameworkElement FrameworkElementSetting { get; set; }
        private readonly double minHeight;
        private readonly double minWidth;

        private readonly double maxHeight;
        private readonly double maxWidth;

        public UIElement MyUI { get; set; }

        public bool CanVResize { get; private set; }
        public bool CanHResize { get; private set; }

        /// <summary>
        /// 선택된 개체 반환 함수
        /// </summary>
        /// <returns></returns>
        /// 

        public static DesignerComponent GetSellectedComponent()
        {

            return StDeCompon;
        }

        /// <summary>
        ///  외부에서 크기를을 업데이트 시킬때
        /// </summary>
        public void updateUnit()
        {
            UIPropertyDataSetting();
        }
        public DesignerComponent(FrameworkElement content, UIElement UI, Point point)
        {
            UIHorizontal = point.X;
            UIVertical = point.Y;

            MyUI = UI;
            FrameworkElementSetting = content;
            this.InitializeComponent();

            //크기조정
            if (!double.IsNaN(content.Width))
            {
                CanHResize = false;
                this.Width = content.Width;
            }
            else
            {
                CanHResize = true;
                this.Width = 23.0;
            }

            if (!double.IsNaN(content.Height))
            {
                CanVResize = false;
                this.Height = content.Height; ;
            }
            else
            {
                CanVResize = true;
                this.Height = 23.0;
            }

            //최소값 최대값 설정 확인
            minWidth = content.MinWidth < 10.0 ? 10.0 : content.MinWidth;
            minHeight = content.MinHeight < 10.0 ? 10.0 : content.MinHeight;
            maxWidth = content.MaxWidth;
            maxHeight = content.MaxHeight;
            #region 예전 코드
            //double top = (double)content.GetValue(Canvas.TopProperty);
            //if (double.IsNaN(top))
            //{
            //    top = 0.0;
            //}

            //double left = (double)content.GetValue(Canvas.LeftProperty);
            //if (double.IsNaN(left))
            //{
            //    left = 0.0;
            //}
            #endregion
            SetValue(Canvas.TopProperty, UIVertical);
            SetValue(Canvas.LeftProperty, UIHorizontal);

            this.Content = content;
        }

        public new object Content
        {
            get
            {
                return this.ContentComponent.Content;
            }
            protected set
            {
                this.ContentComponent.Content = value;
            }
        }

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        //마우스로 클린된 개체
        private void DesignerComponent_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.IsSelected = true;
            StDeCompon = this;
            UIPropertyDataSetting();
       


        }

        // 유아이 속성창 보여주기
        private void UIPropertyDataSetting()
        {
            WebModelingStaticClass.ucp.UI_NameSetting = this.MyUI.UIName; 
            WebModelingStaticClass.ucp.UIHeigthSetting = this.Height;
            WebModelingStaticClass.ucp.UIWidthSetting = this.Width;
            WebModelingStaticClass.ucp.UI_HorizonSetting = UIHorizontal;
            WebModelingStaticClass.ucp.UI_VerticalSetting = UIVertical;

            //UI 형변환
            if ((MyUI is UI_Button))
            {

                UI_Button but = this.MyUI as UI_Button;
                WebModelingStaticClass.ucp.UIKindSetting = "버튼";
                WebModelingStaticClass.ucp.LB_Option1.Text = but.UIName;
                WebModelingStaticClass.ucp.UI_Option1.Text = but.UIName;
                WebModelingStaticClass.ucp.UI_Option1.Visibility = Visibility.Visible;

            }
            else if ((MyUI is UI_TextBox))
            {

                UI_TextBox but = this.MyUI as UI_TextBox;
                WebModelingStaticClass.ucp.UIKindSetting = "텍스트박스";
            }
        }

        /// <summary>
        /// 늘리거나 주릴때 발생하는 이벤트 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            string name = ((Thumb)sender).Name;

            // 위를 키울때
            if (name.Contains("Top"))
            {
                double newHeight = this.Height - e.VerticalChange;
                if (newHeight >= minHeight && newHeight <= maxHeight)
                {
                    this.Height = newHeight;
                    UIPropertyDataSetting();
                    SetValue(Canvas.TopProperty, (double)GetValue(Canvas.TopProperty) + e.VerticalChange);
                }
            }

            if (name.Contains("Right"))
            {

                double newWidth = this.Width + e.HorizontalChange;

                if (newWidth >= minWidth && newWidth <= maxWidth)
                    this.Width = newWidth;
                UIPropertyDataSetting();
            }

            if (name.Contains("Bottom"))
            {
                double newHeight = this.Height + e.VerticalChange;
                if (newHeight >= minHeight && newHeight <= maxHeight)
                    this.Height = newHeight;
                UIPropertyDataSetting();
            }

            if (name.Contains("Left"))
            {
                double newWidth = this.Width - e.HorizontalChange;
                if (newWidth >= minWidth && newWidth <= maxWidth)
                {
                    this.Width = newWidth;
                    UIPropertyDataSetting();
                    SetValue(Canvas.LeftProperty, (double)GetValue(Canvas.LeftProperty) + e.HorizontalChange);
                }
            }
        }
        public void UIPostionUpdate()
        {
            SetValue(Canvas.LeftProperty, UIHorizontal);
            SetValue(Canvas.TopProperty, UIVertical);
            UIPropertyDataSetting();
        }
        /// <summary>
        /// 드래그하여 위치를 이동시킬때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            UIHorizontal = (double)GetValue(Canvas.LeftProperty) + e.HorizontalChange;
            UIVertical = (double)GetValue(Canvas.TopProperty) + e.VerticalChange;
            SetValue(Canvas.LeftProperty, (double)GetValue(Canvas.LeftProperty) + e.HorizontalChange);
            SetValue(Canvas.TopProperty, (double)GetValue(Canvas.TopProperty) + e.VerticalChange);
            UIPropertyDataSetting();
        }
    }
}
