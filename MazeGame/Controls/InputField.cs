using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace MazeGame.Controls
{
    public class InputField : Component
    {
        public String Text { get; set; }
        private SpriteFont _font { get; set; }
        private Vector2 _position { get; set; }

        public InputField(string text, SpriteFont font, Vector2 position)
        {
            Text = string.Empty;
            _font = font;
            _position = position;
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, Text, _position, Color.Black);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
