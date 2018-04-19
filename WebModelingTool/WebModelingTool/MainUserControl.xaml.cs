using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace WebModelingTool
{
    /// <summary>
    /// MainUserControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainUserControl : UserControl
    {
        public delegate void ChangeStatusTextEvent(string text);
        public delegate void NewProjectEvent(string type);
        public MainUserControl()
        {
            InitializeComponent();
           UserControlProperty  ul = MyStaticClass.ucp;
            Designer de = MyStaticClass.de;
            de.Width = 1000;
            de.Height = 800;
            DrawGrid.Children.Add(de);
            TrackInfoGrid.Children.Add(ul);
            this.LayoutUpdated += MainUserControl_LayoutUpdated;

        }

        private void MainUserControl_LayoutUpdated(object sender, EventArgs e)
        {
            if (MyStaticClass.IsMainGridClik==false&& dotCheckBox.IsChecked==false)
            {
                ButtonRadioButton.IsChecked = false;
                TextBoxRadioButton.IsChecked = false;
                RadioButtonRadioButton.IsChecked = false;
            }
            else if(dotCheckBox.IsChecked == false)
            {

            }
        }

        void myDoc_selectTrackEvent(int trackNum)
        {
            try
            {
               
            }
            catch
            {
               
            }
        }
        private void dotCheckBox_Checked(object sender, RoutedEventArgs e)
        {
           
        }
        private void InitProjectInfo()
        {
            
        }

        void pic_trackinfoChange()
        {
            InitProjectInfo();
        }

        
       
        public void ConvertMidToScore()
        {
   
           
        }

        private void TrackSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ComboBoxItem item = TrackSelectComboBox.SelectedItem as ComboBoxItem;
                if (item != null)
                {
                    string trackmenu = item.Content.ToString();
                    if (trackmenu != "트랙 선택")
                    {
                        int tracknum = int.Parse(trackmenu.Remove(0, 3));
                      
                        //if (track != null)
                        //{
                        //    MakeStaff(track);
                        //    AnalysisTrack(track, tracknum);
                        //    selectracknum = tracknum;
                        //}
                    }
                }
            }
            catch
            {
               
            }
        }
        void DisplayNote(int staff_num, int play_num)
        {
            try
            {
                
            }
            catch
            {
                MessageBox.Show("fail!");
            }
        }
        void DisappearNote(int staff_num, int play_num)
        {
           
        }
        void PlayCheckBoxFalse()
        {
            PlayCheckBox.IsChecked = false;
        }

        void Primary_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double Ratio;
            if (e.PreviousSize.Width == 0)
            {
                Ratio = 1;
            }
            else
            {
                Ratio = (double)((e.NewSize.Width) / e.PreviousSize.Width);
            }

            HTMLGridRowDefinition.Height = new GridLength(HTMLGridRowDefinition.Height.Value * Ratio);
            ViewGridParent.Margin = new Thickness(ViewGridParent.Margin.Left * Ratio, 0, 0, 0);

            if (e.PreviousSize.Width == 0)
            {
                HTMLGridRowDefinition.Height = new GridLength(160 * e.NewSize.Width / 1916);
                ViewGridParent.Margin = new Thickness(HTMLGridRowDefinition.Height.Value, 0, 0, 0);
            }


           // titleImg.Height = HTMLGridRowDefinition.Height.Value;
           // titleImg.Width = HTMLGridRowDefinition.Height.Value;
           // titleImg.Margin = new Thickness(0, 0, e.NewSize.Width - titleImg.Width, 0);
        }
        void ChExpander_Collapsed(object sender, RoutedEventArgs e)
        {

            PlayGropColumn.Width = new GridLength(180);
            ChExpander.Margin = new Thickness(0, 30.52, 0, 0);
        }
        void ChExpander_Expanded(object sender, RoutedEventArgs e)
        {
            PlayGropColumn.Width = new GridLength(280);
            ChExpander.Margin = new Thickness(0, 0, 0, 0);
        }
        private void Play(object sender, RoutedEventArgs e)
        {
            
        }
        private void Pause(object sender, RoutedEventArgs e)
        {
           
        }
        private void Stop(object sender, RoutedEventArgs e)
        {
          
        }
        private void PlayTrackViewCheck_Checked(object sender, RoutedEventArgs e)
        {
            TrackTreeView.Visibility = System.Windows.Visibility.Visible;
        }
        private void PlayTrackViewCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            TrackTreeView.Visibility = System.Windows.Visibility.Hidden;
        }
        #region Image Save
        private static RenderTargetBitmap bit;
        BitmapSource source;
        public void ScoreMusicSave_Click(object sender, RoutedEventArgs e)
        {
            bit = ConverterBitmapImage(DrawGrid);
            Convert(DrawGrid);
        }
        private void Convert(Grid grid)
        {
            int size = 2100;
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "PNG|*.png";
            sf.AddExtension = true;
            bool? result = sf.ShowDialog();
            if (result == true)
            {
                if ((grid.ActualHeight / size) < 1.5)
                {
                    source = CutAreaToImage(0, 0, grid.ActualWidth, size);
                    ImageSave(null, sf, source);
                }

                else
                {
                    double a = Math.Ceiling(((double)grid.ActualHeight / size));
                    if ((grid.ActualHeight - (a - 1) * size) <= 1700)
                    {
                        for (int i = 0; i < a - 1; i++)
                        {
                            source = CutAreaToImage(0, size * i, DrawGrid.ActualWidth, size);
                            ImageSave(i, sf, source);
                        }
                    }

                    else
                    {
                        for (int i = 0; i < a; i++)
                        {
                            source = CutAreaToImage(0, size * i, DrawGrid.ActualWidth, size);
                            ImageSave(i, sf, source);
                        }
                    }
                }
                size = 2100;
            }
        }
        private void ImageSave(int? number, Microsoft.Win32.SaveFileDialog saveDialog, BitmapSource source)
        {
            BitmapEncoder encoder = null;
            string path = saveDialog.FileName;
            char[] _path = path.ToCharArray(0, saveDialog.FileName.Length - 4);
            string newpath = new string(_path);
            if (number == null)
            {
                newpath = string.Format("{0}.png", newpath);
            }
            else
            {
                newpath = string.Format("{0}_{1}.png", newpath, number.ToString());
            }
            // 파일 생성
            FileStream stream = new FileStream(newpath, FileMode.Create, FileAccess.Write);

            // 파일 포맷
            string upper = saveDialog.SafeFileName.ToUpper();
            char[] format = upper.ToCharArray(saveDialog.SafeFileName.Length - 3, 3);
            upper = new string(format);

            encoder = new PngBitmapEncoder();
            // 인코더 프레임에 이미지 추가
            encoder.Frames.Add(BitmapFrame.Create(source));
            // 파일에 저장
            encoder.Save(stream);
            stream.Close();
            Process pr = new Process();
            pr.StartInfo.FileName = newpath;
            pr.Start();
        }
        private BitmapSource CutAreaToImage(int x, int y, double width, double height)
        {
            if (x < 0)
            {
                width += x;
                x = 0;
            }
            if (y < 0)
            {
                height += y;
                y = 0;

                width = (int)DrawGrid.ActualWidth - x;
            }
            if (x + width > DrawGrid.ActualWidth)
            {
                width = (int)DrawGrid.ActualWidth - x;
            }
            if (y + height > (int)DrawGrid.ActualHeight)
            {
                height = (int)DrawGrid.ActualHeight - y;
            }

            byte[] pixels = CopyPixels((int)x, (int)y, (int)width, (int)height);

            int stride = ((int)width * bit.Format.BitsPerPixel + 7) / 8;

            return BitmapSource.Create((int)width, (int)height, 96, 96, PixelFormats.Pbgra32, null, pixels, stride);
        }

        private byte[] CopyPixels(int x, int y, int width, int height)
        {
            byte[] pixels = new byte[width * height * 4];
            int stride = (width * bit.Format.BitsPerPixel + 7) / 8;

            // Canvas 이미지에서 객체 역역만큼 픽셀로 복사
            bit.CopyPixels(new Int32Rect(x, y, (int)width, (int)height), pixels, stride, 0);

            return pixels;
        }

        private RenderTargetBitmap ConverterBitmapImage(Grid grid)
        {

            DrawingVisual dv = new DrawingVisual();
            DrawingContext dc = dv.RenderOpen();


            //Size size = new Size(grid.ActualWidth, grid.ActualHeight);
            Size size = new Size(grid.ActualWidth, DrawGrid.ActualHeight);
            dc.DrawRectangle(new VisualBrush(grid), null, new Rect(new Point(0, 0), size));
            dc.Close();
            //RenderTargetBitmap target = new RenderTargetBitmap((int)grid.ActualWidth, (int)smu.ScoreGrid.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            RenderTargetBitmap target = new RenderTargetBitmap((int)grid.ActualWidth, (int)DrawGrid.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            target.Render(dv);
            return target;
        }
        #endregion

        public void ScoreDrawPrint(object sender, RoutedEventArgs e)
        {
            PrintDialog dlg = new PrintDialog();
            dlg.PageRangeSelection = PageRangeSelection.AllPages;
            dlg.UserPageRangeEnabled = true;

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                dlg.PrintVisual(DrawGrid, "HtmlView Print");
            }
        }


        private void ButtonRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            dotCheckBox.IsEnabled = true;
            if (dotCheckBox.IsChecked == true)
            {
                Designer.IsUIChecked[0] = true;
                
            }
            else
            {
                Designer.IsUIChecked[0] = true;
            }
            
        }

        private void TextBoxRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            dotCheckBox.IsEnabled = true;
            if (dotCheckBox.IsChecked == true)
            {
                Designer.IsUIChecked[1] = true;
            }
            else
            {
                Designer.IsUIChecked[1] = true;
            }
        }

        private void RadioButtonRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            dotCheckBox.IsEnabled = true;
            if (dotCheckBox.IsChecked == true)
            {
                
            }
            else
            {
               
            }
        }

        private void ImageRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            dotCheckBox.IsEnabled = true;
            if (dotCheckBox.IsChecked == true)
            {
                
            }
            else
            {
              
            }
        }
        private void dotCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
           
        }

        private void TieCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            SlurCheckBox.IsChecked = false;
        }

        private void SlurCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            TieCheckBox.IsChecked = false;
        }

        private void HtmlFileSaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
           
            sfd.DefaultExt = ".html";
            sfd.Filter = "html (*.html)|*.html";

            bool? ok = sfd.ShowDialog();

            if (ok == true)
            {
               
            }
        }

        private void NewProjectButton_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void ImageOpenButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void HtmlOpenButton_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void RecButton_Click(object sender, RoutedEventArgs e)
        {

           

        }

      

        private void DrawCheckBox_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void TitleLabel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void TitleTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void TitleTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
           
        }


      

        private void ModifyModeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //isModifyModeChecked = true;
        }

        private void ModifyModeCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
          //  isModifyModeChecked = false;
           // staffs[noteSelectStaffnum].DisappearRedLine();
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void UserControl_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
