namespace MazeHuntKill;
using Maze;
public class MazeHuntKill : IMapProvider
{
    private Random _random;
    public MazeHuntKill() 
    {
        _random = new Random();
    }
    public Direction[,] CreateMap(int width, int height)
    {
        throw new NotImplementedException();
    }

    public Direction[,] CreateMap()
    {
        throw new NotImplementedException();
    }
}
