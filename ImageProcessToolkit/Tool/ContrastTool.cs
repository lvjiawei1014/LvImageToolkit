using OpenCvSharp;
using System;

namespace ImageProcessToolkit.Tool
{
    public class ContrastTool : ImageTool
    {
        private MatImage inputImage;
        private ImageRegion region;
        private double contrastResult;
        private double mean;
        private double std;

        private Mat mask;
        private Mat roiRect;

        public ImageRegion Region { get => region; set => region = value; }
        public double ContrastResult { get => contrastResult; set => contrastResult = value; }
        public double Mean { get => mean; set => mean = value; }
        public double Std { get => std; set => std = value; }
        public MatImage InputImage { get => inputImage; set => inputImage = value; }

        public override void Run()
        {
            if (inputImage == null || inputImage.Mat == null)
            {
                return;
            }
            try
            {
                Mat matMean =new Mat(new Size(1,1),MatType.CV_64FC1);
                Mat matStd = new Mat(new Size(1, 1), MatType.CV_64FC1);
                if (region == null)
                {
                    roiRect = inputImage.Mat;

                }
                else
                {
                    roiRect = RegionUtil.GetRoiRect(inputImage.Mat, this.region);

                }
                roiRect.MeanStdDev(matMean, matStd);
                this.mean = matMean.At<double>(0);
                this.std = matStd.At<double>(0);
                this.ContrastResult = std/mean;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
