using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using ExplodingTeddies;

namespace Lab10
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        const int WINDOW_WIDTH = 800;
        const int WINDOW_HEIGHT = 600; 

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        TeddyBear teddy0;
        TeddyBear teddy1;
        Explosion explode0;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT; 
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            // velocity information
            //Vector2 velocity1 = new Vector2(1, 0);
            //Vector2 velocity2 = new Vector2(-1, 0);
            // create teddy bears
            teddy0 = new TeddyBear(Content, WINDOW_WIDTH, WINDOW_HEIGHT, "teddybear0", 100, 200, new Vector2(4, 0));
            teddy1 = new TeddyBear(Content, WINDOW_WIDTH, WINDOW_HEIGHT, "teddybear1", 500, 200, new Vector2(-4, 0));

            explode0 = new Explosion(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            // update game objects
            teddy0.Update();
            teddy1.Update();
            explode0.Update(gameTime);

            // check for collision
            //if (teddy0.Active && teddy1.Active && teddy0.DrawRectangle.X == teddy1.DrawRectangle.X)
            if (teddy0.Active && teddy1.Active && teddy0.DrawRectangle.Intersects(teddy1.DrawRectangle))
            {
                // deactivate bears
                teddy0.Active = teddy1.Active = false;

                // play explosion at approximately the point of collision
                //explode0.Play(teddy0.DrawRectangle.X, teddy0.DrawRectangle.Y);
                Rectangle collisionRectangle = Rectangle.Intersect(teddy0.DrawRectangle, teddy1.DrawRectangle);
                explode0.Play(collisionRectangle.Center.X, collisionRectangle.Center.Y);
            }
            base.Update(gameTime);

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            teddy0.Draw(spriteBatch);
            teddy1.Draw(spriteBatch);
            explode0.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
