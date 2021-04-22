using System.Drawing;
using System.Drawing.Drawing2D;

namespace StaticHelper
{
    public static class DrawCommonHelper
    {
        private static GraphicsPath DrawRoundRect(int x, int y, int width, int height, int radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.StartFigure();
            gp.AddArc(x, y, radius, radius, 180, 90);
            gp.AddArc(width - radius, y, radius, radius, 270, 90);
            gp.AddArc(width - radius, height - radius, radius, radius, 0, 90);
            gp.AddArc(x, height - radius, radius, radius, 90, 90);
            gp.CloseAllFigures();
            return gp;
        }

        public static GraphicsPath GetRoundRect(this Rectangle rect, int radius)
        {
            int x = rect.X;
            int y = rect.Y;
            int width = rect.Width;
            int height = rect.Height;
            return DrawRoundRect(x, y, width, height, radius);
        }
    }
}
