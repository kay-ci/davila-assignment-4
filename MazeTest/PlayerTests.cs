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
        private Block[,] _mapGrid { get; set; }
        [TestInitialize]
        public void Init()
        {
            _mapGrid = new Block[5, 5]{
                {Block.Solid,Block.Solid,Block.Solid,Block.Solid,Block.Solid },
                {Block.Solid,Block.Empty,Block.Empty,Block.Empty, Block.Solid},
                {Block.Solid,Block.Empty,Block.Solid, Block.Empty,Block.Solid},
                {Block.Solid,Block.Empty,Block.Solid, Block.Empty,Block.Solid},
                {Block.Solid,Block.Solid,Block.Solid,Block.Solid,Block.Solid},
            };
        }
        [TestMethod()]
        public void PlayerTest()
        {
            //Arrange
            int startX = 1;
            int startY = 3;
            //Act
            var testPlayer = new Player(startX, startY, _mapGrid);
            //Assert
            Assert.AreEqual(1, testPlayer.Position.X);
        }

        [TestMethod()]
        public void GetRotationTest()
        {
            //Arrange
            int startX = 1;
            int startY = 1;
            Player player = new Player(startX, startY, _mapGrid);

            //Act
            float northR = player.GetRotation();

            player.TurnRight();
            float eastR = player.GetRotation();

            player.TurnRight();
            float southR = player.GetRotation();

            player.TurnRight();
            float westR = player.GetRotation();

            //Assert
            Assert.AreEqual(0f, northR, 0.01);
            Assert.AreEqual(1.571f, eastR, 0.01);
            Assert.AreEqual(3.141f, southR, 0.01);
            Assert.AreEqual(4.712f, westR, 0.01);
        }
        [TestMethod()]
        public void MoveBackwardTest()
        {
            //Arrange
            int startX = 1;
            int startY = 1;
            Player player = new Player(startX, startY, _mapGrid);
            //Act
            player.MoveBackward();

            //Assert
            Assert.AreEqual(1, player.Position.X);
            Assert.AreEqual(2, player.Position.Y);
            
        }
       
        [TestMethod()]
        public void MoveBackwardFailTest(){
            //Arrange
            int startX = 1;
            int startY = 3;
            Player player = new Player(startX, startY, _mapGrid);
            

            //Act
            player.MoveBackward();

            //Assert
            Assert.AreEqual(1,player.Position.X);
            Assert.AreEqual(3,player.Position.Y);

        }
        [TestMethod()]
        public void MoveForwardTest()
        {
            //Arrange
            int startX = 1;
            int startY = 1;
            Player player = new Player(startX, startY, _mapGrid);
            player.TurnRight();

            //Act
            player.MoveForward();

            //Assert
            Assert.AreEqual(2, player.Position.X);
            Assert.AreEqual(1, player.Position.Y);
        }
        [TestMethod()]
        public void MoveForwardFailTest()
        {
            //Arrange
            int startX = 1;
            int startY = 1;
            Player player = new Player(startX, startY, _mapGrid);

            //Act
            player.MoveForward();

            //Assert
            Assert.AreEqual(1, player.Position.X);
            Assert.AreEqual(1, player.Position.Y);
        }

        [TestMethod()]
        public void TurnLeftTest()
        {
            //Arrange
            int startX = 1;
            int startY = 3;
            Player player = new Player(startX, startY, _mapGrid);

            //Act
            player.TurnLeft();
            Direction turn1 = player.Facing;

            player.TurnLeft();
            Direction turn2 = player.Facing;

            player.TurnLeft();
            Direction turn3 = player.Facing;

            player.TurnLeft();
            Direction turn4 = player.Facing;

            //Assert
            Assert.AreEqual(Direction.W, turn1);
            Assert.AreEqual(Direction.S, turn2);
            Assert.AreEqual(Direction.E, turn3);
            Assert.AreEqual(Direction.N, turn4);
        }

        [TestMethod()]
        public void TurnRightTest()
        {
            //Arrange
            int startX = 1;
            int startY = 3;
            Player player = new Player(startX, startY, _mapGrid);

            //Act
            player.TurnRight();
            Direction turn1 = player.Facing;

            player.TurnRight();
            Direction turn2 = player.Facing;

            player.TurnRight();
            Direction turn3 = player.Facing;

            player.TurnRight();
            Direction turn4 = player.Facing;

            //Assert
            Assert.AreEqual(Direction.E, turn1);
            Assert.AreEqual(Direction.S, turn2);
            Assert.AreEqual(Direction.W, turn3);
            Assert.AreEqual(Direction.N, turn4);
        }

        [TestMethod()]
        public void IsValidTest()
        {
            //Arrange
            int startX = 1;
            int startY = 3;
            Player player = new Player(startX, startY, _mapGrid);

            MapVector newPosition = new MapVector(-2, 30); //out of bounds
            MapVector solidPosition = new MapVector(0, 0); //if solid
            
            bool inBounds = player.IsValidMove(newPosition);
            bool onSolid = player.IsValidMove(solidPosition);

            Assert.IsFalse(inBounds);
            Assert.IsFalse(onSolid);

        }
    }
}