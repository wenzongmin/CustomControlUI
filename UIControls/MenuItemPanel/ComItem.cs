using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace UIControls
{
    public partial class ComItem : Component
    {
        public ComItem()
        {
            InitializeComponent();
        }

        public ComItem(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
    }
}
