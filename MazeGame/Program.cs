using MazeGame;
using System;
using System.IO;
using System.Windows.Forms;
public class Program : Form{
    [STAThread]
    public static void Main(string[] args)
    {
        using (var game = new MazeGameFinal())
            game.Run();
    }

     
}

