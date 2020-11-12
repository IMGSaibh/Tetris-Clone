using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettrix
{
    class Square
    {
        public Point location;
        public Size size;
        public Color foreColor;
        public Color backColor;

        public Square(Size initialSize, Color initialBackColor, Color initialForeColor) 
        {
            size        = initialSize;
            foreColor   = initialForeColor;
            backColor   = initialBackColor;
        }

        public void Show(System.IntPtr WinHandle) 
        {
            Graphics gameGraphics;
            GraphicsPath graphPath;
            PathGradientBrush brushSquare;
            Color[] surroundColor;
            Rectangle rectSquare;

            // gets graphics obeject of the background picture
            gameGraphics = Graphics.FromHwnd(WinHandle);

            //creates a path consiting of one rectangle
            graphPath = new GraphicsPath();
            rectSquare = new Rectangle(location.X, location.Y, size.Width, size.Height);
            graphPath.AddRectangle(rectSquare);

            //creates gradientbrush that draws the square
            brushSquare = new PathGradientBrush(graphPath);
            brushSquare.CenterColor = foreColor;
            surroundColor = new Color[] { backColor };
            brushSquare.SurroundColors = surroundColor;

            //finally draws the square
            gameGraphics.FillPath(brushSquare, graphPath);




        }
        public void Hide(System.IntPtr WinHandle) 
        {
            Graphics gameGraphics;
            Rectangle rectSquare;


            // gets graphics obeject of the background picture
            gameGraphics = Graphics.FromHwnd(WinHandle);

            //finally draws the square
            rectSquare = new Rectangle(location.X, location.Y, size.Width, size.Height);
            gameGraphics.FillRectangle(new SolidBrush(GameField.backColor), rectSquare);

        }

    }
}
