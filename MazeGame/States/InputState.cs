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
        private InputField _widthInput;
        private InputField _heightInput;
        private List<Component> _components;
        private InputManager _inputManager;

        public InputState(MazeGame game, GraphicsDevice graphicsDevice, ContentManager content)
         : base(game, graphicsDevice, content)
        {
            _inputManager = InputManager.Instance;
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
            var _heightInput = new InputField(inputTexture, font, new Vector2(350, 250));

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
                submitButton
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

        public override void PostUpdate(GameTime gameTime)
        {

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
            //assuming valid num done in input field
            if (ValidInput(_widthInput.Text) && ValidInput(_heightInput.Text))
            {
                IMapProvider mapProvider = new MazeRecursion.MazeRecursion();
                mapProvider.CreateMap(int.Parse(_widthInput.Text), int.Parse(_heightInput.Text));

                _game.ChangeState(new GameState(_game, _graphicsDevice, _content, mapProvider));
            }
        }

        private bool ValidInput(string input)
        {
            if (int.TryParse(input, out int value))
            {
                if (value >= 5 && value <= 99 && value % 2 != 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
