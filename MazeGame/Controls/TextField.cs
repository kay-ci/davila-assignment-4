using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MazeGame.Controls
{
    /// <summary>
    /// A textured component which displays text
    /// </summary>
    public class TextField : Component
    {
       
        private readonly SpriteFont _font;
        public Color PenColour { get; set; }
        public Vector2 Position { get; set; }
        public string Text { get; set; }
        public TextField(SpriteFont font)
        {
            _font = font;
            PenColour = Color.Black;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, Text, Position, PenColour);
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
