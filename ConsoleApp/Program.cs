using Maze;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Console Maze!");
        Console.WriteLine("Please choose a MAZE size:");
        Console.WriteLine("[1] 5x5 \n[2] 9x7\n[3] 9x13");
        string input = Console.ReadLine();

        switch (input)
        {
            case "1":
                //load 5x5 maze
                Test();
                break;

            case "2":
                // load 9x7 maze
                Test();
                break;

            case "3":
                //load 9x13 maze
                Test();
                break;

            default:
                Console.WriteLine(" Please choose a valid maze size");
                Console.WriteLine();
                Console.ReadLine();
                break;
        }
       

    }
    public static void Test() {
        Console.WriteLine("good input"); ;
    }
}