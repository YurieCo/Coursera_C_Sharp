using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProgrammingAssignment4
{
    /// <summary>
    /// The quit button
    /// </summary>
    class QuitButton
    {
        #region Fields

        // fields for button image
        Texture2D sprite;
        const int IMAGES_PER_ROW = 2;
        int buttonWidth;

        // fields for drawing
        bool visible = false;
        Rectangle drawRectangle = new Rectangle();
        Rectangle sourceRectangle;
        
        // press processing
        GameState pressState;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="contentManager">the content manager for loading content</param>
        /// <param name="x">the x location of the center of the button</param>
        /// <param name="y">the y location of the center of the button</param>
        /// <param name="pressState">the game state to change to when the button is pressed</param>
        public QuitButton(ContentManager contentManager, int x, int y, GameState pressState)
        {
            this.pressState = pressState;
            LoadContent(contentManager);

            // STUDENTS: ADD CODE HERE TO SET THE DRAW RECTANGLE X AND Y PROPERTIES
            // TO CENTER THE BUTTON AT THE GIVEN X AND Y
            drawRectangle.X = x - drawRectangle.Width / 2;
            drawRectangle.Y = y - drawRectangle.Height / 2;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Sets whether or not the quit button is visible
        /// </summary>
        public bool Visible
        {
            set { visible = value; }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Updates the menu button. May highlight the button or detect button click
        /// </summary>
        /// <param name="mouse">the current mouse state</param>
        public void Update(MouseState mouse)
        {
            // check for mouse over button
            if (drawRectangle.Contains(mouse.X, mouse.Y))
            {
                // highlight button
                sourceRectangle.X = buttonWidth;

                // check for button pressed
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    Game1.ChangeState(pressState);
                }
            }
            else
            {
                sourceRectangle.X = 0;
            }
        }

        /// <summary>
        /// Draws the menu button
        /// </summary>
        /// <param name="spriteBatch">Reference to a spritebatch object</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {
                spriteBatch.Draw(sprite, drawRectangle, sourceRectangle, Color.White);
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Loads the content for the quit button
        /// </summary>
        /// <param name="contentManager">the content manager to use</param>
        private void LoadContent(ContentManager contentManager)
        {
            // load the sprite
            sprite = contentManager.Load<Texture2D>("quitbutton");

            // calculate button width
            buttonWidth = sprite.Width / IMAGES_PER_ROW;

            // set initial draw and source rectangles
            drawRectangle.Width = buttonWidth;
            drawRectangle.Height = sprite.Height;
            sourceRectangle = new Rectangle(0, 0, buttonWidth, sprite.Height);
        }

        #endregion
    }
}
