using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace StaticHelper
{
    public struct MenuItemUI : IUIStyle
    {
        public Color CommonColor => throw new NotImplementedException();

        public Color DivisionColor => "#DCE0E9".ToColor();

        public Color BackgroundColor => throw new NotImplementedException();

        public Color SecondBgColor => throw new NotImplementedException();

        public Color BorderColor => throw new NotImplementedException();

        public Color SelectDefaultColor => throw new NotImplementedException();

        public Color SelectedColor => "#F1F1F1".ToColor();

        public Color TextColor => "#34362F".ToColor();

        public Color DescribeColor => "#656568".ToColor();

        public Color LeftColor => throw new NotImplementedException();

        public Color RightColor => throw new NotImplementedException();

        public Color TopColor => throw new NotImplementedException();

        public Color BottomColor => throw new NotImplementedException();
    }
}
