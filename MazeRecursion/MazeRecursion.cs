namespace MazeRecursion;
using System;
using System.Diagnostics;
using Maze;

public static class MazeRecursionCreator
{
    public static IMapProvider CreateRecursion()
    {
        return new MazeRecursion();
    }
}
internal class MazeRecursion : IMapProvider
{
    private bool[,]? _visitedArray;
    private readonly Random _random;
    internal MazeRecursion()
    {
        _random = new Random();
    }
    public MazeRecursion(int seed)
    {
        _random = new Random(seed);
    }
    /// <summary>
    /// Creates a direction map recursively
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns>A Direction array representing the maze</returns>
    public Direction[,] CreateMap(int width, int height)
    {
        // Validate width
        if (width <= 0 || width % 2 == 0)
        {
            throw new ArgumentException("Width must be a positive odd number.", nameof(width));
        }

        // Validate height
        if (height <= 0 || height % 2 == 0)
        {
            throw new ArgumentException("Height must be a positive odd number.", nameof(height));
        }

        int arrayWidth = (width - 1) / 2;
        int arrayHeight = (height - 1) / 2;

        Direction[,] directionsArray = new Direction[arrayHeight, arrayWidth];
        _visitedArray = new bool[arrayHeight, arrayWidth];

        //pick random initial vector
        int rWidth = _random.Next(0, arrayWidth);
        int rHeight = _random.Next(0, arrayHeight);
        MapVector initial = new(rWidth, rHeight);

        // Start Walking
        Walk(initial, directionsArray);
        return directionsArray;
    }

    private Direction[,] Walk(MapVector currentPos, Direction[,] directionsArray)
    {
        Debug.Assert(_visitedArray != null);
        
        _visitedArray[currentPos.Y, currentPos.X] = true;

        // Shuffled enums
        Direction[] enums = new Direction[] { Direction.N, Direction.E, Direction.S, Direction.W};
        Direction[] shuffledEnums = Shuffle(_random, enums);

        foreach (Direction dir in shuffledEnums)
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
    // uses the Fisher-Yates algorithm, code example from StackOverflow
    // url: https://stackoverflow.com/questions/108819/best-way-to-randomize-an-array-with-net
    private static Direction[] Shuffle(Random random, Direction[] dirArray)
    {
        int n = dirArray.Length;
        while (n > 1)
        {
            int k = random.Next(n--);
            (dirArray[k], dirArray[n]) = (dirArray[n], dirArray[k]);
        }
        return dirArray;
    }

    /// <summary>
    /// Create a Direction array with default size 9x7 recursively
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Direction[,] CreateMap()
    {
        int defaultWidth = 9;
        int defaultHeight = 7;

        return CreateMap(defaultWidth, defaultHeight);
    }
}