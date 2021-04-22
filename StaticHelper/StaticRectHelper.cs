using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace StaticHelper
{
    public sealed class StaticRectHelper
    {
        /// <summary>
        /// 关闭按钮
        /// </summary>
        public readonly static RegionValue BtnClose = new RegionValue(0, 15, 10, 0,
            srcRect: new Rectangle(140, 162, 16, 16), size: 16);

        /// <summary>
        /// 最大化按钮
        /// </summary>
        public readonly static RegionValue BtnMax = new RegionValue(0, 50, 10, 0,
            srcRect: new Rectangle(114, 162, 16, 16), size: 16);

        /// <summary>
        /// 正常化按钮
        /// </summary>
        public readonly static RegionValue BtnMaxNormal = new RegionValue(0, 50, 10, 0,
            srcRect: new Rectangle(348, 162, 16, 16), size: 16);

        /// <summary>
        /// 最小化按钮
        /// </summary>
        public readonly static RegionValue BtnMin = new RegionValue(0, 95, 10, 0,
           srcRect: new Rectangle(88, 162, 16, 16), size: 16);

        /// <summary>
        /// 加载按钮
        /// </summary>
        public readonly static RegionValue BtnOpen = new RegionValue(15, 15, 5, 0,
           srcRect: new Rectangle(166, 162, 16, 16), size: 16);


        /// <summary>
        /// 保存按钮
        /// </summary>
        public readonly static RegionValue BtnSave = new RegionValue(45, 45, 5, 0,
           srcRect: new Rectangle(192, 162, 16, 16), size: 16);

        /// <summary>
        /// 新增按钮
        /// </summary>
        public readonly static RegionValue BtnNew = new RegionValue(70, 70, 5, 0,
           srcRect: new Rectangle(218, 162, 16, 16), size: 16);
    }


    public struct RegionValue
    {
        public RegionValue(int left, int right, int top, int bottom, int size = 24, Rectangle? srcRect = null)
        {
            this.Left = left;
            this.Right = right;
            this.Top = top;
            this.Bottom = bottom;
            this.SrcRect = srcRect;
            this.Size = size;
        }

        public RegionValue(int size, Rectangle srcRect)
        {
            this.Left = 0;
            this.Right = 0;
            this.Top = 0;
            this.Bottom = 0;
            this.SrcRect = srcRect;
            this.Size = size;
        }


        public Rectangle? SrcRect;
        public int Size;
        public int Left;
        public int Right;
        public int Top;
        public int Bottom;


        public Rectangle GetOneselfRect()
        {
            return new Rectangle(0, 0, 0, 0);
        }
    }
}
