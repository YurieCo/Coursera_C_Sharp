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
    /// A single square for a tic-tac-toe board
    /// </summary>
    public class BoardSquare
    {
        #region Fields

        SquareContents contents = SquareContents.Empty;

        // drawing support
        Texture2D squareSprite;
        Texture2D xSprite;
        Texture2D oSprite;
        Rectangle drawRectangle = new Rectangle();

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new board square centered at the given location
        /// </summary>
        /// <param name="contentManager">the content manager to use</param>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        public BoardSquare(ContentManager contentManager, int x, int y)
        {
            LoadContent(contentManager);

            // STUDENTS: ADD CODE HERE TO SET THE DRAW RECTANGLE X AND Y PROPERTIES
            // TO CENTER THE SQUARE AT THE GIVEN X AND Y. REPLACE THE 0s BELOW WITH 
            // THE APPROPRIATE EQUATIONS
            drawRectangle.X = 0;
            drawRectangle.Y = 0;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets and sets the contents of the square
        /// </summary>
        public SquareContents Contents
        {
            get { return contents; }
            set { contents = value; }
        }

        /// <summary>
        /// Gets whether or not the square is empty
        /// </summary>
        public bool Empty
        {
            get { return contents == SquareContents.Empty;  }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Updates the board square
        /// </summary>
        /// <param name="mouse">the current mouse state</param>
        /// <returns>true if the player placed an X, false otherwise</returns>
        public bool Update(MouseState mouse)
        {
            // STUDENTS: IF THE MOUSE IS OVER THE SQUARE, THE LEFT MOUSE BUTTON IS PRESSED
            // AND THE SQUARE CONTENTS IS EMPTY CHANGE THE CONTENTS TO HOLD AN X AND RETURN true. 
            // OTHERWISE, RETURN false
            // if (<students add Boolean expression here>)
            // {
            //     <students add code here>
            //     return true;
            // }
            // else
            // {
            //     return false;
            // }

            // STUDENTS: REMOVE THE LINE BELOW AFTER UNCOMMENTING AND COMPLETING THE CODE ABOVE
            return false;
        }

        /// <summary>
        /// Draws the board square
        /// </summary>
        /// <param name="spriteBatch">the sprite batch to use</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // STUDENTS: DRAW THE SQUARE SPRITE
 
            // STUDENTS: IF THE SQUARE HOLDS AN X, DRAW THE X SPRITE
            // OTHERWISE, IF THE SQUARE HOLDS AN O, DRAW THE O SPRITE
        }


        /// <summary>
        /// Gets the side length for a board square
        /// </summary>
        /// <param name="contentManager">the content manager</param>
        /// <returns>the side length</returns>
        public static int GetSideLength(ContentManager contentManager)
        {
            BoardSquare tempSquare = new BoardSquare(contentManager, 0, 0);
            return tempSquare.drawRectangle.Width;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Loads the content for the board square
        /// </summary>
        /// <param name="contentManager">the content manager to use</param>
        private void LoadContent(ContentManager contentManager)
        {
            // load content and set size of draw rectangle
            squareSprite = contentManager.Load<Texture2D>("square");
            xSprite = contentManager.Load<Texture2D>("x");
            oSprite = contentManager.Load<Texture2D>("o");
            drawRectangle.Width = squareSprite.Width;
            drawRectangle.Height = squareSprite.Height;
        }

        #endregion

    }
}
