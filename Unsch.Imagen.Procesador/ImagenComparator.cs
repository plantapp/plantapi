using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Unsch.Imagen.Procesador
{
    public class ImagenComparator
    {
        public static float Compare(string bmp1, string bmp2, byte threshold = 3)
        {
            Bitmap firstBmp = (Bitmap)Image.FromFile(bmp1);
            Bitmap secondBmp = (Bitmap)Image.FromFile(bmp2);
            firstBmp.GetDifferenceImage(secondBmp, true);
            float method1 = firstBmp.PercentageDifference(secondBmp, threshold) * 100F;
            float method2 = firstBmp.BhattacharyyaDifference(secondBmp) * 100F;
            if (method1 < method2) { return method1; } else { return method2; }
        }
    }
}
