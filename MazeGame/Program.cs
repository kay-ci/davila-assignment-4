using System.IO;
using System.Windows.Forms;
public class Program{
    public static void Main(string[] args)
    {
        //using var game = new MazeGame.Game1();
        //game.Run();

        var fileContent = string.Empty;
        var filePath = string.Empty;
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.InitialDirectory = "c:\\davila-assignement-2";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog.FileName;

                //Read the contents of the file into a stream
                var fileStream = openFileDialog.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
            }
        }

        MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
    }
}

