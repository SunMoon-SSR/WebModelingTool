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

namespace WebModelingTool
{
    /// <summary>
    /// UserControlUIDefinition.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControlUIDefinition : UserControl
    {
        public UserControlUIDefinition()
        {
            InitializeComponent();
            
            UIPropertyGrid.Children.Add(WebModelingStaticClass.ucp);
         //   htmlViewer.NavigateToString("<HTML><H2><B>asd Html</B><P></P></H2><H2><B>hhhhhh</B><P></P></H2>");
   
        }
        public WebBrowser GetWebViewer()
        {
            return this.htmlViewer;
        }
        public RichTextBox GetHtmlViewer()
        {
            return this.HtmlCodeRichTextBox;
        }
    }
}
