using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGame.Controls;
using static System.Net.Mime.MediaTypeNames;
using Maze;
using MazeRecursion;

namespace MazeGame.States
{
    public class InputState : State
    {
        private readonly InputField _widthInput;
        private readonly InputField _heightInput;
        private readonly TextField _errorBox;
        private readonly List<Component> _components;

        public InputState(MazeGame game, GraphicsDevice graphicsDevice, ContentManager content)
         : base(game, graphicsDevice, content)
        {
            var inputTexture = _content.Load<Texture2D>("Controls/button");
            var font = _content.Load<SpriteFont>("Fonts/font");

            var widthLabel = new TextField(font)
            {
                Text = "Maze Width: ",
                Position = new Vector2(250, 200)
            };
            _widthInput = new InputField(inputTexture, font, new Vector2(350, 200));
            
            var heightLabel = new TextField(font)
            {
                Text = "Maze Height: ",
                Position = new Vector2(250, 250)
            };
            _heightInput = new InputField(inputTexture, font, new Vector2(350, 250));

            _errorBox = new TextField(font)
            {
                Position = new Vector2(250, 300),
                PenColour = Color.Black,
                Text = "Enter a width and height [5-99]"
            };
            var submitButton = new Button(inputTexture, font)
            {
                Position = new Vector2(300, 400),
                Text = "Generate Maze!"
            };

            // handle events
            submitButton.Click += GenerateRecursiveMaze;
            _widthInput.Click += (s, e) =>
            {
                _widthInput.IsSelected = true;
                _heightInput.IsSelected = false;

            };
            _heightInput.Click += (s, e) =>
            {
                _widthInput.IsSelected = false;
                _heightInput.IsSelected = true;

            };
            _components = new List<Component>()
            {
                widthLabel,
                _widthInput,
                heightLabel,
                _heightInput,
                submitButton,
                _errorBox
            };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            _graphicsDevice.Clear(Color.CornflowerBlue);
            foreach (var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
            {
                component.Update(gameTime);
            }
        }

        private void GenerateRecursiveMaze(object sender, EventArgs e)
        {
            _errorBox.PenColour = Color.Red;
            //assuming valid num done in input field
            if(int.TryParse(_widthInput.Text, out int width) && int.TryParse(_heightInput.Text, out int height))
            {
                if(width >= 5 && width < 100 && height >= 5 && height < 100)
                {
                    if ( width % 2 != 0 && height % 2 != 0)
                    {
                        IMapProvider mapProvider = new MazeRecursion.MazeRecursion();
                        Map recursiveMap = new(mapProvider, int.Parse(_widthInput.Text), int.Parse(_heightInput.Text));

                        _game.ChangeState(new GameState(_game, _graphicsDevice, _content, recursiveMap));
                    }
                    else
                    {
                        _errorBox.Text = "Width and height must be odd numbers!";
                    }
                }
                else
                {
                    _errorBox.Text = "Width and height must be between 5 and 99";
                }
            }
            else
            {
                _errorBox.Text = "Please enter a width and height";
            }
        }
    }
}
