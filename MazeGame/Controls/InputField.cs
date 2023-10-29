using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace MazeGame.Controls
{
    public class InputField : Component
    {
        private InputManager _inputManager;

        public String Text { get; set; }
        private SpriteFont _font { get; set; }
        private Vector2 _position { get; set; }

        public InputField(string text, SpriteFont font, Vector2 position)
        {
            _inputManager = InputManager.Instance;
            _inputManager.AddKeyHandler(Keys.Back, () => {
                if(Text.Length > 0)
                {
                    Text = Text.Substring(0, Text.Length - 1);
                }
            });
            //set number keys
            SetKeys();
            Text = string.Empty;
            _font = font;
            _position = position;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, Text, _position, Color.Black);
        }

        public override void Update(GameTime gameTime)
        {
            _inputManager.Update();
        }

        private void SetKeys()
        {
            _inputManager.AddKeyHandler(Keys.D0, () => { Text += "0"; });
            _inputManager.AddKeyHandler(Keys.D1, () => { Text += "1"; });
            _inputManager.AddKeyHandler(Keys.D2, () => { Text += "2"; });
            _inputManager.AddKeyHandler(Keys.D3, () => { Text += "3"; });
            _inputManager.AddKeyHandler(Keys.D4, () => { Text += "4"; });
            _inputManager.AddKeyHandler(Keys.D5, () => { Text += "5"; });
            _inputManager.AddKeyHandler(Keys.D6, () => { Text += "6"; });
            _inputManager.AddKeyHandler(Keys.D7, () => { Text += "7"; });
            _inputManager.AddKeyHandler(Keys.D8, () => { Text += "8"; });
            _inputManager.AddKeyHandler(Keys.D9, () => { Text += "9"; });

        }
    }
}
