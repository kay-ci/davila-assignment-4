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

        protected string _stateName;

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public State(MazeGame game, GraphicsDevice graphicsDevice, ContentManager content, string stateName)
        {
            _game = game;
            _graphicsDevice = graphicsDevice;
            _content = content;
            _stateName = stateName;
        }

        public abstract void Update(GameTime gameTime);

    }
}
