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
        public Block[,] mapGrid { get; set; }
        [TestInitialize]
        public void Init()
        {
            mapGrid = new Block[5, 5]{
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
            var testPlayer = new Player(startX, startY, mapGrid);
            //Assert
            Assert.AreEqual(1, testPlayer.Position.X);
        }

        [TestMethod()]
        public void GetRotationTest()
        {
            //Arrange
            int startX = 1;
            int startY = 1;
            Player player = new Player(startX, startY, mapGrid);

            //Act
            float northR = player.GetRotation();

            player.Facing = Direction.E;
            float eastR = player.GetRotation();

            player.Facing = Direction.S;
            float southR = player.GetRotation();

            player.Facing = Direction.W;
            float westR = player.GetRotation();

            //Assert
            Assert.AreEqual(0f, northR, 0.01);
            Assert.AreEqual(1.571f, eastR, 0.01);
            Assert.AreEqual(3.141f, southR, 0.01);
            Assert.AreEqual(4.712f, westR, 0.01);
        }
        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod()]
        public void InvalidRotation()
        {
            //Arrange
            int startX = 1;
            int startY = 1;
            Player player = new Player(startX, startY, mapGrid);
            player.Facing = Direction.None;

            player.GetRotation();

        }
        [DataRow(Direction.N, 1, 2)]
        [DataRow(Direction.W, 2, 1)]
        [TestMethod()]
        public void MoveBackwardTest(Direction facing, int x, int y)
        {
            //Arrange
            int startX = 1;
            int startY = 1;
            Player player = new Player(startX, startY, mapGrid);
            player.Facing = facing;
            //Act
            player.MoveBackward();

            //Assert
            Assert.AreEqual(x, player.Position.X);
            Assert.AreEqual(y, player.Position.Y);
            
        }
       
        [TestMethod()]
        public void MoveBackwardFailTest(){
            //Arrange
            int startX = 1;
            int startY = 3;
            Player player = new Player(startX, startY, mapGrid);
            

            //Act
            player.MoveBackward();

            //Assert
            Assert.AreEqual(1,player.Position.X);
            Assert.AreEqual(3,player.Position.Y);

        }
        [DataRow(Direction.E, 2, 1)]
        [DataRow(Direction.S, 1, 2)]
        [TestMethod()]
        public void MoveForwardTest(Direction facing, int x, int y)
        {
            //Arrange
            int startX = 1;
            int startY = 1;
            Player player = new Player(startX, startY, mapGrid);
            player.Facing = facing;

            //Act
            player.MoveForward();

            //Assert
            Assert.AreEqual(x, player.Position.X);
            Assert.AreEqual(y, player.Position.Y);
        }
        [TestMethod()]
        public void MoveForwardFailTest()
        {
            //Arrange
            int startX = 1;
            int startY = 1;
            Player player = new Player(startX, startY, mapGrid);

            //Act
            player.MoveForward();

            //Assert
            Assert.AreEqual(1, player.Position.X);
            Assert.AreEqual(2, player.Position.Y);
        }

        [TestMethod()]
        public void TurnLeftTest()
        {
            //Arrange
            int startX = 1;
            int startY = 3;
            Player player = new Player(startX, startY, mapGrid);

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
            Player player = new Player(startX, startY, mapGrid);

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
    }
}