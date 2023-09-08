using Maze;
using System.Security.Cryptography.X509Certificates;

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
        Console.WriteLine("Height in blocks: " +map.Height);
        Console.WriteLine("Width in blocks: " + map.Width);

    }
}