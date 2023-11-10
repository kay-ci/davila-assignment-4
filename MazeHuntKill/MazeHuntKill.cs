namespace MazeHuntKill;
using Maze;
using System.ComponentModel;

public class MazeHuntKill : IMapProvider
{
    private Random _random;
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

        // Pick random starting vector
        int rWidth = _random.Next(0, arrayWidth);
        int rHeight = _random.Next(0, arrayHeight);
        MapVector currentPosition = new(rWidth, rHeight);
        do
        {
            // Walking phase here
            // Choose a random valid Direction 
            Direction[] validDirections = getValidDirections(directionArray, currentPosition);
            Direction randomValidDir = validDirections[_random.Next(0, validDirections.Length)];

            // Next position info
            MapVector nextPosition = randomValidDir + currentPosition ;
            Direction oppositeDir = GetOppositeDirection(randomValidDir);

            // Update current position
            directionArray[currentPosition.Y, currentPosition.X] = directionArray[currentPosition.Y, currentPosition.X]  | randomValidDir;

            // Update next position 
            directionArray[nextPosition.Y, nextPosition.X] = directionArray[nextPosition.Y, nextPosition.X] | oppositeDir;

            // Update current position 
            currentPosition = nextPosition;
        } while (!validPosition(directionArray, currentPosition));

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
    private bool validPosition(Direction[,] directionArray, MapVector currentPosition)
    {
        MapVector nextPosition = new(1, 1);
        return true;
    }

    private Direction[] getValidDirections(Direction[,] directionArray, MapVector currentPosition)
    {
        // Get all the possible directions you can walk to for the given position You can walk to a new position if:

        // i.It has not been touched

        // ii.It is inside the map

        // iii.It is immediately adjacent to your current position
        throw new NotImplementedException();
    }

    public Direction[,] CreateMap()
    {
        throw new NotImplementedException();
    }
}
