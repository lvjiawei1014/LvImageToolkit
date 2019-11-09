using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessToolkit.Tool
{
    /// <summary>
    /// 图像处理工具基类
    /// </summary>
    public class ImageProcessTool : ImageTool
    {

        private MatImage inputImage;
        private MatImage outputImage;
        private bool result;

        public MatImage InputImage { get => inputImage; set => inputImage = value; }
        public MatImage OutputImage { get => outputImage; set => outputImage = value; }
        public bool Result { get => result; set => result = value; }

        public override void Run()
        {
            throw new NotImplementedException();
        }

        public virtual void  Reset()
        {
            this.result = false;
            this.inputImage = null;
            this.outputImage = null;
        }
    }

    /// <summary>
    /// 图像处理工具集和
    /// </summary>
    public class ImageProcessToolModel:ImageProcessTool
    {
        private List<ImageProcessTool> tools = new List<ImageProcessTool>();

        public List<ImageProcessTool> Tools { get => tools; set => tools = value; }

        public void Add(ImageProcessTool imageProcessTool)
        {
            this.Tools.Add(imageProcessTool);
        }

        public override void Run()
        {
            if(this.InputImage==null || this.InputImage.Mat == null)
            {
                this.Result = false;

            }
            else
            {
                MatImage tmp = this.InputImage;
                for (int i = 0; i < Tools.Count; i++)
                {
                    Tools[i].InputImage = tmp;
                    Tools[i].Run();
                    tmp = Tools[i].OutputImage;
                }
                this.OutputImage = tmp;
            }
        }
    }

    /// <summary>
    /// 高斯滤波工具
    /// </summary>
    public class GaussFilterTool : ImageProcessTool
    {
        private double sigma = 1;

        public double Sigma { get => sigma; set => sigma = value; }

        public GaussFilterTool(double sigma)
        {
            this.sigma = sigma;
        }

        public override void Run()
        {
            if (this.InputImage==null)
            {
                this.Result = false;
            }
            else 
            {
                try
                {
                    this.InputImage.Mat=this.InputImage.Mat.GaussianBlur(new OpenCvSharp.Size(0,0), this.sigma);
                    this.OutputImage = this.InputImage;
                    this.Result = true;
                }
                catch (Exception)
                {
                    this.Result = false;
                    throw;
                }
            }
        }
    }


}
