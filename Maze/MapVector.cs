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
        public MapVector(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public bool InsideBoundary(int width, int height)
        {
            bool isInside = false;
            if (X > 0 || Y > 0 && X <= width || Y <=height)
            {
                isInside = true;
            }
            if (X > width || Y > height || X < 0 || Y < 0)
            {
                isInside = false;
            }
            return isInside;

        }

        public double Magnitude()
        {
            double magnitude = Math.Sqrt(X * X + Y * Y);
            return Math.Round(magnitude,2);
        }

        public static implicit operator MapVector(int x)
        {
            return new MapVector((int)x, (int)x);
        }

        public static MapVector operator +(MapVector v1, MapVector v2) 
        { 
            int x = v1.X + v2.X;
            int y = v1.Y + v2.Y;
            return new MapVector(x,y);
        }

        public static MapVector operator -(MapVector v1, MapVector v2)
        {
            int newX = v1.X - v2.X;
            int newY = v1.Y - v2.Y;
            return new MapVector(newX, newY);
        }

        public static MapVector operator *(MapVector v1, MapVector v2)
        {
            int newX = v1.X * v2.X;
            int newY = v1.Y * v2.Y;
            return new MapVector(newX, newY);
        }

        public static implicit operator MapVector(Direction d) {
            MapVector convertedDirection;
            if (d.HasFlag(Direction.N))
            {
                convertedDirection = new MapVector(1, 0);
            }
            else if(d.HasFlag(Direction.E))
            {
                convertedDirection = new MapVector(0, 1);
            }
            else if (d.HasFlag(Direction.S))
            {
                convertedDirection = new MapVector(-1, 0);
            }
            else if (d.HasFlag(Direction.W))
            {
                convertedDirection = new MapVector(0, -1);
            }
            else
            {
                convertedDirection = new MapVector(0, 0);
            }
            return convertedDirection;
        }
        
    }
}
