using Maze;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Runtime.CompilerServices;

namespace MazeGame;

public class MazeGame : Game
{
    private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
    private readonly GraphicsDeviceManager _graphics;
    public const int Pixels = 32;
    private bool _isMazeGenerated;
    private string _filePath;
    private SpriteBatch _spriteBatch;
    private Texture2D _pathTexture;
    private Texture2D _goalTexture;
    private Texture2D _solidTexture;
    private PlayerSprite _player;
    public Map _map;
    public MazeGame(string filePath)
    {
        _filePath = filePath;
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _logger.Info($"Map Loaded from: {_filePath}");
    }

    protected override void Initialize()
    {
        _map = new Map(new MazeFromFile.MazeFromFile(_filePath));
        _map.CreateMap();
        _player = new PlayerSprite(this, _map);
        this.Components.Add( _player );
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _goalTexture = Content.Load<Texture2D>("goal");
        _pathTexture = Content.Load<Texture2D>("path");
        _solidTexture = Content.Load<Texture2D>("solid");
        base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
           || Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            _logger.Info($"User pressed Escape Key...Exiting Game");
            Exit();
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        if(!_isMazeGenerated) // Generate maze & goal Once
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _graphics.PreferredBackBufferHeight = _map.Height * Pixels;
            _graphics.PreferredBackBufferWidth = _map.Width * Pixels;

            _spriteBatch.Begin();
            for (int y = 0; y < _map.Height; y++)
            {
                for (int x = 0; x < _map.Width; x++)
                {
                    if (_map.MapGrid[y, x] == Block.Solid)
                    {
                        _spriteBatch.Draw(_solidTexture, new Vector2(x* Pixels, y* Pixels), new Rectangle(0,0, Pixels, Pixels), Color.White);

                    }
                    else if (_map.MapGrid[y, x] == Block.Empty)
                    {
                        _spriteBatch.Draw(_pathTexture, new Vector2(x * Pixels, y * Pixels), new Rectangle(0, 0, Pixels, Pixels), Color.White);
                    }
        
                }
            }
            _spriteBatch.Draw(_goalTexture, new Vector2(_map.Goal.X * Pixels, _map.Goal.Y * Pixels), new Rectangle(0, 0, Pixels, Pixels), Color.White);
            _logger.Info($"Goal located at X: {_map.Goal.X} Y: {_map.Goal.Y}");
            _spriteBatch.End();
        }
        _isMazeGenerated = true;
        base.Draw(gameTime);
    }
}
