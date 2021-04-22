using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace StaticHelper
{
    public struct FormUI : IUIStyle
    {
        public Color CommonColor => "#e6e9ef".ToColor();

        public Color DivisionColor => throw new NotImplementedException();

        public Color BackgroundColor => "#f5f6f9".ToColor();

        public Color SecondBgColor => "#734a20".ToColor();

        public Color BorderColor => throw new NotImplementedException();

        public Color SelectDefaultColor => throw new NotImplementedException();

        public Color SelectedColor => "#9d6731".ToColor();

        public Color TextColor => Color.White;

        public Color DescribeColor => throw new NotImplementedException();

        public Color LeftColor => throw new NotImplementedException();

        public Color RightColor => throw new NotImplementedException();

        public Color TopColor => throw new NotImplementedException();

        public Color BottomColor => throw new NotImplementedException();
    }
}
