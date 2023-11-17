using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using MazeGame.Controls;
using System.Windows.Forms;
using Maze;
using Button = MazeGame.Controls.Button;

namespace MazeGame.States
{
    public class MenuState : State
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        private List<Component> _components;
     
        public MenuState(MazeGame game, GraphicsDevice graphicsDevice, ContentManager content): base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("Controls/button");
            var buttonFont = _content.Load<SpriteFont>("Fonts/font");

            // TextField
            var title = new TextField(buttonFont)
            {
                Position = new Vector2(345, 150),
                Text = "Bun Bun Maze",
            };

            // Load maze from file
            var fromFileButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 200),
                Text = "Load File Maze",
            };

            fromFileButton.Click += FromFileClick;

            // Load maze with Recursion algorithm
            var recursionButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 250),
                Text = "Load Recursion Maze",
            };

            // Navigate to InputState 
            recursionButton.Click += RecursionClick;

            // Load maze with Hunt & Kill algorithm
            var huntKillButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 300),
                Text = "Load Hunt & Kill maze",
            };
            huntKillButton.Click += HuntKillClick;
            // Exit game
            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 350),
                Text = "Quit Game",
            };

            quitGameButton.Click += QuitGameClick;

            _components = new List<Component>()
            {
                fromFileButton,
                recursionButton,
                huntKillButton,
                quitGameButton,
                title
            };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            _graphicsDevice.Clear(Color.CornflowerBlue);
            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);
            spriteBatch.End();
        }

        private void FromFileClick(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Title = "Browse Map File to Load";
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.DefaultExt = "txt";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    var filePath = openFileDialog.FileName;
                    IMapProvider mapProvider = new MazeFromFile.MazeFromFile(filePath);
                    Map fileMap = new(mapProvider);
                    _game.ChangeState(new GameState(_game, _graphicsDevice, _content, fileMap));
                    _logger.Info($"Map Loaded from: {filePath}");
                }
            }
        }

        private void RecursionClick(object sender, EventArgs e)
        {
            IMapProvider mapProvider = new MazeRecursion.MazeRecursion();
            _game.ChangeState(new InputState(_game, _graphicsDevice, _content, mapProvider));
        }

        private void HuntKillClick(object sender, EventArgs e)
        {
            IMapProvider mapProvider = new MazeHuntKill.MazeHuntKill();
            _game.ChangeState(new InputState(_game, _graphicsDevice, _content, mapProvider));
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }

        private void QuitGameClick(object sender, EventArgs e)
        {
            _game.Exit();
            MessageBox.Show("Thank you for Playing!", "Bun Bun Maze", MessageBoxButtons.OK);
        }

    }
}
