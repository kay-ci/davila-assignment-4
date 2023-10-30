namespace MazeRecursion;
using Maze;
using System;
using System.Linq;
using System.Windows.Markup;

public class MazeRecursion : IMapProvider
{
    private List<MapVector> _previouslyVisited;
    private bool[,] _visitedArray;
    private Random _random;
    public MazeRecursion()
    {
        _random = new Random();
        _previouslyVisited = new List<MapVector>();
    }

    public Direction[,] CreateMap(int width, int height)
    {
        int arrayWidth = (width - 1) / 2;
        int arrayHeight = (height - 1) / 2;

        Direction[,] directionsArray = new Direction[arrayHeight, arrayWidth];
        _visitedArray = new bool[arrayHeight, arrayWidth];
        //pick random initial vector
        MapVector initial;
        do
        {
            int rWidth = _random.Next(0, arrayWidth);
            int rHeight = _random.Next(0, arrayHeight);
            initial = new(rWidth, rHeight);
        } while (!initial.InsideBoundary(arrayWidth, arrayHeight));


        // Start Walking
        Walk(initial, directionsArray);
        return directionsArray;
    }

    private Direction[,] Walk(MapVector currentPos, Direction[,] directionsArray)
    {
        _visitedArray[currentPos.Y, currentPos.X] = true;

        //_previouslyVisited.Add(currentPos);

        //shuffled enums
        Direction[] shuffledEnums = (Direction[])Enum.GetValues(typeof(Direction));
        shuffledEnums = shuffledEnums.OrderBy(_ => _random.Next()).ToArray();

        foreach (Direction dir in shuffledEnums)
        {
            if (dir != Direction.None)
            {
                var forwardPos = dir + currentPos;
                var oppositeDir = GetOppositeDirection(dir);
                if (forwardPos.InsideBoundary(directionsArray.GetLength(1), directionsArray.GetLength(0)))
                {
                    if (!_visitedArray[forwardPos.Y, forwardPos.X])
                    {
                        directionsArray[currentPos.Y, currentPos.X] = directionsArray[currentPos.Y, currentPos.X] | dir;
                        directionsArray[forwardPos.Y, forwardPos.X] = directionsArray[forwardPos.Y, forwardPos.X] | oppositeDir;
                        directionsArray = Walk(forwardPos, directionsArray);
                    }
                }
            }

        }
        return directionsArray;
    }
    static private Direction GetOppositeDirection(Direction dir)
    {
        Direction newDir;
        switch (dir)
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
