using Microsoft.VisualStudio.TestTools.UnitTesting;
using MazeRecursion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maze;

namespace MazeRecursion.Tests
{
    [TestClass()]
    public class MazeRecursionTests
    {
        [TestMethod()]
        public void MazeRecursionTest()
        {
            MazeRecursion mazeRecursion = new(3);
            Assert.IsNotNull(mazeRecursion);
        }

        [TestMethod()]
        public void CreateMapTest()
        {
            // If Initial position is [0,0]
            MazeRecursion mazeRecursion = new(0);
            Direction [,] dirArray = mazeRecursion.CreateMap(5, 5);
            Assert.IsNotNull(dirArray);
            Assert.AreEqual(Direction.E | Direction.S, dirArray[0, 0]);
            Assert.AreEqual(Direction.S | Direction.W, dirArray[0, 1]);
            Assert.AreEqual(Direction.N, dirArray[1, 0]);
            Assert.AreEqual(Direction.N, dirArray[1, 1]);
        }
    }
}