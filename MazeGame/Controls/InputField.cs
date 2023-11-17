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
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace MazeGame.Controls
{
    /// <summary>
    /// Creates a number input field for the user to input maze width and height.
    /// </summary>
    public class InputField : Component
    {
        private MouseState _currentMouse;
        private MouseState _previousMouse;
        private readonly InputManager _inputManager;
        private readonly Texture2D _texture;
        private bool _isHovering;

        public event EventHandler Click;
        public bool IsSelected { get; set; }
        public string Text { get; set; }
        private SpriteFont _font { get; set; }
        private Vector2 _position { get; set; }
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
            }
        }
        public InputField(Texture2D texture, SpriteFont font, Vector2 position)
        {
            _inputManager = InputManager.Instance;
            _inputManager.AddKeyHandler(Keys.Back, () => {
                if(Text.Length > 0 && IsSelected)
                {
                    Text = Text.Substring(0, Text.Length - 1);
                }
            });
            _texture = texture;
            //set number keys
            SetKeys();
            Text = string.Empty;
            _font = font;
            _position = position;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var color = Color.White;
            if (_isHovering || IsSelected)
                color = Color.Gray;
            spriteBatch.Draw(_texture, Rectangle, color);
            spriteBatch.DrawString(_font, Text, new Vector2(_position.X + 80, _position.Y+10), Color.Black);
        }

        public override void Update(GameTime gameTime)
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);
            _isHovering = false;
            if (mouseRectangle.Intersects(Rectangle))
            {
                _isHovering = true;
                if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                    
                }
            }
            _inputManager.Update();
        }

        private void SetKeys()
        {
            _inputManager.AddKeyHandler(Keys.D0, () => { if (Text.Length < 2 && IsSelected) Text += "0"; });
            _inputManager.AddKeyHandler(Keys.D1, () => { if (Text.Length < 2 && IsSelected) Text += "1"; });
            _inputManager.AddKeyHandler(Keys.D2, () => { if (Text.Length < 2 && IsSelected) Text += "2"; });
            _inputManager.AddKeyHandler(Keys.D3, () => { if (Text.Length < 2 && IsSelected) Text += "3"; });
            _inputManager.AddKeyHandler(Keys.D4, () => { if (Text.Length < 2 && IsSelected) Text += "4"; });
            _inputManager.AddKeyHandler(Keys.D5, () => { if (Text.Length < 2 && IsSelected) Text += "5"; });
            _inputManager.AddKeyHandler(Keys.D6, () => { if (Text.Length < 2 && IsSelected) Text += "6"; });
            _inputManager.AddKeyHandler(Keys.D7, () => { if (Text.Length < 2 && IsSelected) Text += "7"; });
            _inputManager.AddKeyHandler(Keys.D8, () => { if (Text.Length < 2 && IsSelected) Text += "8"; });
            _inputManager.AddKeyHandler(Keys.D9, () => { if (Text.Length < 2 && IsSelected) Text += "9"; });

        }
    }
}
