namespace MazeHuntKill;
using Maze;
using System.ComponentModel;
using System.Diagnostics;

public class MazeHuntKill : IMapProvider
{
    private readonly Random _random;
    private bool[,]? _visitedArray;
    private MapVector _currentPosition;
    public MazeHuntKill() 
    {
        _random = new Random();
        _currentPosition = new MapVector(0,0);
    }
    public MazeHuntKill(int seed)
    {
        _random = new Random(seed);
        _currentPosition = new MapVector(0, 0);
    }
    public Direction[,] CreateMap(int width, int height)
    {
        int arrayWidth = (width - 1) / 2;
        int arrayHeight = (height - 1) / 2;

        // Set appropriate size
        Direction[,] directionArray = new Direction[arrayHeight, arrayWidth];
        _visitedArray = new bool[arrayHeight, arrayWidth];

        // Pick random starting vector
        int rWidth = _random.Next(0, arrayWidth);
        int rHeight = _random.Next(0, arrayHeight);
        _currentPosition = new(rWidth, rHeight);
        while (true)
        {
            _visitedArray[_currentPosition.Y, _currentPosition.X] = true;

            // Walking phase here
            bool walkedSuccessfully = Walk(directionArray);

            // If unsuccessful walk start Hunting phase here
            if (!walkedSuccessfully && !Hunt(directionArray)) 
            {
                break;
            }
        }
        return directionArray;
    }

    private bool Walk(Direction[,] directionArray)
    {
        // Choose a random valid Direction 
        Direction[] validDirections = GetValidDirections(directionArray);
        if (validDirections.Length == 0)
        {
            return false; // Unsuccessful walk
        }

        Direction randomValidDir = validDirections[_random.Next(0, validDirections.Length)];

        // Next position info
        MapVector nextPosition = randomValidDir + _currentPosition;
        Direction oppositeDir = GetOppositeDirection(randomValidDir);

        // Update current position
        directionArray[_currentPosition.Y, _currentPosition.X] = directionArray[_currentPosition.Y, _currentPosition.X] | randomValidDir;

        // Update next position 
        directionArray[nextPosition.Y, nextPosition.X] = directionArray[nextPosition.Y, nextPosition.X] | oppositeDir;

        // Update current position 
        _currentPosition = nextPosition;
        return true; // Successful walk
    }

    private bool Hunt(Direction[,] directionArray)
    {
        for(int y = 0; y < directionArray.GetLength(0); y++)
        {
            for (int x = 0; x < directionArray.GetLength(1); x++)
            {
                if (directionArray[y, x] == Direction.None)
                {
                    MapVector huntPosition = new(x, y);

                    Direction[] validDirections = GetValidDirectionsForHunt(directionArray, huntPosition);
                    if (validDirections.Length > 0)
                    {
                        Direction validDir = validDirections[_random.Next(0,validDirections.Length)];
                        MapVector nextPosition = validDir + huntPosition;
                        Direction oppositeDir = GetOppositeDirection(validDir);

                        directionArray[huntPosition.Y, huntPosition.X] = directionArray[huntPosition.Y, _currentPosition.X] | validDir;

                        // Update next position 
                        directionArray[nextPosition.Y, nextPosition.X] = directionArray[nextPosition.Y, nextPosition.X] | oppositeDir;

                        // Update current position 
                        _currentPosition = nextPosition;
                        return true; // Successful walk

                    }

                }
            }
        }
        return false;
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

    private Direction[] GetValidDirections(Direction[,] directionArray)
    {
        var directions = new Direction[] { Direction.S, Direction.W, Direction.N, Direction.E };
        var possibleDirection = new List<Direction>();

        foreach (var dir in directions)
        {
            MapVector nextPosition = dir + _currentPosition;
            Debug.Assert(_visitedArray != null);
            if (nextPosition.InsideBoundary(directionArray.GetLength(1), directionArray.GetLength(0)))
            {
                if (_visitedArray[nextPosition.Y, nextPosition.X] == false)
                {
                    possibleDirection.Add(dir);
                }
                
            }

        }
        return possibleDirection.ToArray();
    }

    // Get the valid directions for the hunting phase
    private Direction[] GetValidDirectionsForHunt(Direction[,] directionArray, MapVector position)
    {
        var directions = new Direction[] { Direction.S, Direction.W, Direction.N, Direction.E };
        var possibleDirection = new List<Direction>();

        foreach (var dir in directions)
        {
            MapVector nextPosition = dir + position;
            if (nextPosition.InsideBoundary(directionArray.GetLength(1), directionArray.GetLength(0)))
            {
                Debug.Assert(_visitedArray != null);
                if (_visitedArray[nextPosition.Y, nextPosition.X])
                {
                        possibleDirection.Add(dir);
                }
            }

        }
        return possibleDirection.ToArray();
    }
    public Direction[,] CreateMap()
    {
        throw new NotImplementedException();
    }
}
