using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public class CommonProperties
    {
        public static bool drawing = false;
        public static Color paintColor = Color.Brown;
        public static Item currItem = Item.None;
        public enum Item
        {
            Rectangle, Ellipse, Line, Text, Brush, Pencil, eraser, ColorPicker, None
        }
        CommonProperties()
        {
            drawing = false;
        }
    }
}
