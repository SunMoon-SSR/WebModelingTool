using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace WPFDesigner
{
    public class UI_EventArgs :EventArgs
    {
        public string type { get; set; }
        public int trackNum { get; set; }

        public int position { get; set; }

        public UIElement ui_Element { get; set; }
        public int[] msg { get; set; }
        public int dataLen { get; set; }
        public byte[] data { get; set; }
    }
    public enum ButtonEvents
    {
        Click,UnClick,MoseUp,MouseDown,DragOver,Visable
    }

    public class UI_ButtonEvent : UI_EventArgs
    {
        private readonly int constEnumCount = Enum.GetNames(typeof(ButtonEvents)).Length;
        public bool[] buttonEventMask { get; set; }
        public UI_ButtonEvent(ButtonEvents btevent)
        {
        buttonEventMask = new bool[constEnumCount];
        }
    }
    public enum TextBoxEvents
    {
        Click, UnClick, MoseUp, MouseDown, Mouse, DragOver,Readonly,Visable
    }
    public class UI_TextBoxEvent : UI_EventArgs
    {


        private readonly int constEnumCount = Enum.GetNames(typeof(TextBoxEvents)).Length;
        public bool[] TextBoxEventMask { get; set; }
        public UI_TextBoxEvent(TextBoxEvents ievent)
        {
            TextBoxEventMask = new bool[constEnumCount];
        }
      
    }
    public enum JPGEvents
    {
      MoseUp, MouseDown, Mouse, DragOver, Visable
    }
    public class UI_JPGEvent : UI_EventArgs
    {

        private readonly int constEnumCount = Enum.GetNames(typeof(JPGEvents)).Length;
        public bool[] UI_JPGEventMask { get; set; }
        public UI_JPGEvent(UI_JPGEvent ievent)
        {
            UI_JPGEventMask = new bool[constEnumCount];
        }
  
    }
    public enum RadioButtonEvents
    {
        Click, UnClick, MoseUp, MouseDown, Mouse, DragOver, MultiCheck, Visable
    }
    public class UI_RadioButtonEvent : UI_EventArgs
    {

        private readonly int constEnumCount = Enum.GetNames(typeof(RadioButtonEvents)).Length;
        public bool[] UI_RadioButtonEventMask { get; set; }
        public UI_RadioButtonEvent(RadioButtonEvents ievent)
        {
            UI_RadioButtonEventMask = new bool[constEnumCount];
        }

    }
    public enum CheckBoxEvents
    {
        Click, UnClick, MoseUp, MouseDown, Mouse, DragOver, MultiCheck, Visable
    }
    public class UI_CheckBoxEvent : UI_EventArgs
    {
        private readonly int constEnumCount = Enum.GetNames(typeof(CheckBoxEvents)).Length;
        public bool[] UI_CheckBoxEventMask { get; set; }
        public UI_CheckBoxEvent(CheckBoxEvents ievent)
        {
            UI_CheckBoxEventMask = new bool[constEnumCount];
        }

    }
}
