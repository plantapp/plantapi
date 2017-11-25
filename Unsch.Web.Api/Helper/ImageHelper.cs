using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Unsch.Web.Api.Helper
{
    public class ImageHelper
    {
        public static string getImage(string Image)
        {
            return $"data:{"image/png"};base64,{Image}";
        }
        public static string imageToString(string urlImage)
        {
            var base64Img = new Base64Image
            {
                FileContents = File.ReadAllBytes(urlImage),
                ContentType = "image/png"
            };
            return base64Img.ToString();

        }
        public static string fGetImage(string urlImage)
        {
            byte[] imageArray = System.IO.File.ReadAllBytes(urlImage);
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
            return base64ImageRepresentation;
        }
        public static System.Drawing.Image Base64ToImage(string Imagen)
        {
            byte[] imageBytes = Convert.FromBase64String(Imagen);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }
    }
}
