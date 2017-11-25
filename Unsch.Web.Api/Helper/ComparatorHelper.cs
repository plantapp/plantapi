using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Unsch.Imagen.Procesador;

namespace Unsch.Web.Api.Helper
{
    public class ComparatorHelper
    {
        public static float Compare(string Image1b64, string Image2b64, byte threshold = 3)
        {
            Bitmap firstBmp = (Bitmap)Base64ToImage(Image1b64);
            Bitmap secondBmp = (Bitmap)Base64ToImage(Image2b64);
            firstBmp.GetDifferenceImage(secondBmp, true);
            float method1 = firstBmp.PercentageDifference(secondBmp, threshold) * 100F;
            float method2 = firstBmp.BhattacharyyaDifference(secondBmp) * 100F;
            if (method1 < method2) { return method1; } else { return method2; }
        }
        public static Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
    }
}
