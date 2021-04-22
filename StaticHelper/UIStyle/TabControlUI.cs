
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace StaticHelper
{
    public struct TabControlUI : IUIStyle
    {
        public Color CommonColor => "#e6e9ef".ToColor();

        public Color DivisionColor => throw new NotImplementedException();

        public Color BackgroundColor => Color.White;

        public Color SecondBgColor => "#734a20".ToColor();

        public Color BorderColor => throw new NotImplementedException();

        public Color SelectDefaultColor => "#9d6731".ToColor();

        public Color SelectedColor => "#ffffff".ToColor();

        public Color TextColor => throw new NotImplementedException();

        public Color DescribeColor => throw new NotImplementedException();

        public Color LeftColor => throw new NotImplementedException();

        public Color RightColor => throw new NotImplementedException();

        public Color TopColor => throw new NotImplementedException();

        public Color BottomColor => "#e6e9ef".ToColor();
    }
}
