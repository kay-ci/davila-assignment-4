using Maze;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Runtime.CompilerServices;

namespace MazeGame;

public class MazeGame : Game
{
    private GraphicsDeviceManager _graphics;
    public Map _map;
    private SpriteBatch _spriteBatch;
    private Texture2D _pathTexture;
    private Texture2D _bunnyTexture;
    private Texture2D _goalTexture;
    private Texture2D _solidTexture;
    
    private bool _isMazeGenerated;
    private PlayerSprite _player;

    public MazeGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        string filePath = "C:\\Users\\kayci\\School\\Programming_V\\davila-assignement-2\\map9x13.txt";
        _map = new Map(new MazeFromFile.MazeFromFile(filePath));
        _map.CreateMap();
        _player = new PlayerSprite(this, _map);
        this.Components.Add( _player );
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _bunnyTexture = Content.Load<Texture2D>("bunny");
        _goalTexture = Content.Load<Texture2D>("goal");
        _pathTexture = Content.Load<Texture2D>("path");
        _solidTexture = Content.Load<Texture2D>("solid");
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        // TODO: Add your update logic here

        base.Update(gameTime);
        _isMazeGenerated = false;
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        int pixels = 32;
        _spriteBatch.Begin();
        // TODO: Add your drawing code here
        if(!_isMazeGenerated)
        {
            _graphics.PreferredBackBufferHeight = _map.Height * pixels;
            _graphics.PreferredBackBufferWidth = _map.Width * pixels;
            _graphics.ApplyChanges();
            for (int y = 0; y < _map.Height; y++)
            {
                for (int x = 0; x < _map.Width; x++)
                {
                    if (_map.MapGrid[y, x] == Block.Solid)
                    {
                        _spriteBatch.Draw(_solidTexture, new Vector2(x* pixels, y* pixels), new Rectangle(0,0, pixels, pixels), Color.White);

                    }
                    else if (_map.MapGrid[y, x] == Block.Empty)
                    {
                        _spriteBatch.Draw(_pathTexture, new Vector2(x * pixels, y * pixels), new Rectangle(0, 0, pixels, pixels), Color.White);
                    }
        
                }
            }
            _spriteBatch.Draw(_goalTexture, new Vector2(_map.Goal.X * pixels, _map.Goal.Y * pixels), new Rectangle(0, 0, pixels, pixels), Color.White);
        }
        _spriteBatch.End(); 
        base.Draw(gameTime);
    }
}
