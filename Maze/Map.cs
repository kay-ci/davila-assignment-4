using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class Map : IMap
    {
        public MapVector Goal { get; set; }
        public int Width { get; set; }

        public int Height { get; set; }

        public bool IsGameFinished { get; set; }

        public Block[,] MapGrid {get; set;}

        public IPlayer Player {get; set;}
        private readonly IMapProvider MapProvider;
        private Direction [,] _directionMaze { get; set; }

        public Map(IMapProvider mapProvider)
        {
            MapProvider = mapProvider;
            _directionMaze = MapProvider.CreateMap();
        }

        public void CreateMap()
        {
            Height = _directionMaze.GetLength(0)*2+1;
            Width = _directionMaze.GetLength(1)*2+1;

            MapGrid = new Block[Height, Width];

            //setting to solid block 
            for (int y = 0; y < Height; y++) { 
                for(int x = 0; x < Width; x++)
                {
                    MapGrid[y, x] = Block.Solid;
                }
                Console.WriteLine("\n");
            }
            for (int y = 0; y < _directionMaze.GetLength(0); y++) {
                for (int x = 0; x < _directionMaze.GetLength(1); x++)
                {
                    int mapGridX = x * 2 + 1;
                    int mapGridY = y * 2 + 1;

                    MapGrid[mapGridY,mapGridX] = Block.Empty;

                    Direction currentLocation = _directionMaze[y, x];

                    if ((currentLocation & Direction.E) > 0)
                    {
                        MapGrid[mapGridY, mapGridX+1] = Block.Empty;
                    }
                    if ((currentLocation & Direction.S) > 0)
                    {
                        MapGrid[mapGridY + 1, mapGridX] = Block.Empty;
                    }
                }
            }

            PrintMaze();
            Console.WriteLine();
        }

        public void CreateMap(int width, int height)
        {
            throw new NotImplementedException();
        }

        public void SaveDirectionMap(string path)
        {
            throw new NotImplementedException();
        }

        public void PrintMaze()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (MapGrid[y, x] == Block.Empty)
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.Write("X ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
