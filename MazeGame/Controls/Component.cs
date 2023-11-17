using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace MazeGame.Controls
{
    /// <summary>
    /// Create a base class for drawable components for the user input and for user display components
    /// Got the idea from a Youtube tutorial that teaches using state and implementing a menu state. Oyyou
    /// link to video: https://www.youtube.com/watch?v=76Mz7ClJLoE
    /// link to github: https://github.com/Oyyou/MonoGame_Tutorials/tree/master/MonoGame_Tutorials/Tutorial013 
    /// </summary>
    public abstract class Component
    {
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);
    }
}
