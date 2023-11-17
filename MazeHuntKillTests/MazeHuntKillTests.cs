using Maze;
namespace MazeHuntKillTests;

[TestClass()]
public class MazeRecursionTests
{
    [TestMethod()]
    public void MazeHuntKillTest()
    {
        var mazeRecursion = new MazeHuntKill.MazeHuntKill(3);
        Assert.IsNotNull(mazeRecursion);
    }

    [TestMethod()]
    public void CreateMap5x5Test()
    {
        // If Initial position is [0,0]
        var mazeRecursion = new MazeHuntKill.MazeHuntKill(0);
        Direction[,] dirArray = mazeRecursion.CreateMap(5, 5);
        Assert.IsNotNull(dirArray);
        Assert.AreEqual(Direction.E | Direction.S, dirArray[0, 0]);
        Assert.AreEqual(Direction.S | Direction.W, dirArray[0, 1]);
        Assert.AreEqual(Direction.N, dirArray[1, 0]);
        Assert.AreEqual(Direction.N, dirArray[1, 1]);
    }

    [TestMethod()]
    public void CreateMap9x7Test()
    {
        // If Initial position is [0,0]
        var mazeRecursion = new MazeHuntKill.MazeHuntKill(0);
        Direction[,] dirArray = mazeRecursion.CreateMap(9, 7);
        Assert.IsNotNull(dirArray);
        Assert.AreEqual(Direction.S, dirArray[0, 0]);
        Assert.AreEqual(Direction.E | Direction.S, dirArray[0, 1]);
        Assert.AreEqual(Direction.E | Direction.S | Direction.W, dirArray[0, 2]);
        Assert.AreEqual(Direction.W, dirArray[0, 3]);

        Assert.AreEqual(Direction.N | Direction.S, dirArray[1, 0]);
        Assert.AreEqual(Direction.N | Direction.S, dirArray[1, 1]);
        Assert.AreEqual(Direction.N | Direction.E, dirArray[1, 2]);
        Assert.AreEqual(Direction.S | Direction.W, dirArray[1, 3]);

        Assert.AreEqual(Direction.N | Direction.E, dirArray[2, 0]);
        Assert.AreEqual(Direction.N | Direction.W, dirArray[2, 1]);
        Assert.AreEqual(Direction.E, dirArray[2, 2]);
        Assert.AreEqual(Direction.N | Direction.W, dirArray[2, 3]);
    }
}