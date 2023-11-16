namespace MazeHuntKill;
using Maze;
using System.ComponentModel;

public class MazeHuntKill : IMapProvider
{
    private Random _random;
    private bool[,]? _visitedArray;
    private MapVector _currentPosition;
    public MazeHuntKill() 
    {
        _random = new Random();
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
        do
        {
            // Walking phase here
            _visitedArray[_currentPosition.Y, _currentPosition.X] = true;

            // Choose a random valid Direction 
            Direction[] validDirections = getValidDirections(directionArray);
            Direction randomValidDir = validDirections[_random.Next(0, validDirections.Length)];

            // Next position info
            MapVector nextPosition = randomValidDir + _currentPosition ;
            Direction oppositeDir = GetOppositeDirection(randomValidDir);

            // Update current position
            directionArray[_currentPosition.Y, _currentPosition.X] = directionArray[_currentPosition.Y, _currentPosition.X]  | randomValidDir;

            // Update next position 
            directionArray[nextPosition.Y, nextPosition.X] = directionArray[nextPosition.Y, nextPosition.X] | oppositeDir;

            // Update current position 
            _currentPosition = nextPosition;
        } while (!ValidPosition(directionArray, _currentPosition));

        // Hunting phase here

        return directionArray;
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
    private bool ValidPosition(Direction[,] directionArray, MapVector nextPosition)
    {
        if (_visitedArray != null)
        {
            if (_visitedArray[nextPosition.Y, nextPosition.X] == false)
            {
                if (nextPosition.InsideBoundary(directionArray.GetLength(1), directionArray.GetLength(0)) && IsAdjacent(nextPosition))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private Direction[] getValidDirections(Direction[,] directionArray)
    {
        var directions = new Direction[] { Direction.S, Direction.W, Direction.N, Direction.E };
        var possibleDirection = new List<Direction>();

        foreach (var dir in directions)
        {
            MapVector nextPosition = dir + _currentPosition;
            if (ValidPosition(directionArray, nextPosition))
            {
                possibleDirection.Add(dir);
            }

        }
        return possibleDirection.ToArray();
    }

    // Check if the next position is adjacent to the _currentPosition
    private bool IsAdjacent(MapVector nextPosition)
    {
        if (nextPosition + Direction.S == _currentPosition || nextPosition + Direction.N == _currentPosition ||
            nextPosition + Direction.E == _currentPosition || nextPosition + Direction.W == _currentPosition)
        {
            return true;
        }
        return false;
    }
    public Direction[,] CreateMap()
    {
        throw new NotImplementedException();
    }
}
