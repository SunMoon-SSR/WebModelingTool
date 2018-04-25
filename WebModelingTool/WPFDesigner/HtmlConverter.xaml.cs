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
            //HTMLnote.Text += "<html>\n  <head>\n </head>\n  <body>\n";
            //if (frameworkElements != null)
            //    foreach (DesignerComponent de in frameworkElements)
            //    {
            //        if (de.MyUI is UI_Button)
            //        {
            //            UI_Button be = de.MyUI as UI_Button;
            //            HTMLnote.Text += " <button type=" + '\u0022' + "button" + '\u0022' + ">\n   ";
            //            HTMLnote.Text += "   " + be.UIName;
            //            HTMLnote.Text += "  \n</button>\n";

            //        }
            //        else if (de.MyUI is UI_TextBox)
            //        {
            //            UI_TextBox be = de.MyUI as UI_TextBox;
            //            HTMLnote.Text += " <textbox type=" + '\u0022' + "textbox" + '\u0022' + ">\n   ";
            //            HTMLnote.Text += "   " + be.UIName;

            //            HTMLnote.Text += "  \n</textbox>\n";
            //        }
            //    }
            //HTMLnote.Text += "  </body>\n</html>";
            HTMLnote.Text += "<html>\n<head>\n</head>\n<body>\n";
            if (frameworkElements != null)
                foreach (DesignerComponent de in frameworkElements)
                {
                    if (de.MyUI is UI_Button)
                    {
                        UI_Button be = de.MyUI as UI_Button;
                        HTMLnote.Text += "<button type="+'\u0022' + "button"+'\u0022'+ "size=" + '\u0022' + de.Width + '\u0022' +
                            "name=" + '\u0022' + be.UIName + '\u0022'
                            + "style=" + '\u0022' + "height:" + de.Height + "px" + '\u0022'+ ">\n";
                        HTMLnote.Text += "" + be.UIName;
                        HTMLnote.Text += "\n</button>\n";

                    }
                    else if (de.MyUI is UI_TextBox)
                    {
                        UI_TextBox be = de.MyUI as UI_TextBox;
                        HTMLnote.Text += "<input style=" + '\u0022' +"ime - mode:auto"+ '\u0022'+
                            "size=" +'\u0022'+ de.Width+'\u0022'+
                            "name="+'\u0022'+be.UIName+ '\u0022'
                            +"style="+'\u0022'+"height:"+ de.Height+"px"+'\u0022';
                        HTMLnote.Text += "</input>\n";
                    }
                }
            HTMLnote.Text += "</body>\n</html>\n";
            WebModelingStaticClass.TestWebBrowserData = HTMLnote.Text;
        }
        
    }
}
