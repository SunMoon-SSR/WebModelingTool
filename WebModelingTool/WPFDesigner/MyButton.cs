using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFDesigner
{
    public class MyButton : UIElement
    {
        /// <summary>
        /// .버튼에 대한 클래스 초기화
        /// </summary>
        public MyButton(string uiname, string fontname, string bold, int pontsize) :base(uiname,fontname,bold,pontsize)
        {
            
        }
    }
}
