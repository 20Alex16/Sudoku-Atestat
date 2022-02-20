using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdvancedEffects;

namespace Sudoku_Atestat
{
    public partial class Sudoku : Form
    {
        SudokuEngine game;
        //Transversal_Lines tl;
        //RandomParticles rp;

        public Sudoku()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            new Transversal_Lines(this, -40, 2, Color.Magenta, 20);
            new RandomParticles(this, Color.Aquamarine, 500, 400);

            game = new SudokuEngine(new Point(50,50), 500, this);
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
