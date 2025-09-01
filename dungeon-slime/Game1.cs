﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;

namespace DungeonSlime
{
    public class Game1 : Core
    {
        // The MonoGame Logo texture
        private Texture2D _logo;

        public Game1() : base("Dungeon Slime", 1280, 720, false)
        {

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {

            // TODO: use this.Content to load your game content here

            base.LoadContent();

            _logo = Content.Load<Texture2D>("images/MonoGameLogo");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        { 
            GraphicsDevice.Clear(Color.Wheat);

            // TODO: Add your drawing code here

            // Begin the sprite batch to prepare for rendering
            SpriteBatch.Begin();

            // Draw the Logo texture
            SpriteBatch.Draw(_logo, Vector2.Zero, Color.White);

            // Always end the sprite batch when done rendering
            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
