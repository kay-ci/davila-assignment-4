using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maze;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Maze.Tests
{
    [TestClass()]
    public class MapTests
    { 
        IMapProvider MapProvider { get; set; }

        [TestInitialize]
        public void Init()
        {
            Direction[,] directionArray = new Direction[2, 2]
            {
                {Direction.E | Direction.S, Direction.S|Direction.W},
                {Direction.N,Direction.N}
            }; //mock return 
            var m_provider = new Mock<IMapProvider>();
            m_provider.Setup(s => s.CreateMap()).Returns(directionArray);

            MapProvider = m_provider.Object;
        }
        [TestMethod()]
        public void MapTest()
        {
            Map map = new Map(MapProvider);
            map.CreateMap();
            Assert.IsNotNull(map._directionMaze);
            Assert.AreEqual(2, map._directionMaze.GetLength(1));
            Assert.AreEqual(2, map._directionMaze.GetLength(0));
        }

        [TestMethod()]
        public void CreateMapTest()
        {
            Map map = new Map(MapProvider);

            map.CreateMap();

            Assert.IsNotNull(map.MapGrid);
            Assert.IsNotNull(map.Goal);
            Assert.IsNotNull(map.Player);
            Assert.AreEqual(5, map.Height);
            Assert.AreEqual(5, map.Width);
            Assert.AreEqual(Block.Empty, map.MapGrid[1, 1]);
        }
    }
}