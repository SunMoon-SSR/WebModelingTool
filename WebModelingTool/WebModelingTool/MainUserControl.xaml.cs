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
        private WebBrowser webview;
        private RichTextBox HtmlCordRich;
        private bool IsButtonCheck = false;
        private bool IsTextBoxCheck = false;
        private bool IsRadioButtonCheck = false;
        public MainUserControl()
        {
            InitializeComponent();
           UserControlProperty  ul = WebModelingStaticClass.ucp;
            Designer de = WebModelingStaticClass.de;
            de.Width = 1000;
            de.Height = 800;
            //DrawGrid.Children.Add(de);
            //TrackInfoGrid.Children.Add(ul);
            this.LayoutUpdated += MainUserControl_LayoutUpdated;
            UserControlUIDefinition ucud =new UserControlUIDefinition();
            UIDefinitionGrid.Children.Add(ucud);
             webview=ucud.GetWebViewer();
            HtmlCordRich = ucud.GetHtmlViewer();

            webview.NavigateToString("<HTML><H2><B>hello HtmlModeling Tool Html</B><P></P></H2><H2><B>It's WebBrowser</B><P></P></H2>");


        }
        #region UIRedefinition
        private void MainUserControl_LayoutUpdated(object sender, EventArgs e)
        {
            if (WebModelingStaticClass.IsMainGridClik==false&& dotCheckBox.IsChecked==false)
            {
                ButtonRadioButton.IsChecked = false;
                IsButtonCheck = false;
                TextBoxRadioButton.IsChecked = false;
                IsTextBoxCheck = false;
                RadioButtonRadioButton.IsChecked = false;
                IsRadioButtonCheck = false;
            }
            else if(dotCheckBox.IsChecked==true)
            {
                if (IsButtonCheck)
                    Designer.IsUIChecked[0] = true;
                else if(IsTextBoxCheck)
                    Designer.IsUIChecked[1] = true;
            }
        }
        #endregion

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

            //HTMLGridRowDefinition.Height = new GridLength(HTMLGridRowDefinition.Height.Value * Ratio);
            //ViewGridParent.Margin = new Thickness(ViewGridParent.Margin.Left * Ratio, 0, 0, 0);

            //if (e.PreviousSize.Width == 0)
            //{
            //    HTMLGridRowDefinition.Height = new GridLength(160 * e.NewSize.Width / 1916);
            //    ViewGridParent.Margin = new Thickness(HTMLGridRowDefinition.Height.Value, 0, 0, 0);
            //}


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
        private void ButtonRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            dotCheckBox.IsEnabled = true;
            if (dotCheckBox.IsChecked == true)
            {
                IsButtonCheck = true;
                
            }
            Designer.IsUIChecked[0] = true;

        }

        private void TextBoxRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            dotCheckBox.IsEnabled = true;
            if (dotCheckBox.IsChecked == true)
            {
                IsTextBoxCheck = true;
            }

            Designer.IsUIChecked[1] = true;
        }

        private void RadioButtonRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            dotCheckBox.IsEnabled = true;
            if (dotCheckBox.IsChecked == true)
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
            HtmlCordRich.AppendText("");
            HtmlConverter htm = new HtmlConverter();
            htm.Close();
            webview.NavigateToString(WebModelingStaticClass.TestWebBrowserData);
            HtmlCordRich.AppendText(WebModelingStaticClass.TestWebBrowserData);
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
