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
    public class PlayerTests
    {
        [TestMethod()]
        public void PlayerTest()
        {
            //Arrange
            Block[,] mapGrid = new Block[5,5];
            int startX = 1;
            int startY = 3;
            //Act
            var testPlayer = new Player(startX,startY,mapGrid);
            //Assert
            Assert.AreEqual(1, testPlayer.Position.X);
        }

        [TestMethod()]
        public void GetRotationTest()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod()]
        public void MoveBackwardTest()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod()]
        public void MoveForwardTest()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod()]
        public void TurnLeftTest()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod()]
        public void TurnRightTest()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}