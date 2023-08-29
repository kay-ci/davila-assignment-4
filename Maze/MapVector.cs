using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class MapVector : IMapVector
    {
        public bool IsValid { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public bool InsideBoundary(int width, int height)
        {
            throw new NotImplementedException();
        }

        public double Magnitude()
        {
            throw new NotImplementedException();
        }
    }
}
