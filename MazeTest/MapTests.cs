using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maze;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Tests
{
    [TestClass()]
    public class MapTests
    { 
        IMapProvider m_provider;

        [TestInitialize]
        public void Init()
        {
            string filePath = "\"C:\\\\assignement01\\\\map9x7.txt\""; //needs to be changed to pass
            m_provider = new MazeFromFile.MazeFromFile(filePath);
        }
        [TestMethod()]
        public void MapTest()
        {
            Map map = new Map(m_provider);

            Assert.IsNotNull(map);
            Assert.AreEqual(3, map._directionMaze.GetLength(1));
            Assert.AreEqual(4, map._directionMaze.GetLength(0));
        }

        [TestMethod()]
        public void CreateMapTest()
        {
            Map map = new Map(m_provider);

            map.CreateMap();

            Assert.AreEqual(7, map.Height);
            Assert.AreEqual(9, map.Width);
        }

        [TestMethod()]
        public void ToGridTest()
        {
            //Arrange
            int value = 2;
            Map map = new Map(m_provider);

            //act
            int actual = map.ToGrid(value);
            //assert
            Assert.AreEqual(5, actual);
        }

    }
}