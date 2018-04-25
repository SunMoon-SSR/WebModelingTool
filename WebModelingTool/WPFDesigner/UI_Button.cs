using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFDesigner
{
   
    public class UI_Button : UIElement
    {
        public delegate void ButtonClickEventHandler();
        public delegate void ButtonMoseUpEventHandler();
        public delegate void ButtonMouseDownEventHandler();
        public delegate void ButtonDragOverHandler();
        /// <summary>
        /// .버튼에 대한 클래스 초기화
        /// </summary>
        public UI_Button(string uiname, string fontname, string bold, int pontsize) :base(uiname,fontname,bold,pontsize)
        {
            
        }
    }
}
