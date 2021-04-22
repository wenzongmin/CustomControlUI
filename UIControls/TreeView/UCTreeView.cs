using StaticHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UIControls
{
    public sealed partial class UCTreeView: TreeView
    {
        private IUIStyle uiStyle = null;

        [Category("自定义属性"), Description("控件风格"), Browsable(true)]
        public IUIStyle UiStyle
        {
            get { return uiStyle; }
            set { uiStyle = value; }
        }

        public UCTreeView()
        {
            DrawMode = TreeViewDrawMode.OwnerDrawAll;
            ItemHeight = 30;
            FullRowSelect = true;
            BorderStyle = BorderStyle.None;
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
            //    ControlStyles.Opaque | ControlStyles.UserPaint |
            //    ControlStyles.AllPaintingInWmPaint, true);
            //this.UpdateStyles();

        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //    using (Brush bg = uiStyle.BackgroundColor.ToBrush())
        //    {
        //        e.Graphics.FillRectangle(bg, e.ClipRectangle);
        //    }
        //    using (Pen pen = new Pen(uiStyle.BorderColor.ToBrush()))
        //    {
        //        e.Graphics.DrawRectangle(pen, 0, 0, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
        //    }
        //    DrawItems(e.Graphics, Nodes);
        //}

        //private void DrawItems(Graphics g, TreeNodeCollection nodes)
        //{
        //    foreach (TreeNode node in nodes)
        //    {
        //        drawTreeView(node, g);
        //        if (node.IsExpanded && node.GetNodeCount(true) > 0)
        //        {
        //            DrawItems(g, node.Nodes);
        //        }
        //    }
        //}


        //private void drawTreeView(TreeNode node, Graphics g)
        //{
        //    Brush bgBrush = Brushes.Red;
        //    if (SelectedNode == node)
        //    {
        //        bgBrush = uiStyle.SelectedColor.ToBrush();
        //    }
        //    g.FillRectangle(bgBrush, node.Bounds);
        //    //if (node.GetNodeCount(true) > 0)
        //    //{
        //    //    Rectangle iconRect;
        //    //    if (node.IsExpanded)
        //    //        iconRect = new Rectangle(640, 304, 85, 85);
        //    //    else
        //    //        iconRect = new Rectangle(520, 304, 85, 85);
        //    //    Rectangle destRect = new Rectangle(node.Bounds.X + 6, 6 + node.Bounds.Y, 18, 18);
        //    //    g.DrawImage(VTLabIcons.Icon, destRect, iconRect, GraphicsUnit.Pixel);
        //    //}
        //    //else
        //    //{
        //    //    g.DrawImage(VTLabIcons.Icon, new Rectangle(node.Bounds.X + 6 + ItemHeight, 6 + node.Bounds.Y, 18, 18), new Rectangle(520, 304, 85, 85), GraphicsUnit.Pixel);
        //    //}
        //    g.DrawString(node.Text, Font, Brushes.Black, node.Bounds.X, node.Bounds.Y + 9);
        //}

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            base.OnDrawNode(e);
            drawTreeView(e, e.Graphics);
        }

        private void drawTreeView(DrawTreeNodeEventArgs e, Graphics g)
        {
            bool selected = (e.State & TreeNodeStates.Selected) > 0;
            using (Brush bgBrush = (selected ? uiStyle.SelectedColor.ToBrush() :
                    uiStyle.SelectDefaultColor.ToBrush()))
            {
                g.FillRectangle(bgBrush, e.Bounds);
            }
            if (selected)
            {
                using (Brush leftbrush = uiStyle.LeftColor.ToBrush())
                {
                    g.FillRectangle(leftbrush, e.Bounds.X, e.Bounds.Y, 2, e.Bounds.Height);
                }
            }
            if (e.Node.GetNodeCount(true) > 0)
            {
                Rectangle iconRect;
                if (e.Node.IsExpanded)
                    iconRect = new Rectangle(400, 400, 16, 16);
                else
                    iconRect = new Rectangle(374, 400, 16, 16);
                Rectangle destRect = new Rectangle(e.Bounds.X + 6, 6 + e.Bounds.Y, 16, 16);
                g.DrawImage(VTLabIcons.Icon, destRect, iconRect, GraphicsUnit.Pixel);
            }
            else
            {
                g.DrawImage(VTLabIcons.Icon, new Rectangle(e.Bounds.X + 6 + ItemHeight, 6 + e.Bounds.Y, 18, 18), new Rectangle(520, 304, 85, 85), GraphicsUnit.Pixel);
            }
            g.DrawString(e.Node.Text, Font,
            Brushes.Black, e.Bounds.X + ItemHeight * (e.Node.Level + 1), e.Bounds.Y + 7);
        }
    }
}
