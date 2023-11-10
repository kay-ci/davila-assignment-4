using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

/// <summary>
/// Abstract class which defines what each view of our game should contain.
/// </summary>
namespace MazeGame.States
{
    public abstract class State
    {
        protected ContentManager _content;

        protected GraphicsDevice _graphicsDevice;

        protected MazeGame _game;

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public State(MazeGame game, GraphicsDevice graphicsDevice, ContentManager content)
        {
            _game = game;
            _graphicsDevice = graphicsDevice;
            _content = content;
        }

        public abstract void Update(GameTime gameTime);

    }
}
