using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class Player : IPlayer
    {
        public Direction Facing { get; set; }

        public MapVector Position { get; set; }

        public int StartX { get; set; }

        public int StartY { get; set; }

        public Player(int x, int y)
        {
            StartX = x;
            StartY = y;
            Facing = Direction.N;
            Position = new MapVector(x, y);
        }

        public float GetRotation()
        {
            throw new NotImplementedException();
        }

        public void MoveBackward()
        {
            throw new NotImplementedException();
        }

        public void MoveForward()
        {
            throw new NotImplementedException();
        }

        public void TurnLeft()
        {
            throw new NotImplementedException();
        }

        public void TurnRight()
        {
            throw new NotImplementedException();
        }
    }
}
