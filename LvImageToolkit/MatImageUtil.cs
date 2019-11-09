using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using OpenCvSharp;
using System.Windows.Media.Imaging;
using ImageProcessToolkit;

namespace LvImageToolkit
{
    class MatImageUtil
    {
        

        /// <summary>
        /// 导入图像
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static MatImage Import(string path)
        {
            Mat mat = null;
            if (path.EndsWith(".bmp") || path.EndsWith(".BMP"))
            {
                try
                {
                    mat = Cv2.ImRead(path,0);
                    return new MatImage() { Mat = mat };
                }
                catch (Exception)
                {
                    return null;
                }
            }

            return null;
        }

        public static ImageSource MatToImageSource(Mat mat)
        {
            if (mat == null )
            {
                return null;
            }
            int stride = (int)mat.Step();
            
            var bitmapImage = BitmapImage.Create(mat.Width, mat.Height, 96.0, 96.0, PixelFormats.Gray8, BitmapPalettes.Gray256, mat.Data, stride*mat.Height, stride);
            return bitmapImage;
        }


    }
}
