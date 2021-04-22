using StaticHelper;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace UIControls
{
    public partial class MenuItemPanel : UserControl
    {
        private MenuItemPanelInfo[] _items = null;
        private int _iSelectIndex = -1;
        private IUIStyle uiStyle = null;

        [Category("自定义属性"), Description("选项值集合"), Browsable(true)]
        public MenuItemPanelInfo[] Items
        {
            get { return _items; }
            set { _items = value; }
        }

        [Category("自定义属性"), Description("控件风格"), Browsable(true)]
        public IUIStyle UiStyle
        {
            get { return uiStyle; }
            set { uiStyle = value; }
        }

        public MenuItemPanel()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            this.DoubleBuffered = true;
            this.Cursor = Cursors.Hand;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _iSelectIndex = -1;
            this.Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_items == null)
                return;
            int index = 0;
            _iSelectIndex = -1;
            foreach (MenuItemPanelInfo item in _items)
            {
                Rectangle rect = new Rectangle(index * item.Width, 0, item.Width, Height);
                if (rect.Contains(e.Location))
                    _iSelectIndex = index;
                index++;
            }
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            DrawItems(g);
        }

        private void DrawItems(Graphics g)
        {
            if (_items == null)
                return;
            int index = 0;
            foreach (MenuItemPanelInfo item in _items)
            {
                int left = item.Width * index;
                Rectangle iconRect = new Rectangle(60 + left, 12, item.Region.Size, item.Region.Size);
                if (_iSelectIndex == index)
                {
                    Rectangle bgRect = iconRect;
                    bgRect.Inflate(3, 3);
                    using (Brush bg = uiStyle.SelectedColor.ToBrush())
                    {
                        g.FillRectangle(bg, bgRect);
                    }
                }
                g.DrawImage(VTLabIcons.Icon, iconRect, item.Region.SrcRect.Value, GraphicsUnit.Pixel);
                using (Brush bg = uiStyle.TextColor.ToBrush())
                {
                    SizeF fontSize = g.MeasureString(item.Name, Font);
                    g.DrawString(item.Name, Font, bg, left + (item.Width - fontSize.Width) / 2, (Height - fontSize.Height) / 2 + 8);
                }
                using (Brush bg = uiStyle.DescribeColor.ToBrush())
                {
                    using (Font font = new Font(Font.FontFamily, Font.Size - 2))
                    {
                        SizeF fontSize = g.MeasureString(item.Describe, font);
                        g.DrawString(item.Describe, font, bg, left + (item.Width - fontSize.Width) / 2 + 3, Height - fontSize.Height - 5);
                    }
                }
                left += item.Width;
                using (Pen pen = new Pen(uiStyle.DivisionColor))
                {
                    g.DrawLine(pen, left, 10, left, Height);
                }
                index++;
            }
        }



    }
}
