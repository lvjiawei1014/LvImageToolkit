using System.Collections.Generic;

namespace ImageProcessToolkit.Tool
{
    public class ImageFileTool:ImageTool
    {
        public delegate void ContentChangedHandler(object sender);
        public event ContentChangedHandler ContentChanged;

        public delegate void ItemSelectedHandler(object sender, MatImage matSelected);
        public event ItemSelectedHandler ItemSelected;


        List<MatImage> mats = new List<MatImage>();

        public List<MatImage> Mats { get => mats; }

        public MatImage SelectedItem { get; set; } = null;

        public void Add(MatImage matImage)
        {
            this.mats.Add(matImage);
            this.ContentChanged?.Invoke(this);
        }

        public void Remove(int index)
        {
            if(index>=0&& index<this.mats.Count)
            {
                this.mats.RemoveAt(index);
                this.ContentChanged?.Invoke(this);
            }
        }


        public MatImage Select(int index)
        {
            if (index >= 0 && index < this.mats.Count)
            {
                this.ItemSelected?.Invoke(this, this.mats[index]);
                return this.mats[index];

            }
            return null;
        }

        public override void Run()
        {
            throw new System.NotImplementedException();
        }
    }
}
