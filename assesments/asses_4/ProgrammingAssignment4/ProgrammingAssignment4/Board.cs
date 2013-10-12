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
    /// A tic-tac-toe board
    /// </summary>
    public class Board
    {
        #region Fields

        BoardSquare[,] board = new BoardSquare[3,3];

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new board centered at the given location
        /// </summary>
        /// <param name="contentManager">the content manager to use</param>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        public Board(ContentManager contentManager, int x, int y)
        {
            // dynamically get board square dimensions
            int sideLength = BoardSquare.GetSideLength(contentManager);

            // STUDENTS: CALCULATE THE X AND Y OF THE TOP LEFT CORNER OF THE BOARD
            // REPLACE THE 0s BELOW WITH THE APPROPRIATE EQUATIONS
            int leftX = 0;
            int topY = 0;

            // build board squares and add to array
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int column = 0; column < board.GetLength(1); column++)
                {
                    board[row, column] = new BoardSquare(contentManager,
                       leftX + (column * sideLength) + sideLength / 2,
                       topY + (row * sideLength) + sideLength / 2);
                }
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Draws the board
        /// </summary>
        /// <param name="spriteBatch">the sprite batch to use</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // draw board squares
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int column = 0; column < board.GetLength(1); column++)
                {
                    board[row, column].Draw(spriteBatch);
                }
            }
        }

        /// <summary>
        /// Lets the player potentially take a turn
        /// </summary>
        /// <param name="mouse">the current mouse state</param>
        /// <returns>true if the player took a turn, false otherwise</returns>
        public bool TakePlayerTurn(MouseState mouse)
        {
            // update board squares
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int column = 0; column < board.GetLength(1); column++)
                {
                    bool tookTurn = board[row, column].Update(mouse);
                    if (tookTurn)
                    {
                        return true;
                    }
                }
            }

            // player didn't place an X
            return false;
        }

        /// <summary>
        /// Gets the square at the given row and column on the board
        /// </summary>
        /// <param name="row">the row</param>
        /// <param name="column">the column</param>
        /// <returns>the board square</returns>
        public BoardSquare GetSquare(int row, int column)
        {
            if (row < board.GetLength(0) &&
                column < board.GetLength(1))
            {
                return board[row, column];
            }
            else
            {
                throw new Exception("Board.GetSquare: Invalid row or column!");
            }
        }

        /// <summary>
        /// Tells whether or not the game is over
        /// </summary>
        /// <returns>true if the game is over, false otherwise</returns>
        public bool GameOver()
        {
            return RowWin(SquareContents.X) || RowWin(SquareContents.O) ||
                ColumnWin(SquareContents.X) || ColumnWin(SquareContents.O) ||
                DiagonalWin(SquareContents.X) || DiagonalWin(SquareContents.O) ||
                BoardFull();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Tells whether or not the given square contents wins on a row
        /// </summary>
        /// <param name="contents">the square contents to check</param>
        /// <returns>true for a win on a row, false otherwise</returns>
        private bool RowWin(SquareContents contents)
        {
            return (board[0, 0].Contents == contents && board[0, 1].Contents == contents && board[0, 2].Contents == contents) ||
                (board[1, 0].Contents == contents && board[1, 1].Contents == contents && board[1, 2].Contents == contents) ||
                (board[2, 0].Contents == contents && board[2, 1].Contents == contents && board[2, 2].Contents == contents);
        }

        /// <summary>
        /// Tells whether or not the given square contents wins on a column
        /// </summary>
        /// <param name="contents">the square contents to check</param>
        /// <returns>true for a win on a column, false otherwise</returns>
        private bool ColumnWin(SquareContents contents)
        {
            return (board[0, 0].Contents == contents && board[1, 0].Contents == contents && board[2, 0].Contents == contents) ||
                (board[0, 1].Contents == contents && board[1, 1].Contents == contents && board[2, 1].Contents == contents) ||
                (board[0, 2].Contents == contents && board[1, 2].Contents == contents && board[2, 2].Contents == contents);
        }

        /// <summary>
        /// Tells whether or not the given square contents wins on a diagonal
        /// </summary>
        /// <param name="contents">the square contents to check</param>
        /// <returns>true for a win on a diagonal, false otherwise</returns>
        private bool DiagonalWin(SquareContents contents)
        {
            return (board[0, 0].Contents == contents && board[1, 1].Contents == contents && board[2, 2].Contents == contents) ||
                (board[2, 0].Contents == contents && board[1, 1].Contents == contents && board[0, 2].Contents == contents);
        }

        /// <summary>
        /// Tells whether or not the board is full
        /// </summary>
        /// <returns>true if the board is full, false otherwise</returns>
        private bool BoardFull()
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int column = 0; column < board.GetLength(1); column++)
                {
                    if (board[row, column].Empty)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        #endregion
    }
}
