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
        private static InputManager _instance = null;
        private Dictionary<Keys, List<Action>> _keysHandler;
        private InputManager(){
            _keysHandler = new Dictionary<Keys, List<Action>>();
        }
        static InputManager(){}

        public static InputManager Instance
        {
            get{
                if (_instance == null) {
                    _instance = new InputManager();
                }
                return _instance;}
        }
        
        public void AddKeyHandler(Keys key, Action action)
        {
            List<Action> actions = new List<Action>();
            actions.Add(action);
            _keysHandler.Add(key, actions);
        }
        public void Update()
        {

        }
    }
}
