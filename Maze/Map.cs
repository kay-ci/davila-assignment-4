using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class Map : IMap
    {
        private Random _random { get; set; }
        public MapVector Goal { get; set; }
        public int Width { get; set; }

        public int Height { get; set; }

        public bool IsGameFinished { get; set; }

        public Block[,] MapGrid {get; set;}

        public IPlayer Player {get; set;}
        private readonly IMapProvider _mapProvider;
        public Direction [,] _directionMaze { get; set; }

        public Map(IMapProvider mapProvider)
        {
            _mapProvider = mapProvider;  
            _random = new();
        }

        public void CreateMap()
        {
            _directionMaze = _mapProvider.CreateMap();
            Height = _directionMaze.GetLength(0)*2+1;
            Width = _directionMaze.GetLength(1)*2+1;

            MapGrid = new Block[Height, Width];

            //Fill solid blocks
            for (int y = 0; y < Height; y++) { 
                for(int x = 0; x < Width; x++)
                {
                    MapGrid[y, x] = Block.Solid;
                }
            }

            //Fill path blocks
            GenerateMaze();

            //Create Player
            Player = CreatePlayer();

            //Create Goal
            int goalY;
            int goalX;

            while (true)
            {
                goalX = _random.Next(0, _directionMaze.GetLength(1));
                goalY = _random.Next(1, _directionMaze.GetLength(0));
                Goal = new MapVector(ToGrid(goalX), ToGrid(goalY));
                if(IsValidGoal(goalY, goalX)) {
                    break;
                }
            }
        }
        private void GenerateMaze()
        {
            for (int y = 0; y < _directionMaze.GetLength(0); y++)
            {
                for (int x = 0; x < _directionMaze.GetLength(1); x++)
                {
                    int mapGridX = x * 2 + 1;
                    int mapGridY = y * 2 + 1;

                    MapGrid[mapGridY, mapGridX] = Block.Empty;

                    Direction currentLocation = _directionMaze[y, x];

                    if (currentLocation.HasFlag(Direction.E))
                    {
                        MapGrid[mapGridY, mapGridX + 1] = Block.Empty;
                    }
                    if (currentLocation.HasFlag(Direction.S))
                    {
                        MapGrid[mapGridY + 1, mapGridX] = Block.Empty;
                    }
                }
            }
        }
        private Player CreatePlayer()
        {
            int posY;
            int posX;
            do{
                posY = _random.Next(1, Height - 1);
                posX = _random.Next(1, Width - 1);
            }while (MapGrid[posY, posX] != Block.Empty);

            return new Player(posX, posY, MapGrid);
        }
        private bool IsValidGoal(int goalY, int goalX) {
            if (MapGrid[ToGrid(goalY), ToGrid(goalX)] != Block.Solid)
            {
                Direction goalDir = _directionMaze[goalY, goalX];

                // If It is a power of two, then it has only one direction
                bool hasOneFlag = (goalDir & (goalDir - 1)) == 0; 
                if (hasOneFlag)
                {
                    double distance = (Goal - Player.Position).Magnitude();
                    if (distance >= ((new MapVector(Width, Height)).Magnitude() % 2))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private int ToGrid(int x)
        {
            return x * 2 + 1;
        }
        public void CreateMap(int width, int height)
        {
            throw new NotImplementedException();
        }

        public void SaveDirectionMap(string path)
        {
            throw new NotImplementedException();
        }
    }
}
