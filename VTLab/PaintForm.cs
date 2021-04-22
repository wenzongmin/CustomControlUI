using StaticHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace VTLab
{
    public enum BtnClickType
    {
        None = 1,
        Close = 2,
        Max = 4,
        Min = 8,
        Open = 16,
        Save = 32,
        New = 64
    }

    public partial class PaintForm : Form
    {
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams paras = base.CreateParams;
        //        paras.ExStyle |= 0x02000000;
        //        return paras;
        //    }
        //}

        protected Rectangle CloseRect, MaxRect, MaxNormalRect, MinRect, OpenRect, SaveRect, NewRect;
        protected Rectangle SelectRect;
        protected Rectangle TitleRect;
        protected BtnClickType CurrentClickType = BtnClickType.None;

        private IUIStyle uiStyle = null;

        [Category("自定义属性"), Description("控件风格"), Browsable(true)]
        public IUIStyle UiStyle
        {
            get { return uiStyle; }
            set { uiStyle = value; }
        }

        public PaintForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
            //    ControlStyles.Opaque | ControlStyles.UserPaint |
            //    ControlStyles.AllPaintingInWmPaint, true);
            //this.UpdateStyles();
        }

        protected bool DetectionMousePoint(Point point)
        {
            //Thread.Sleep(10);
            CurrentClickType = BtnClickType.None;
            SelectRect.Width = 0;
            if (CloseRect.Contains(point))
            {
                CurrentClickType = BtnClickType.Close;
                SelectRect = CloseRect;
            }
            else if (MaxRect.Contains(point))
            {
                CurrentClickType = BtnClickType.Max;
                SelectRect = MaxRect;
            }
            else if (MinRect.Contains(point))
            {
                CurrentClickType = BtnClickType.Min;
                SelectRect = MinRect;
            }
            else if (OpenRect.Contains(point))
            {
                CurrentClickType = BtnClickType.Open;
                SelectRect = OpenRect;
            }
            else if (SaveRect.Contains(point))
            {
                CurrentClickType = BtnClickType.Save;
                SelectRect = SaveRect;
            }
            else if (NewRect.Contains(point))
            {
                CurrentClickType = BtnClickType.New;
                SelectRect = NewRect;
            }
            if (SelectRect.Width > 0)
            {
                SelectRect.Inflate(5, 5);
            }
            return CurrentClickType != BtnClickType.None;
        }

        protected void InitButtonRegion()
        {
            CloseRect = new Rectangle(Width - StaticRectHelper.BtnClose.Right - StaticRectHelper.BtnClose.Size,
                StaticRectHelper.BtnClose.Top, StaticRectHelper.BtnClose.Size,
                StaticRectHelper.BtnClose.Size);
            MaxRect = new Rectangle(Width - StaticRectHelper.BtnMax.Right - StaticRectHelper.BtnClose.Size,
                StaticRectHelper.BtnMax.Top, StaticRectHelper.BtnMax.Size,
                StaticRectHelper.BtnMax.Size);
            MaxNormalRect = new Rectangle(Width - StaticRectHelper.BtnMaxNormal.Right - StaticRectHelper.BtnMaxNormal.Size,
                StaticRectHelper.BtnMaxNormal.Top, StaticRectHelper.BtnMaxNormal.Size,
                StaticRectHelper.BtnMaxNormal.Size);
            MinRect = new Rectangle(Width - StaticRectHelper.BtnMin.Right - StaticRectHelper.BtnClose.Size,
                StaticRectHelper.BtnMin.Top, StaticRectHelper.BtnMin.Size,
                StaticRectHelper.BtnMin.Size);

            OpenRect = new Rectangle(StaticRectHelper.BtnOpen.Left,
               StaticRectHelper.BtnOpen.Top, StaticRectHelper.BtnOpen.Size,
               StaticRectHelper.BtnOpen.Size);
            SaveRect = new Rectangle(StaticRectHelper.BtnSave.Left,
                StaticRectHelper.BtnSave.Top, StaticRectHelper.BtnSave.Size,
                StaticRectHelper.BtnSave.Size);
            NewRect = new Rectangle(StaticRectHelper.BtnNew.Left,
                StaticRectHelper.BtnNew.Top, StaticRectHelper.BtnNew.Size,
                StaticRectHelper.BtnNew.Size);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            InitButtonRegion();
            TitleRect = new Rectangle(0, 0, Width, StaticValueHelper.FormTitleHeight);
        }

        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == Win32.WM_ERASEBKGND)
        //        return;
        //    base.WndProc(ref m);
        //    if (m.Msg == Win32.WM_PAINT)
        //    {
        //        IntPtr hDC = Win32.GetWindowDC(m.HWnd);
        //        if (hDC.ToInt32() == 0)
        //        {
        //            return;
        //        }
        //        try
        //        {
        //            //绘制边框
        //            using (Graphics g = Graphics.FromHdc(hDC))
        //            {
        //                DrawForm(g);
        //                m.Result = IntPtr.Zero;
        //            }
        //        }
        //        finally
        //        {
        //            if (hDC != IntPtr.Zero)
        //            {
        //                Win32.ReleaseDC(m.HWnd, hDC);
        //            }
        //        }
        //    }
        //}

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            DrawForm(g);
        }

        private void DrawForm(Graphics g)
        {
            using (Brush bg = uiStyle.BackgroundColor.ToBrush())
            {
                g.FillRectangle(bg, 0, 0, Width, Height);
            }
            using (Brush bg = uiStyle.SecondBgColor.ToBrush())
            {
                g.FillRectangle(bg, 0, 0, Width, StaticValueHelper.FormTitleHeight);
            }
            if (SelectRect.Width > 0)
            {
                using (Brush bg = uiStyle.SelectedColor.ToBrush())
                {
                    g.FillRectangle(bg, SelectRect);
                }
            }
            g.DrawImage(VTLabIcons.Icon, CloseRect, StaticRectHelper.BtnClose.SrcRect.Value, GraphicsUnit.Pixel);
            if ((WindowState & FormWindowState.Maximized) > 0)
                g.DrawImage(VTLabIcons.Icon, MaxNormalRect, StaticRectHelper.BtnMaxNormal.SrcRect.Value, GraphicsUnit.Pixel);
            else
                g.DrawImage(VTLabIcons.Icon, MaxRect, StaticRectHelper.BtnMax.SrcRect.Value, GraphicsUnit.Pixel);
            g.DrawImage(VTLabIcons.Icon, MinRect, StaticRectHelper.BtnMin.SrcRect.Value, GraphicsUnit.Pixel);
            g.DrawImage(VTLabIcons.Icon, OpenRect, StaticRectHelper.BtnOpen.SrcRect.Value, GraphicsUnit.Pixel);
            g.DrawImage(VTLabIcons.Icon, SaveRect, StaticRectHelper.BtnSave.SrcRect.Value, GraphicsUnit.Pixel);
            g.DrawImage(VTLabIcons.Icon, NewRect, StaticRectHelper.BtnNew.SrcRect.Value, GraphicsUnit.Pixel);
            using (Brush fg = uiStyle.TextColor.ToBrush())
            {
                SizeF fontSize = g.MeasureString(StaticValueHelper.SoftwareTitle, Font);
                g.DrawString(StaticValueHelper.SoftwareTitle, Font, fg, (Width - fontSize.Width) / 2, 8);
            }
            using (Pen pen = new Pen(uiStyle.SecondBgColor, StaticValueHelper.FormBorderWidth))
            {
                g.DrawRectangle(pen, 0, 0, Width, Height);
            }
            //绘制风格
            using (Pen pen = new Pen(uiStyle.CommonColor))
            {
                g.DrawRectangle(pen, 10, 172, 240, Height - 172 - 12);
                g.DrawLine(pen, 10, 197, 250, 197);
                g.DrawImage(VTLabIcons.Icon, new Rectangle(182, 178, 60, 14),
                    new Rectangle(305, 10, 60, 14), GraphicsUnit.Pixel);
            }
            
        }
    }
}
