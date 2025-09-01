using Microsoft.Xna.Framework;
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

            //Ex 1. Draw the Logo texture centered
            //SpriteBatch.Draw(
            //    _logo,
            //    new Vector2(
            //        (Window.ClientBounds.Width * 0.5f) - (_logo.Width * 0.5f),
            //        (Window.ClientBounds.Height * 0.5f) - (_logo.Height * 0.5f)), 
            //    Color.Red);


            //Ex 2. Draw the logo texture centered
            SpriteBatch.Draw(
                _logo,                                  // texture
                new Vector2(                            // position
                    (Window.ClientBounds.Width * 0.5f),
                    (Window.ClientBounds.Height * 0.5f)),
                null,                                   // source rectangle (null draws the entire texture)
                Color.White * 0.5f,                            // color
                0.0f,                                   // rotation
                new Vector2(                            // origin            
                    _logo.Width,
                    _logo.Height) * 0.5f,
                1.0f,                                   // scale
                SpriteEffects.None,                     // effects
                0.0f                                    // layer depth
            );

            // Ex 3. Draw the logo texture in the bottom right corner
            Rectangle iconSourceRect = new Rectangle(0, 0, 128, 128);

            SpriteBatch.Draw(
                _logo,                                  // texture
                new Vector2(                            // position
                    Window.ClientBounds.Width,
                    Window.ClientBounds.Height),
                iconSourceRect,                        // source rectangle (null draws the entire texture)
                Color.White,                           // color
                0.0f,                                   // rotation
                new Vector2(                            // origin            
                    iconSourceRect.Width,
                    iconSourceRect.Height),
                1.0f,                                   // scale
                SpriteEffects.None,                     // effects
                0.0f                                    // layer depth
            );

            // Ex 4. Draw Text logo on top left corner
            Rectangle wordmarkSourceRect = new Rectangle(150, 34, 458, 58);

            SpriteBatch.Draw(
                _logo,
                Vector2.Zero,
                wordmarkSourceRect,
                Color.White,
                0.0f,
                Vector2.Zero,
                1.0f,
                SpriteEffects.None,
                0.0f
            );

            // When using layer depth, make sure to set SpriteSortMode.BackToFront or .FrontToBack
            // in SpriteBatch.Begin()

            // Always end the sprite batch when done rendering
            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
