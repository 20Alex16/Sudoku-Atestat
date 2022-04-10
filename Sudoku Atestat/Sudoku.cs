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
        Transversal_Lines tl;
        RandomParticles rp;

        public Sudoku()
        {
            InitializeComponent();

            exit.Parent = this;
            verifica.Parent = this;

            tl = new Transversal_Lines(this, -40, 2, Color.Magenta, 20);
            rp = new RandomParticles(this, Color.Aquamarine, 500, 600);

            new_game.FlatAppearance.MouseOverBackColor =
                exit.FlatAppearance.MouseOverBackColor =
                verifica.FlatAppearance.MouseOverBackColor =
                effects.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(70, 5, 247, 174);

            
            exit.Font =
                verifica.Font =
                credentials.Font =
                new_game.Font =
                effects.Font =
                score_summary.Font = 
                new Font(UseCustomFont.getFont(), 17F, FontStyle.Bold);
            

            score_summary.Visible = false;
            score_summary.BackColor = Color.FromArgb(200, 50,50,50);
            game = new SudokuEngine(new Point(250,50), 500, this);
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
            $"Scor precedent: \nSpatii: {game.gresite + game.nimerite}\n" +
            $"Gresite: {game.gresite} \n" +
            $"Corecte: {game.nimerite} \n" +
            $"Rata succes: {Math.Round(100.0 * game.nimerite / (game.gresite + game.nimerite), 2)}%";

            score_summary.Visible = true;
        }

        private void new_game_Click(object sender, EventArgs e)
        {
            game.Reset();
            game.Start();
        }

        private void effects_Click(object sender, EventArgs e)
        {
            tl.ToggleActivation();
            rp.ToggleActivation();
            Refresh();
        }
    }
}
