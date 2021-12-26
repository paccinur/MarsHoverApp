using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsHoverApp
{
    public class Field
    {
        public int VerticalSize { get; internal set; }   
        public int HorizontalSize { get; internal set; }   
        public List<Hover> Hovers { get; set; }

        public Field(int vSize, int hSize)
        {
            VerticalSize = vSize;
            HorizontalSize = hSize;
            Hovers = new List<Hover>();
        }
        public void AddHover(Hover hover)
        {
            Hovers.Add(hover);
        }
    }
}
