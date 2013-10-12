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

namespace ProgrammingAssignment4
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

        // STUDENTS: DECLARE BOARD AND QUIT BUTTON VARIABLES HERE
        Board board;
        QuitButton quitButton;

        // game state and turn tracking
        static GameState gameState = GameState.Play;
        PlayerType whoseTurn = PlayerType.Human;

        // computer player
        ComputerPlayer computer = new ComputerPlayer();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;

            IsMouseVisible = true;
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

            // STUDENTS: CREATE THE BOARD OBJECT HERE, MAKING SURE THE BOARD IS CENTERED IN THE WINDOW
            board = new Board(Content, WINDOW_WIDTH/2, WINDOW_HEIGHT/2);

            // STUDENTS: CREATE QUIT BUTTON HERE, CENTERED HORIZONTALLY AND WITH A REASONABLE SPACE ABOVE THE BOTTOM OF THE WINDOW
            quitButton = new QuitButton(Content, WINDOW_WIDTH / 2, WINDOW_HEIGHT / 2, GameState.Quit);

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

            // update based on game state
            MouseState mouse = Mouse.GetState();
            if (gameState == GameState.Play)
            {
                if (whoseTurn == PlayerType.Human)
                {
                    // STUDENTS: IF IT'S THE PLAYER'S TURN, LET THE PLAYER TAKE A TURN
                    // SAVE THE BOOLEAN VALUE THE METHOD RETURNS FOR USE IN THE NEXT STEP
                    bool playerTurn = board.TakePlayerTurn(mouse);

                    // STUDENTS: IF THE PLAYER TOOK A TURN, CHANGE WHOSE TURN IT IS
                    if (playerTurn)
                    {
                        ChangeTurn();
                    }
                }
                else
                {
                    // STUDENTS: HAVE THE COMPUTER PLAYER TAKE A TURN AND CHANGE WHOSE TURN IT IS
                    computer.TakeTurn(board);
                    ChangeTurn();
                }

            }
            else if (gameState == GameState.GameOver)
            {
                // STUDENTS: THE GAME IS OVER, SO UPDATE THE QUIT BUTTON
            }
            else
            {
                // game state is quit, so exit the game
                this.Exit();
            }

            // STUDENTS: IF THE GAME IS OVER AND GAME STATE IS GameState.Play, MAKE THE QUIT 
            // BUTTON VISIBLE AND CHANGE gameState TO GameState.GameOver
            if (board.GameOver() && gameState == GameState.Play)
            {
                quitButton.Visible = true;
                gameState = GameState.GameOver;
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

            // STUDENTS: DRAW THE BOARD HERE. IF gameState IS GameState.GameOver, DRAW THE QUIT BUTTON ALSO
            spriteBatch.Begin();
            board.Draw(spriteBatch);

            if (gameState == GameState.GameOver)
            {
                quitButton.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Changes whose turn it is
        /// </summary>
        private void ChangeTurn()
        {
            if (whoseTurn == PlayerType.Human)
            {
                whoseTurn = PlayerType.Computer;
            }
            else
            {
                whoseTurn = PlayerType.Human;
            }
        }

        /// <summary>
        /// Changes the state of the game
        /// </summary>
        /// <param name="newState">the new game state</param>
        public static void ChangeState(GameState newState)
        {
            gameState = newState;
        }
    }
}
