using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGame
{
    public class InputManager
    { 
        private static readonly InputManager _instance = new InputManager();

        public Action<Keys> HandleKey = (key) => 
        {
            Console.WriteLine($"test: {key}");
        };
        private InputManager(){}
        static InputManager(){}

        public static InputManager Instance
        {
            get
            {
                return _instance;
            }
        }
        public void AddKeyHandler(Keys key, Action action)
        {

        }
        public void MoveForward() { }
        public void MoveBackwards() { }
        public void TurnLeft() { }
        public void TurnRight() { }
    }
}
