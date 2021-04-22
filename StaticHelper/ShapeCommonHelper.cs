using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StaticHelper
{
    public static class ShapeCommonHelper
    {
        public static void SetControlRect(this Control ctrl, int sideWidth = 2)
        {
            if (ctrl.IsHandleCreated == false)
                return;
            Rectangle rect = new Rectangle();
            Win32.SendMessage(ctrl.Handle, Win32.EM_GETRECT, IntPtr.Zero, ref rect);
            rect.X = ctrl.Location.X;
            rect.Y = ctrl.Location.Y;
            rect.Height = 50 - sideWidth;
            rect.Width = ctrl.Width - sideWidth;
            Win32.SendMessage(ctrl.Handle, Win32.EM_SETRECT, IntPtr.Zero, ref rect);
        }
    }
}
