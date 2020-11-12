using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettrix
{

    public enum BlockTypes 
    {
        UNDEFINED = 0,
        SQAURE = 1,
        LINE = 2,
        J = 3,
        L = 4,
        T = 5,
        Z = 6, 
        S = 7
    }


    class Block
    {

        public BlockTypes blocktype;

        Random random;
        //squares that compose a block
        Square square1;
        Square square2;
        Square square3;
        Square square4;
        private const int squareSize = GameField.squareSize;

        private Color[] backColors = { Color.Empty, Color.Red, Color.Blue, Color.Red, Color.Yellow, Color.Green, Color.White, Color.Black };
        private Color[] foreColors = { Color.Empty, Color.Purple, Color.LightBlue, Color.Yellow, Color.Red, Color.LightGreen, Color.Black, Color.White};

        public BlockTypes blockType
        {
            get { return blockType;  }
            set { blockType = value; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="location"></param>
        /// <param name="newBlocktype"></param>
        public Block(Point location, BlockTypes newBlocktype) 
        {
            if (newBlocktype == BlockTypes.UNDEFINED)
                blocktype = (BlockTypes)(random.Next(7)) + 1;
            else
                blocktype = newBlocktype;

            // set sqaure colors based on blocktype
            square1 = new Square(new Size(squareSize, squareSize), backColors[(int)blocktype], foreColors[(int)blocktype]);
            square2 = new Square(new Size(squareSize, squareSize), backColors[(int)blocktype], foreColors[(int)blocktype]);
            square3 = new Square(new Size(squareSize, squareSize), backColors[(int)blocktype], foreColors[(int)blocktype]);
            square4 = new Square(new Size(squareSize, squareSize), backColors[(int)blocktype], foreColors[(int)blocktype]);

            //set square position based on blocktype

            switch (blocktype)
            {
                case BlockTypes.UNDEFINED:
                    break;
                case BlockTypes.SQAURE:
                    square1.location = new Point(location.X, location.Y);
                    square2.location = new Point(location.X + squareSize, location.Y);
                    square3.location = new Point(location.X, location.Y + squareSize);
                    square4.location = new Point(location.X + squareSize, location.Y + squareSize);
                    break;
                case BlockTypes.LINE:
                    square1.location = new Point(location.X, location.Y);
                    square2.location = new Point(location.X, location.Y +     squareSize);
                    square3.location = new Point(location.X, location.Y + 2 * squareSize);
                    square4.location = new Point(location.X, location.Y + 3 * squareSize);
                    break;
                case BlockTypes.J:
                    square1.location = new Point(location.X, location.Y);
                    square2.location = new Point(location.X, location.Y +     squareSize);
                    square3.location = new Point(location.X, location.Y + 2 * squareSize);
                    square4.location = new Point(location.X, location.Y + 3 * squareSize);
                    break;
                case BlockTypes.L:
                    square1.location = new Point(location.X, location.Y);
                    square2.location = new Point(location.X, location.Y + squareSize);
                    square3.location = new Point(location.X, location.Y + 2 * squareSize);
                    square4.location = new Point(location.X + squareSize, location.Y + 2 * squareSize);
                    break;
                case BlockTypes.T:
                    square1.location = new Point(location.X, location.Y);
                    square2.location = new Point(location.X + squareSize, location.Y);
                    square3.location = new Point(location.X + 2 * squareSize, location.Y);
                    square4.location = new Point(location.X + squareSize, location.Y + squareSize);
                    break;
                case BlockTypes.Z:
                    square1.location = new Point(location.X, location.Y);
                    square2.location = new Point(location.X + squareSize, location.Y);
                    square3.location = new Point(location.X + squareSize, location.Y + squareSize);
                    square4.location = new Point(location.X + 2 * squareSize, location.Y + squareSize);
                    break;
                case BlockTypes.S:
                    square1.location = new Point(location.X, location.Y + squareSize);
                    square2.location = new Point(location.X + squareSize, location.Y + squareSize);
                    square3.location = new Point(location.X + squareSize, location.Y);
                    square4.location = new Point(location.X + 2 * squareSize, location.Y);
                    break;
                default:
                    break;
            }
        }

        public bool Down()
        {
            // If there's no block below the current one, go down         
            if (GameField.IsEmpty(square1.location.X / squareSize, square1.location.Y / squareSize + 1) 
                && GameField.IsEmpty(square2.location.X / squareSize, square2.location.Y / squareSize + 1) 
                && GameField.IsEmpty(square3.location.X / squareSize, square3.location.Y / squareSize + 1) 
                && GameField.IsEmpty(square4.location.X / squareSize, square4.location.Y / squareSize + 1))
            {
                // Hide the block (in the previous position)
                Hide(GameField.WinHandle);
                // Update the block position
                square1.location = new Point(square1.location.X, square1.location.Y + squareSize);
                square2.location = new Point(square2.location.X, square2.location.Y + squareSize);
                square3.location = new Point(square3.location.X, square3.location.Y + squareSize);
                square4.location = new Point(square4.location.X, square4.location.Y + squareSize);
                // Draw the block in the new position
                Show(GameField.WinHandle);
                return true;
            }
            else
            {
                // If there's a block below the current one, doesn't go down 
                // -> put it on the array that controls the game and return FALSE
                GameField.StopSquare(square1, square1.location.X / squareSize, square1.location.Y / squareSize);
                GameField.StopSquare(square2, square2.location.X / squareSize, square2.location.Y / squareSize);
                GameField.StopSquare(square3, square3.location.X / squareSize, square3.location.Y / squareSize);
                GameField.StopSquare(square4, square4.location.X / squareSize, square4.location.Y / squareSize);
                return false;
            }
        }        
        
        //public bool Left() { }
        //public bool Right() { }
        //public void Rotate() { }

        // Draws each square of the block on the game field
        public void Show(System.IntPtr winHandle)
        {
            square1.Show(winHandle);
            square2.Show(winHandle);
            square3.Show(winHandle);
            square4.Show(winHandle);
        }

        // Hides each square of the block on the game field
        public void Hide(System.IntPtr winHandle)
        {
            square1.Hide(winHandle);
            square2.Hide(winHandle);
            square3.Hide(winHandle);
            square4.Hide(winHandle);
        }
    }
}
