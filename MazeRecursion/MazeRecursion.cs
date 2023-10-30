namespace MazeRecursion;
using Maze;
using System.Linq;
using System.Windows.Markup;

public class MazeRecursion : IMapProvider
{
    private List<MapVector> _previouslyVisited;

    public MazeRecursion() {
        _previouslyVisited = new List<MapVector>();
    }

    public Direction[,] CreateMap(int width, int height)
    {
        Direction[,] directionsArray = new Direction[width, height];
        Random random = new Random();
        //pick random initial vector
        int rWidth = random.Next(0, width);
        int rHeight = random.Next(0, height);
        MapVector initial = new(rWidth, rHeight);

        //shuffled enums
        Direction[] shuffledEnums = (Direction[])Enum.GetValues(typeof(Direction));
        shuffledEnums = shuffledEnums.OrderBy(_ => random.Next()).ToArray();
        foreach (Direction dir in shuffledEnums)
        {
            var forwardPos = dir + initial;
            var oppositeDir = GetOppositeDirection(dir);
            if (forwardPos.InsideBoundary(width, height) && !_previouslyVisited.Contains(forwardPos))
            {
                directionsArray[forwardPos.X, forwardPos.Y] = dir | oppositeDir;
            }
        }
        _previouslyVisited.Add(initial);
        return directionsArray;    
    }
    

    static private Direction GetOppositeDirection(Direction dir)
    {
        Direction newDir;
        switch(dir)
        {
            case Direction.N:
                newDir = Direction.S;
                break;    
            case Direction.E:
                newDir = Direction.W;
                break;
            case Direction.S:
                newDir = Direction.N;
                break;
            case Direction.W:
                newDir = Direction.E;
                break;
            default:
                newDir = Direction.None;
                break;
        }
        return newDir;
    }

    
    public Direction[,] CreateMap()
    {
        throw new NotImplementedException();
    }
}
