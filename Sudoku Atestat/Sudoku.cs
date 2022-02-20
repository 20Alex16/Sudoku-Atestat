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

            exit.Parent = this;
            verifica.Parent = this;

            new Transversal_Lines(this, -40, 2, Color.Magenta, 20);
            new RandomParticles(this, Color.Aquamarine, 500, 400);

            new_game.FlatAppearance.MouseOverBackColor = exit.FlatAppearance.MouseOverBackColor = verifica.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 5, 247, 174);

            score_summary.Visible = false;
            game = new SudokuEngine(new Point(220,50), 500, this);
            game.Start();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void verifica_Click(object sender, EventArgs e)
        {
            game.Verifica();

            score_summary.Text =
            $"Scor precedent: \nGresite: {game.gresite} \n" + 
            $"Corecte: {game.nimerite} \n" + 
            $"Rata succes: {Math.Round(100.0*game.nimerite/game.gresite, 2)}%";

            score_summary.Visible = true;
        }

        private void new_game_Click(object sender, EventArgs e)
        {
            game.Reset();
            game.Start();
        }
    }
}
