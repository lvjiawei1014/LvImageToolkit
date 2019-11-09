using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ImageProcessToolkit.Tool;
using ImageProcessToolkit;

namespace LvImageToolkit
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        MatImage image;

        ContrastTool contrastTool;

        ImageProcessToolkit imageProcessToolkit;

        public MainWindow()
        {
            InitializeComponent();
            InitData();
        }
        public void InitData()
        {
            this.image = new MatImage();
            contrastTool = new ContrastTool();
            imageProcessToolkit=new ImageProcessToolkit()
        }

        internal MatImage Image { get => image; set => image = value; }

        private void mi_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "bmp|*.bmp";
            var result = openFileDialog.ShowDialog();
            if (result.HasValue && result.Value == true)
            {
                this.InitImage(openFileDialog.FileName);
            }
        }

        private void InitImage(string path)
        {
            var tmp = MatImageUtil.Import(path);
            if (tmp==null)
            {
                MessageBox.Show("导入文件失败");
            }
            else
            {
                this.image = tmp;
                //ivMain.Image
                siReso.Content = this.image.Mat.Width.ToString() + "*" + image.Mat.Height.ToString();
                var bitmap = MatImageUtil.MatToImageSource(this.image.Mat);
                this.ivMain.Image = bitmap.Clone();
                contrastTool.InputImage = this.image;
            }
        }

        private void btnContrastRun_Click(object sender, RoutedEventArgs e)
        {
            contrastTool.Run();
            labContrast.Content = contrastTool.ContrastResult.ToString("0.00000");
            labMean.Content = contrastTool.Mean.ToString();
            labStd.Content = contrastTool.Std.ToString();

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
