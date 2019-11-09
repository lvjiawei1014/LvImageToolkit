using OpenCvSharp;

namespace ImageProcessToolkit
{
    public class MatImage
    {
        private Mat mat;

        public Mat Mat { get => mat; set => mat = value; }


    }


    public class ImageRegion { }

    public class RectRegion : ImageRegion
    {
        private int x1;
        private int y1;
        private int x2;
        private int y2;

        public int X1 { get => x1; set => x1 = value; }
        public int Y1 { get => y1; set => y1 = value; }
        public int X2 { get => x2; set => x2 = value; }
        public int Y2 { get => y2; set => y2 = value; }
    }

    public class RegionUtil
    {
        public static Mat CreateMask(Mat mat, ImageRegion region)
        {
            Mat mask = Mat.Zeros(mat.Size(), MatType.CV_8UC1);
            switch (region)
            {
                case RectRegion rect when region is RectRegion:
                    mask[rect.Y1, rect.Y2, rect.X1, rect.X2].SetTo(1);
                    break;
                default:
                    break;
            }


            return mask;
        }

        /// <summary>
        /// 创建最小的包含region的submat
        /// </summary>
        /// <param name="src"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        public static Mat GetRoiRect(Mat src, ImageRegion region)
        {
            Mat rectRoi = null;
            switch (region)
            {
                case RectRegion rect when region is RectRegion:
                    rectRoi = src[rect.Y1, rect.Y2, rect.X1, rect.X2];
                    break;
                default:
                    break;
            }


            return rectRoi;
        }
    }

}
