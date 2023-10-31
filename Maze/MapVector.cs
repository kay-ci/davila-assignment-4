using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class MapVector : IMapVector
    {
        public bool IsValid { get; private set; }

        public int X { get; private set; }

        public int Y { get; private set; }
        public MapVector(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public bool InsideBoundary(int width, int height)
        {
            bool valid = false;
            if (X >= 0 && Y >= 0 && X < width && Y < height)
            {
                valid = true;
            }
            else
            {
                valid = false;
            }
            return valid;

        }

        public double Magnitude()
        {
            double magnitude = Math.Sqrt(X * X + Y * Y);
            return magnitude;
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
            if (d == Direction.N)
            {
                convertedDirection = new MapVector(0, -1);
            }
            else if(d == Direction.E)
            {
                convertedDirection = new MapVector(1, 0);
            }
            else if (d == Direction.S)
            {
                convertedDirection = new MapVector(0, 1);
            }
            else if (d == Direction.W)
            {
                convertedDirection = new MapVector(-1, 0);
            }
            else
            {
                convertedDirection = new MapVector(0, 0);
            }
            return convertedDirection;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            MapVector other = (MapVector)obj;
            return X == other.X && Y == other.Y;
        }

    }
}
