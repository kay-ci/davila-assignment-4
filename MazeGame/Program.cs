using System;
using System.IO;
using System.Windows.Forms;
public class Program : Form{
    [STAThread]
    public static void Main(string[] args)
    {
        try
        {
            StartGame();
        }
        catch (Exception ex) { 
            MessageBox.Show($"Error: {ex.Message}","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            StartGame();
        }
    }

    private static void StartGame()
    {
        var filePath = string.Empty;
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Title = "Browse Map File to Load";
            openFileDialog.Filter = "txt files (*.txt)|*.txt";
            openFileDialog.FilterIndex = 2;
            openFileDialog.DefaultExt = "txt";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog.FileName;

                var game = new MazeGame.MazeGame(filePath);
                game.Run();
                
                MessageBox.Show("Thank you for Playing!", "Bun Bun Maze", MessageBoxButtons.OK);
            }
        }
    }
}

