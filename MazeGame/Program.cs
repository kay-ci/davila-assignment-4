using MazeGame;
using System;
using System.IO;
using System.Windows.Forms;
public class Program {
    [STAThread]
    public static void Main(string[] args)
    {
        using (var game = new MazeGame.MazeGame())
            game.Run();
    }

     
}

