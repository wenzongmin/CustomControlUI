using StaticHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace VTLab
{
    public partial class MoveForm : PaintForm
    {
        /// <summary>
        /// 鼠标移动位置变量
        /// </summary>
        Point mouseOff;

        /// <summary>
        /// 标签是否为左键
        /// </summary>
        bool leftFlag;

        public MoveForm()
        {
            InitializeComponent();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button != MouseButtons.Left)
                return;
            if (!TitleRect.Contains(e.Location))
                return;
            if (DetectionMousePoint(e.Location))
            {
                ManageFormState();
                return;
            }
            mouseOff = new Point(-e.X, -e.Y);
            leftFlag = true;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                //设置移动后的位置
                mouseSet.Offset(mouseOff.X, mouseOff.Y);
                Location = mouseSet;
                return;
            }
            if (TitleRect.Contains(e.Location))
            {
                DetectionMousePoint(e.Location);
                this.Invalidate(TitleRect);
                return;
            }
        }


        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (leftFlag)
            {
                //释放鼠标后标注为false;
                leftFlag = false;
            }
        }

        private void ManageFormState()
        {
            if (CurrentClickType == BtnClickType.Close)
            {
                this.Close();
            }
            else if (CurrentClickType == BtnClickType.Max)
            {
                SelectRect.Width = 0;
                WindowState = (WindowState & FormWindowState.Maximized) > 0 ?
                    FormWindowState.Normal : FormWindowState.Maximized;
                this.Invalidate();
            }
            else if (CurrentClickType == BtnClickType.Min)
            {
                SelectRect.Width = 0;
                WindowState = FormWindowState.Minimized;
            }
        }
    }
}
