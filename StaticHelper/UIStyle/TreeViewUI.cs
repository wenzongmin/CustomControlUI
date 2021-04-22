using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace StaticHelper
{
    public struct TreeViewUI : IUIStyle
    {
        public Color CommonColor => throw new NotImplementedException();

        public Color DivisionColor => throw new NotImplementedException();

        public Color BackgroundColor => Color.White;

        public Color SecondBgColor => throw new NotImplementedException();

        public Color BorderColor => "#D7DCE6".ToColor();

        public Color SelectDefaultColor => Color.White;

        public Color SelectedColor => "#EFD2B3".ToColor();

        public Color TextColor => throw new NotImplementedException();

        public Color DescribeColor => throw new NotImplementedException();

        public Color LeftColor => "#C4711E".ToColor();

        public Color RightColor => throw new NotImplementedException();

        public Color TopColor => throw new NotImplementedException();

        public Color BottomColor => throw new NotImplementedException();
    }
}
