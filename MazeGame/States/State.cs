using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

/// <summary>
/// Abstract class which defines what each view of our game should contain.
/// Got the idea from a Youtube tutorial that teaches using state and implementing a menu state. Oyyou
/// link to video: https://www.youtube.com/watch?v=76Mz7ClJLoE
/// link to github: https://github.com/Oyyou/MonoGame_Tutorials/tree/master/MonoGame_Tutorials/Tutorial013 
/// </summary>
namespace MazeGame.States
{
    public abstract class State
    {
        /// <summary>
        /// Used for loading and managing resources (textures, fonts and other assets)
        /// </summary>
        protected ContentManager _content;

        /// <summary>
        /// Represents the graphics hardware
        /// </summary>
        protected GraphicsDevice _graphicsDevice;

        /// <summary>
        /// Represents Maze game which implements Game
        /// </summary>
        protected MazeGame _game;

        public State(MazeGame game, GraphicsDevice graphicsDevice, ContentManager content)
        {
            _game = game;
            _graphicsDevice = graphicsDevice;
            _content = content;
        }
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);

    }
}
