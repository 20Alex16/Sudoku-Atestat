using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku_Atestat
{
    public partial class Sudoku : Form
    {
        SudokuEngine game;

        public Sudoku()
        {
            InitializeComponent();

            panel1.Parent = this;
            panel1.BackColor = Color.Transparent;

            game = new SudokuEngine(panel1, Properties.Resources.sudokuRez);
            game.Start();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(game.Verifica());
        }
    }
}
