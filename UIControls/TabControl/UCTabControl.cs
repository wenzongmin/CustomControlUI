using StaticHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace UIControls
{
    public sealed partial class UCTabControl : TabControl
    {
        private IUIStyle uiStyle = null;

        [Category("自定义属性"), Description("控件风格"), Browsable(true)]
        public IUIStyle UiStyle
        {
            get { return uiStyle; }
            set { uiStyle = value; }
        }

        public UCTabControl()
        {
            InitData();
        }

        public void InitData()
        {
            this.Width = 800;
            this.Height = 135;
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.SizeMode = TabSizeMode.Fixed;
            this.ItemSize = new Size(StaticValueHelper.TabItemWidth, StaticValueHelper.TabItemHeight);
            base.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor, true);
            base.UpdateStyles();
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            ResetRegion();
        }

        private void ResetRegion()
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddLine(2, 2, Width / 2, 2);
            path.AddLine(Width / 2, StaticValueHelper.TabItemHeight, Width, StaticValueHelper.TabItemHeight);
            path.AddLine(Width, Height, 2, Height);
            path.CloseFigure();
            this.Region = new Region(path);
        }
        
        
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            using (Brush bg1 = UiStyle.BackgroundColor.ToBrush())
            {
                g.FillRectangle(bg1, ClientRectangle);
            }
            using (Brush bg = UiStyle.SecondBgColor.ToBrush())
            {
                //绘制tab表头背景
                g.FillRectangle(bg, 0, 0, Width, StaticValueHelper.TabItemHeight - 1);
            }
            //绘制底线
            using (Pen pen = new Pen(UiStyle.BottomColor, 1))
            {
                int top = ClientRectangle.Height - 1;
                g.DrawLine(pen, 0, top, Width, top);
            }
            //绘制标头
            foreach (TabPage tp in this.TabPages)
            {
                Rectangle tabRect = this.GetTabRect(this.TabPages.IndexOf(tp));
                DrawTabPage(g, tabRect, tp);
            }
        }


        private void DrawTabPage(Graphics g, Rectangle rectangle, TabPage tp)
        {
            using (Brush bg1 = UiStyle.SelectDefaultColor.ToBrush())
            {
                using (Brush bg2 = UiStyle.SelectedColor.ToBrush())
                {
                    bool selected = SelectedTab != null && this.SelectedTab.Equals(tp);
                    SizeF fontSize = g.MeasureString(tp.Text, Font);
                    int top = (int)((rectangle.Height - fontSize.Height) / 2);
                    top = rectangle.Y + (top < 0 ? 0 : top);
                    g.FillRectangle(selected ? bg2 : bg1, rectangle);
                    int left = rectangle.X + (int)(rectangle.Width - fontSize.Width) / 2;
                    using (StringFormat sformat = new StringFormat())
                    {
                        sformat.LineAlignment = StringAlignment.Center;
                        sformat.Alignment = StringAlignment.Center;
                        g.DrawString(tp.Text, Font, selected ? bg1 : bg2, rectangle, sformat);
                    }
                }
            }
        }



        //protected override void OnDrawItem(DrawItemEventArgs e)
        //{
        //    base.OnDrawItem(e);
        //    Graphics g = e.Graphics;
        //    using (Brush bg1 = StaticColorHelper.TabDefaultBgColor.ToBrush())
        //    {
        //        using (Brush bg2 = StaticColorHelper.TabSelectedBgColor.ToBrush())
        //        {
        //            bool selected = (e.State & DrawItemState.Selected) > 0;
        //            SizeF fontSize = g.MeasureString(TabPages[e.Index].Text, Font);
        //            int top = (int)((e.Bounds.Height - fontSize.Height) / 2);
        //            top = e.Bounds.Y + (top < 0 ? 0 : top);
        //            g.FillRectangle(selected ? bg2 : bg1, e.Bounds);
        //            int left = e.Bounds.X + (int)(e.Bounds.Width - fontSize.Width) / 2;
        //            using (StringFormat sformat = new StringFormat())
        //            {
        //                sformat.LineAlignment = StringAlignment.Center;
        //                sformat.Alignment = StringAlignment.Center;
        //                e.Graphics.DrawString(TabPages[e.Index].Text, Font, selected ? bg1 : bg2, e.Bounds, sformat);
        //            }
        //        }
        //    }
        //}
    }

    public sealed partial class UCTabPage : TabPage
    {
        public UCTabPage()
        {
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            using (Brush bg1 = Color.White.ToBrush())
            {
                e.Graphics.FillRectangle(bg1, ClientRectangle);
            }
        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //    Graphics g = e.Graphics;
        //    g.FillRectangle(Brushes.Green, e.ClipRectangle);
        //}

    }
}
