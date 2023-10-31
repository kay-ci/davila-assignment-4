 using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace MazeGame
{
    public class InputManager
    { 
        private static InputManager _instance = null;
        private readonly Dictionary<Keys, List<Action>> _keysHandler;
        private KeyboardState _previousState;
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
            if(!_keysHandler.ContainsKey(key))
            {
                _keysHandler[key] = new List<Action>();
            }
            _keysHandler[key].Add(action);
        }
        public void Update()
        {
            KeyboardState state = Keyboard.GetState();
            foreach (var keyPair in _keysHandler)
            {
                if (state.IsKeyDown(keyPair.Key) & !_previousState.IsKeyDown(keyPair.Key))
                {
                    foreach (Action action in keyPair.Value)
                    {
                        action?.Invoke();
                    }
                }
            }
            _previousState = state;
        }
    }
}
