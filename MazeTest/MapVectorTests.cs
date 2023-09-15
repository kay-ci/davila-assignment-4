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
            bool isInBound = vector.InsideBoundary(13, 9);

            //Assert
            Assert.AreEqual(inBounds, vector.IsValid);
            Assert.AreEqual(inBounds, isInBound);
        }

        [TestMethod()]
        public void MagnitudeTest()
        {
            MapVector Mv = new MapVector(2, 4);
            double magnitude = Mv.Magnitude();

            Assert.AreEqual(4.47, magnitude);
        }
        [TestMethod()]
        public void ConstantOperationTest()
        {
            //Arrange
            MapVector Mv = new MapVector(2, 4);

            //Act
            var addedMv = Mv + 2;
            var removedMV = Mv - 1;

            //Assert
            Assert.AreEqual(4, addedMv.X);
            Assert.AreEqual(6, addedMv.Y);
            Assert.AreEqual(1, removedMV.X);
            Assert.AreEqual(3, removedMV.Y);
        }
        [TestMethod()]
        public void VectorOpsTest()
        {
            var v1 = new MapVector(2, 4);
            var v2 = new MapVector(1, 3);

            var result1 = v1 + v2;
            var result2 = v1 - v2;
            var result3 = v1 * v2;

            Assert.AreEqual(3, result1.X);
            Assert.AreEqual(7, result1.Y);
            Assert.AreEqual(1, result2.X);
            Assert.AreEqual(1, result2.Y);
            Assert.AreEqual(2, result3.X);
            Assert.AreEqual(12, result3.Y);
        }
    }
}