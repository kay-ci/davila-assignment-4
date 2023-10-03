using Maze;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Console Maze!");
        Console.WriteLine("Please enter path to maze:");
        string input = "";
        do{
            input = Console.ReadLine();
            try
            {
                GenerateMaze(input); 
            }
            catch (Exception e)
            {   
                Console.WriteLine(e.Message);
                input = "";
            }
        } while (string.IsNullOrWhiteSpace(input));
    }
    public static void GenerateMaze(string filePath) {
        Map map = new Map(new MazeFromFile.MazeFromFile(filePath));
        map.CreateMap();
        PrintMaze(map);
    }

    public static void PrintMaze(Map map)
    {
        for (int y = 0; y < map.Height; y++)
        {
            for (int x = 0; x < map.Width; x++)
            {
                if (map.MapGrid[y, x] == Block.Empty)
                {

                    if (y == map.Goal.Y && x == map.Goal.X)
                    {
                        Console.Write("G ");
                    }
                    else if (y == map.Player.Position.Y && x == map.Player.Position.X)
                    {
                        Console.Write("P ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                else
                {
                    Console.Write("* ");
                }
            }
            Console.WriteLine();
        }
    }
}