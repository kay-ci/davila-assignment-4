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

        public int Height { get; set; }

        public bool IsGameFinished { get; set; }

        public Block[,] MapGrid {get; set;}

        public IPlayer Player {get; set;}
        public IMapProvider MapProvider { get; set;}

        public int Width { get; set; }
        public Map(IMapProvider mapProvider)
        {
            MapProvider = mapProvider;
        }

        public void CreateMap()
        {
            Direction[,] directionMaze = MapProvider.CreateMap();
            MapGrid = new Block[directionMaze.GetLength(0), directionMaze.GetLength(1)];

            //setting to solid block 
            for (int i = 0; i < MapGrid.GetLength(0); i++) { 
                for(int j = 0; j < MapGrid.GetLength(1); j++)
                {
                    MapGrid[i, j] = Block.Solid;
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
