using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace StaticHelper
{
    public static class ColorCommonHelper
    {
        /// <summary>
        /// 获取过渡颜色值
        /// </summary>
        /// <param name="curIndex"></param>
        /// <param name="blockCount">总共分了多少块</param>
        /// <returns></returns>
        public static string[] GetTransitonColorValue(this int curIndex, int blockCount = 3)
        {
            if (curIndex == 0)
                return new string[] { "#1AB293", "#1EC0B3" };
            if (curIndex > blockCount)
                curIndex = blockCount;
            int fr = blockCount - curIndex;
            int[] A = new int[] { 43, 154, 255 };
            int[] B = new int[] { 72, 193, 242 };
            int len = blockCount - 1;
            List<string> list = new List<string>();
            for (int start = fr - 1; start < fr + 1; start++)
            {
                string hexVal = "#";
                for (int index = 0; index < 3; index++)
                {
                    int val = A[index] + ((B[index] - A[index]) * start) / len;
                    if (val < 10) hexVal += "0" + val.ToString();
                    else hexVal += val.ToString("X");
                }
                list.Add(hexVal);
            }
            return list.ToArray();
        }

        public static Color ToColor(this string strValue)
        {
            return ColorTranslator.FromHtml(strValue);
        }

        public static SolidBrush ToBrush(this Color color)
        {
            return new SolidBrush(color);
        }
    }
}
