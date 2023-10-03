using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class Player : IPlayer
    {
        public Direction Facing { get; private set; }

        public MapVector Position { get; private set; }

        public int StartX { get; private set; }

        public int StartY { get; private set; }
        private Block[,] _mapGrid { get; }

        public Player(int x, int y, Block[,] mapGrid)
        {
            StartX = x;
            StartY = y;
            Facing = Direction.N;
            Position = new MapVector(x, y);
            _mapGrid = mapGrid;
        }

        public float GetRotation()
        {
            float rotationRadians = 0.0f;
            switch (Facing)
            {
                case Direction.N:
                    rotationRadians = 0.0f;
                    break;
                case Direction.E:
                    rotationRadians = (float)(Math.PI / 2);
                    break;
                case Direction.S:
                    rotationRadians = (float)Math.PI;
                    break;
                case Direction.W:
                    rotationRadians = (float)(3 * Math.PI / 2);
                    break;
                case Direction.None:
                    throw new InvalidOperationException();
            }
            return rotationRadians;
        }

        public void MoveBackward()
        {
            MapVector newPosition = Position - (MapVector)Facing;
            if (IsValidMove(newPosition))
            {
                Position = newPosition;
            } 
        }

        public void MoveForward()
        {
            MapVector newPosition = Position + (MapVector)Facing;
            if (IsValidMove(newPosition)) {
                Position = newPosition;
            }
        }

        public void TurnLeft()
        {
            switch (Facing)
            {
                case Direction.N:
                    Facing = Direction.W; 
                    break;
                case Direction.W:
                    Facing = Direction.S;
                    break;
                case Direction.S:
                    Facing = Direction.E;
                    break;
                case Direction.E:
                    Facing = Direction.N;
                    break;
                case Direction.None:
                    throw new InvalidOperationException();
            }
        }

        public void TurnRight()
        {
            switch (Facing)
            {
                case Direction.N:
                    Facing = Direction.E;
                    break;
                case Direction.W:
                    Facing = Direction.N;
                    break;
                case Direction.S:
                    Facing = Direction.W;
                    break;
                case Direction.E:
                    Facing = Direction.S;
                    break;
                case Direction.None:
                    throw new InvalidOperationException();
            }
        }
        public bool IsValidMove(MapVector newPosition)
        {
            if(!newPosition.InsideBoundary(_mapGrid.GetLength(1), _mapGrid.GetLength(0)))
            {
                return false;
            }
            if (_mapGrid[newPosition.Y, newPosition.X] == Block.Solid)
            {
                return false;
            }
            return true;
        }
    }
}
