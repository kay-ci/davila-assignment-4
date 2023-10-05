﻿using Maze;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    public class PlayerSprite: DrawableGameComponent
    {
        public const int Pixels = 32;
        private readonly Map _map;
        private readonly Game _game;
        private SpriteBatch _spriteBatch;
        private Texture2D _playerTexture;
        private Texture2D _pathTexture;
        private Vector2 _previousPosition;
        private InputManager _inputManager;
        
        public PlayerSprite(Game game, Map map) : base(game)
        {
            _game = game;
            _map = map;
        }
        public override void Initialize()
        {
            _previousPosition = new Vector2(_map.Player.StartX * Pixels, _map.Player.StartY * Pixels);
            _inputManager = InputManager.Instance;
            _inputManager.AddKeyHandler(Keys.Right, () => { _map.Player.TurnRight(); });

            _inputManager.AddKeyHandler(Keys.Left, () => { _map.Player.TurnLeft(); });

            _inputManager.AddKeyHandler(Keys.Down, () => {
                _previousPosition.X = _map.Player.Position.X * Pixels;
                _previousPosition.Y = _map.Player.Position.Y * Pixels;
                _map.Player.MoveForward();
            });

            _inputManager.AddKeyHandler(Keys.Up, () => {
                _previousPosition.X = _map.Player.Position.X * Pixels;
                _previousPosition.Y = _map.Player.Position.Y * Pixels;
                _map.Player.MoveBackward();
            });
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _playerTexture = _game.Content.Load<Texture2D>("bunny");
            _pathTexture = _game.Content.Load<Texture2D>("path");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            _inputManager.Update();
            if (_map.Player.Position.Equals(_map.Goal))
            {
                _game.Exit();
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (_previousPosition.X != _map.Player.Position.X  && _previousPosition.Y != _map.Player.Position.Y)
            {
                _spriteBatch.Begin();
                _spriteBatch.Draw(_pathTexture, _previousPosition, new Rectangle(0, 0, Pixels, Pixels), Color.White);
                _spriteBatch.Draw(
                    _playerTexture, 
                    new Vector2(_map.Player.Position.X * Pixels + (Pixels / 2), _map.Player.Position.Y * Pixels + (Pixels / 2)),
                    new Rectangle(0,0,Pixels,Pixels),
                    Color.White, 
                    _map.Player.GetRotation(),
                    new Vector2(_playerTexture.Width / 2, _playerTexture.Height / 2), 
                    1,
                    SpriteEffects.None,
                    0);
                _spriteBatch.End();
            }
            base.Draw(gameTime);
        }

    }
}
