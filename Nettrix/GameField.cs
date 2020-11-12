using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettrix
{
    class GameField
    {
		// The game field witdth will be exactly 16 bits (2 bytes)
		public const int width = 16;
		public const int height = 30;

		public static Color backColor;
        public const int squareSize = 10;
        public static System.IntPtr WinHandle;

		//gamefield size is how much squares we want to fit in
		private static Square[,] arrGameField = new Square[width, height];
		private static int[] arrBitGameField = new int[height];

		// x goes from 0 to Width -1
		// y goes from 0 to Height -1
		public static bool IsEmpty(int x, int y)
		{
			// If the Y or X is beyond the game field, return false
			if ((y < 0 || y >= height) || (x < 0 || x >= width))
				return false;
			//  Test the Xth bit of the Yth line of the game field
			else if ((arrBitGameField[y] & (1 << x)) != 0)
				return false;

			return true;
		}

		public static void StopSquare(Square square, int x, int y)
		{
			arrBitGameField[y] = arrBitGameField[y] | (1 << x);
			arrGameField[x, y] = square;
		}
	}
}
