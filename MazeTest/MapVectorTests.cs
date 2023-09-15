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
    public class MapVectorTests
    {
        [TestMethod()]
        public void MapVectorTest()
        {
            //Arrange & Act
            MapVector Mv = new MapVector(2, 4);

            //Assert
            Assert.AreEqual(2, Mv.X);
            Assert.AreEqual(4, Mv.Y);
        }

        [TestMethod()]
        [DataRow(-1, 0, false)] //outside bounds < 0
        [DataRow(2, 6, true)] // in bounds
        [DataRow(13, 9, false)] //on edge 
        [DataRow(26, 4, false)] //outside bounds X
        [DataRow(5, 66, false)] //out of bounds Y
        public void InsideBoundaryTest(int x, int y, bool inBounds)
        {
            //Arrange 
            MapVector vector = new MapVector(x, y);

            //Act
            bool actualInBounds = vector.InsideBoundary(13, 9);

            //Assert
            Assert.AreEqual(inBounds, actualInBounds);
        }

        [TestMethod()]
        public void MagnitudeTest()
        {
            MapVector Mv = new MapVector(2, 4);
            double magnitude = Mv.Magnitude();

            Assert.AreEqual(4.47, magnitude);
        }
        public void OperationTest()
        {
            //adding constant plus vectorMap
            MapVector Mv = new MapVector(2, 4);
            var addedMv = Mv + 2;
            MapVector ExpectedMv = new MapVector(4, 6);

            Assert.AreEqual(ExpectedMv, addedMv);

            //adding 2 VectorMaps 
            MapVector vectors = Mv + ExpectedMv;
        }
    }
}