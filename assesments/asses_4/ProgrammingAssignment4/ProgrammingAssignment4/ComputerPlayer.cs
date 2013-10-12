using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingAssignment4
{
    /// <summary>
    /// A computer tic-tac-toe player
    /// </summary>
    public class ComputerPlayer
    {
        #region Fields

        Random rand = new Random();

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ComputerPlayer()
        {
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Takes a turn, placing an O in the best square
        /// </summary>
        /// <param name="board">the board</param>
        public void TakeTurn(Board board)
        {
            // place O in a random open square
            BoardSquare square = board.GetSquare(rand.Next(3), rand.Next(3));
            while (!square.Empty)
            {
                square = board.GetSquare(rand.Next(3), rand.Next(3));
            }
            square.Contents = SquareContents.O;
        }

        #endregion
    }
}
