using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPFDesigner
{
    public class UIElement
    {
        public struct Font
        {
            public string FName { get; set; }
            public string Bold { get; set; }
            public int Size { get; set; }
            public Font(string name,string bold, int size)
            {
                FName = name;
                Bold = bold;
                Size = size;
            }
        }

        public string UIName { get; set; }

        public DesignerComponent DesignerComponent
        {
            get => default(DesignerComponent);
            set
            {
            }
        }


        Font myfont;
        
        public UIElement(string uiname,string fontname,string bold, int pontsize)
        {
            myfont = new Font(fontname, bold, pontsize);
            this.UIName = uiname;
        }
    }
}
