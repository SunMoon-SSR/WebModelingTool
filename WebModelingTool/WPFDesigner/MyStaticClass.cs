using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFDesigner
{
    public static class MyStaticClass
    {
        public static  Designer de = new Designer();
        public static UserControlList ul= new UserControlList(de);
        public static  UserControlProperty ucp = new UserControlProperty();
        public static List<DesignerComponent> DesignElement = null;
        
        
    }
    public enum MYUI
    {
        
    }

}
