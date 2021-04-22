using StaticHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIControls;

namespace VTLab
{
    public partial class MainForm : MoveForm
    {
        UCTabControl tabControl = null;
        UCTreeView uCTreeView = null;
        public MainForm()
        {
            InitializeComponent();
            this.UiStyle = new FormUI();
            //WindowState = FormWindowState.Maximized;
            tabControl = new UCTabControl();
            tabControl.UiStyle = new TabControlUI();
            tabControl.Location = new Point(10, StaticValueHelper.FormTitleHeight - StaticValueHelper.TabItemHeight);
            UCTabPage tabPage1 = new UCTabPage();
            tabPage1.Text = "文件";
            MenuItemPanel panel = new MenuItemPanel();
            panel.UiStyle = new MenuItemUI();
            panel.Dock = DockStyle.Fill;
            panel.Items = StaticValueHelper.ModelSettingItems;
            tabPage1.Controls.Add(panel);
            tabControl.Controls.Add(tabPage1);
            UCTabPage tabPage2 = new UCTabPage();
            tabPage2.Text = "模型设置";
            tabControl.Controls.Add(tabPage2);
            UCTabPage tabPage3 = new UCTabPage();
            tabPage3.Text = "V&V流程";
            tabControl.Controls.Add(tabPage3);
            this.Controls.Add(tabControl);

            uCTreeView = new UCTreeView();
            uCTreeView.UiStyle = new TreeViewUI();
            uCTreeView.Height = 500;
            uCTreeView.Width = 238;
            uCTreeView.Location = new Point(11, 198);
            uCTreeView.Nodes.Add("img0", "测试信息测试信息");
            uCTreeView.Nodes[0].Nodes.Add("img1", "测试信息测试信息");
            uCTreeView.Nodes[0].Nodes.Add("img2", "测试信息测试信息");
            uCTreeView.Nodes[0].Nodes.Add("img3", "测试信息测试信息");
            uCTreeView.Nodes[0].Nodes.Add("img4", "测试信息测试信息");
            uCTreeView.Nodes.Add("img0", "测试信息测试信息");
            uCTreeView.Nodes[1].Nodes.Add("img1", "测试信息测试信息");
            uCTreeView.Nodes[1].Nodes.Add("img2", "测试信息测试信息");
            uCTreeView.Nodes[1].Nodes.Add("img3", "测试信息测试信息");
            uCTreeView.Nodes[1].Nodes.Add("img4", "测试信息测试信息");
            uCTreeView.Nodes.Add("img0", "测试信息测试信息");
            uCTreeView.Nodes[2].Nodes.Add("img1", "测试信息测试信息");
            uCTreeView.Nodes[2].Nodes.Add("img2", "测试信息测试信息");
            uCTreeView.Nodes[2].Nodes.Add("img3", "测试信息测试信息");
            uCTreeView.Nodes[2].Nodes.Add("img4", "测试信息测试信息");
            uCTreeView.Nodes.Add("img0", "测试信息测试信息");
            uCTreeView.Nodes[3].Nodes.Add("img1", "测试信息测试信息");
            uCTreeView.Nodes[3].Nodes.Add("img2", "测试信息测试信息");
            uCTreeView.Nodes[3].Nodes.Add("img3", "测试信息测试信息");
            uCTreeView.Nodes[3].Nodes.Add("img4", "测试信息测试信息");
            this.Controls.Add(uCTreeView);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (tabControl != null)
                tabControl.Width = Width - 12;
            if (uCTreeView != null)
                uCTreeView.Height = Height - 211;
        }
    }
}
