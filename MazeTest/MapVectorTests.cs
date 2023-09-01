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
            MapVector Mv = new MapVector(2, 4);
            Assert.AreEqual(2, Mv.X);
            Assert.AreEqual(4, Mv.Y);
        }

        [TestMethod()]
        public void InsideBoundaryTest()
        {
           
        }

        [TestMethod()]
        public void MagnitudeTest()
        {
            MapVector Mv = new MapVector(2,4);
            double magnitude = Mv.Magnitude();

            Assert.AreEqual(4.47, magnitude);
        }
        public void PlusOperationTest()
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