using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace StaticHelper
{
    public interface IUIStyle
    {
        Color CommonColor { get; }

        /// <summary>
        /// 分割线颜色
        /// </summary>
        Color DivisionColor { get; }

        /// <summary>
        /// 背景颜色
        /// </summary>
        Color BackgroundColor { get; }

        /// <summary>
        /// 二级背景颜色
        /// </summary>
        Color SecondBgColor { get; }

        /// <summary>
        /// 边框颜色
        /// </summary>
        Color BorderColor { get; }


        /// <summary>
        /// 未选中颜色
        /// </summary>
        Color SelectDefaultColor { get; }


        /// <summary>
        /// 选中颜色
        /// </summary>
        Color SelectedColor { get; }


        /// <summary>
        /// 主文本颜色
        /// </summary>
        Color TextColor { get; }


        /// <summary>
        /// 描述文本颜色
        /// </summary>
        Color DescribeColor { get; }


        /// <summary>
        /// 左边框颜色
        /// </summary>
        Color LeftColor { get; }


        /// <summary>
        /// 右边框颜色
        /// </summary>
        Color RightColor { get; }


        /// <summary>
        /// 顶部边框颜色
        /// </summary>
        Color TopColor { get; }


        /// <summary>
        /// 底部边框颜色
        /// </summary>
        Color BottomColor { get; }

    }
}
