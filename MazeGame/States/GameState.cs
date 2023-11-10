using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Drawing;
using Maze;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using Color = Microsoft.Xna.Framework.Color;
using System;

namespace MazeGame.States
{
    public class GameState : State
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        public const int Pixels = 32;
        private bool _isMazeGenerated;
        private Texture2D _goalTexture;
        private Texture2D _pathTexture;
        private Texture2D _solidTexture;
        private PlayerSprite _player;
        private Map _map;
        private bool _isInitialized;
        

        public GameState(MazeGame game, GraphicsDevice graphicsDevice, ContentManager content, Map map)
          : base(game, graphicsDevice, content)
        {
            _content.RootDirectory = "Content";
            _map = map;
            game.IsMouseVisible = true;

        }
      
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!_isInitialized)
            {
                // Generate Map Grid
                _map.CreateMap();

                // Initialize Player
                _player = new PlayerSprite(_game, _map);
                _game.Components.Add(_player);
            }
            _isInitialized = true;

            _goalTexture = _content.Load<Texture2D>("goal");
            _pathTexture = _content.Load<Texture2D>("path");
            _solidTexture = _content.Load<Texture2D>("solid");

            if (!_isMazeGenerated) // Generate maze & goal Once
            {
                _graphicsDevice.Clear(Color.CornflowerBlue);
                _game.Graphics.PreferredBackBufferHeight = _map.Height * Pixels;
                _game.Graphics.PreferredBackBufferWidth = _map.Width * Pixels;
                _game.Graphics.ApplyChanges();

                spriteBatch.Begin();
                for (int y = 0; y < _map.Height; y++)
                {
                    for (int x = 0; x < _map.Width; x++)
                    {
                        if (_map.MapGrid[y, x] == Block.Solid)
                        {
                            spriteBatch.Draw(_solidTexture, new Vector2(x * Pixels, y * Pixels), new Microsoft.Xna.Framework.Rectangle (0, 0, Pixels, Pixels), Color.White);

                        }
                        else if (_map.MapGrid[y, x] == Block.Empty)
                        {
                            spriteBatch.Draw(_pathTexture, new Vector2(x * Pixels, y * Pixels), new Rectangle(0, 0, Pixels, Pixels), Color.White);
                        }

                    }
                }
                spriteBatch.Draw(_goalTexture, new Vector2(_map.Goal.X * Pixels, _map.Goal.Y * Pixels), new Rectangle(0, 0, Pixels, Pixels), Color.White);
                _logger.Info($"Goal located at X: {_map.Goal.X} Y: {_map.Goal.Y}");
                spriteBatch.End();
            }
            _isMazeGenerated = true;

        }

        public override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                _logger.Info($"User pressed Escape Key...Exiting Game");
                
                _game.Exit();
            }
        }
    }
}
