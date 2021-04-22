using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace StaticHelper
{
    public sealed class StaticValueHelper
    {
        /// <summary>
        /// 窗体区域
        /// </summary>
        public readonly static int FormTitleHeight = 55;
        public readonly static int FormBorderWidth = 2;
        public readonly static int TitleTop = 12;

        public readonly static string SoftwareTitle = "SIMV&VER VTLAB";

        /// <summary>
        /// tab区域
        /// </summary>
        public readonly static int TabItemWidth = 110;
        public readonly static int TabItemHeight = 28;


        public readonly static MenuItemPanelInfo[] ModelSettingItems = new MenuItemPanelInfo[]
        {
            new MenuItemPanelInfo("模型信息","数字化模型库",150,new RegionValue(32,new Rectangle(10, 10, 32, 32))),
            new MenuItemPanelInfo("项目管理","虚拟热试验项目管理",150,new RegionValue(32,new Rectangle(52, 10, 32, 32))),
            new MenuItemPanelInfo("仿真模块","虚拟热试验仿真计算",150,new RegionValue(32,new Rectangle(94, 10, 32, 32)))
        };
    }

    public struct MenuItemPanelInfo
    {
        public MenuItemPanelInfo(string name, string desc, int width, RegionValue region)
        {
            this.Name = name;
            this.Describe = desc;
            this.Region = region;
            this.Width = width;
            this.IsSelected = false;
        }

        public string Name;
        public string Describe;
        public int Width;
        public RegionValue Region;

        public bool IsSelected;
    }
}
