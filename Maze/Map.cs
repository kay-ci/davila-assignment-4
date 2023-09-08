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
        public IMapProvider MapProvider { get; set;}
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
            for (int y = 0; y < Width; y++) { 
                for(int x = 0; x < Height; x++)
                {
                    MapGrid[y, x] = Block.Solid;
                    Console.Write(MapGrid[x,y]+ " ");
                }
                Console.WriteLine("\n");
            }

            for (int x = 1;x < Height; x++)
            {
                for (int y = 1;y < Width; y++)
                {
                    
                }
            }
            //how do we determine current location?
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
