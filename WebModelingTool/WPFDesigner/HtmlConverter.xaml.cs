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
using System.Windows.Shapes;

namespace WPFDesigner
{
    /// <summary>
    /// HtmlConverter.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class HtmlConverter : Window
    {
        protected List<DesignerComponent> frameworkElements = null;
        public string head = null;
        public string body = null;
        public string metadata= null;
        public HtmlConverter()
        {
            InitializeComponent();
            frameworkElements = Designer.frameworkElements;
            HTMLnote.Text += "<html>\n  <head>\n </head>\n  <body>\n";
            if(frameworkElements!=null)
            foreach (DesignerComponent de in frameworkElements)
            {
                if (de.MyUI is MyButton)
                {
                    MyButton be = de.MyUI as MyButton;
                    HTMLnote.Text += " <button type=" + '\u0022' + "button" + '\u0022' + ">\n   ";
                    HTMLnote.Text += "   " + be.UIName;
                    HTMLnote.Text += "  \n</button>\n";

                }
                else if(de.MyUI is MyTextBox)
                    {
                        MyTextBox be = de.MyUI as MyTextBox;
                        HTMLnote.Text += " <textbox type=" + '\u0022' + "textbox" + '\u0022' + ">\n   ";
                        HTMLnote.Text += "   " + be.UIName;
                        
                        HTMLnote.Text += "  \n</textbox>\n";
                    }
            }
            else            HTMLnote.Text += "     </body>\n</html>";

        }
        
    }
}
