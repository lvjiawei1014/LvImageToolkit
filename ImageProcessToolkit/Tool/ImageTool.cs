using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessToolkit.Tool
{
    public abstract class ImageTool
    {
        private string name = "";

        public string Name { get => name; set => name = value; }

        public abstract void Run();
    }
}
