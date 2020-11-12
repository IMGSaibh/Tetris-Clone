using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nettrix
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void onButton_Start_Click(object sender, EventArgs e)
        {
            Square square = new Square(new Size(20, 20), Color.Blue, Color.Green);
            square.location = new Point(40, 20);
            GameField.backColor = gamefieldBox.BackColor;
            square.Show(gamefieldBox.Handle);

            Block block = new Block(new Point(50, 50), BlockTypes.LINE);
            block.Show(gamefieldBox.Handle);


        }
    }
}
