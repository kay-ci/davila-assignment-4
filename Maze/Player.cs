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
        public Block[,] MapGrid { get; private set; }

        public Player(int x, int y, Block[,] mapGrid)
        {
            StartX = x;
            StartY = y;
            Facing = Direction.N;
            Position = new MapVector(x, y);
            MapGrid = mapGrid;
        }

        public float GetRotation()
        {
            throw new NotImplementedException();
        }

        public void MoveBackward()
        {
            MapVector newPosition = Position - (MapVector)Facing;
            if (IsValidMove(newPosition))
            {
                Position = newPosition;
            } 
            else
            {
                Position += 0;
            }
        }

        public void MoveForward()
        {
            MapVector newPosition = Position + (MapVector)Facing;
            if (IsValidMove(newPosition)) {
                Position = newPosition;
            }
            else
            {
                Position += 0;
            }
              
            
        }

        public void TurnLeft()
        {
            if (Facing == Direction.N)
            {
                Facing = Direction.W;
            }
            else if (Facing  == Direction.W)
            {
                Facing = Direction.S;
            }
            else if (Facing == Direction.S)
            {
                Facing = Direction.E;
            }
            else if (Facing == Direction.E)
            {
                Facing = Direction.N;
            }
        }

        public void TurnRight()
        {
            if (Facing == Direction.N)
            {
                Facing = Direction.E;
            }
            else if (Facing == Direction.E)
            {
                Facing = Direction.S;
            }
            else if (Facing == Direction.S)
            {
                Facing = Direction.W;
            }
            else if (Facing == Direction.W)
            {
                Facing = Direction.N;
            }
        }
        private bool IsValidMove(MapVector newPosition)
        {
            if(!newPosition.InsideBoundary(MapGrid.GetLength(1), MapGrid.GetLength(0)))
            {
                return false;
            }
            if (MapGrid[newPosition.Y, newPosition.X] == Block.Solid)
            {
                return false;
            }
            return true;
        }
    }
}
