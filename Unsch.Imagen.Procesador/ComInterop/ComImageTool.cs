﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Unsch.Imagen.Procesador.ComInterop
{
    [Guid("221de9e9-852a-4a8a-bba7-b9727a8a155d")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("XnaFan.ImageComparison.ImageTool")]
    public class ComImageTool : _ImageTool
    {
        public float GetPercentageDifference(string image1Path, string image2Path, byte threshold)
        {
            return ImageTool.GetPercentageDifference(image1Path, image2Path, threshold);
        }
    }
}
