
namespace Sudoku_Atestat
{
    partial class Sudoku
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sudoku));
            this.exit = new System.Windows.Forms.Button();
            this.verifica = new System.Windows.Forms.Button();
            this.credentials = new System.Windows.Forms.Label();
            this.new_game = new System.Windows.Forms.Button();
            this.score_summary = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Transparent;
            this.exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exit.BackgroundImage")));
            this.exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exit.FlatAppearance.BorderSize = 0;
            this.exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.Font = new System.Drawing.Font("GhostMachine", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.Location = new System.Drawing.Point(825, 42);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(100, 60);
            this.exit.TabIndex = 1;
            this.exit.Text = "Iesire";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // verifica
            // 
            this.verifica.BackColor = System.Drawing.Color.Transparent;
            this.verifica.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("verifica.BackgroundImage")));
            this.verifica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.verifica.FlatAppearance.BorderSize = 0;
            this.verifica.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.verifica.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.verifica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.verifica.Font = new System.Drawing.Font("GhostMachine", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verifica.Location = new System.Drawing.Point(29, 42);
            this.verifica.Name = "verifica";
            this.verifica.Size = new System.Drawing.Size(100, 60);
            this.verifica.TabIndex = 2;
            this.verifica.Text = "Verifica";
            this.verifica.UseVisualStyleBackColor = false;
            this.verifica.Click += new System.EventHandler(this.verifica_Click);
            // 
            // credentials
            // 
            this.credentials.AutoSize = true;
            this.credentials.BackColor = System.Drawing.Color.Transparent;
            this.credentials.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.credentials.Font = new System.Drawing.Font("GhostMachine", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.credentials.ForeColor = System.Drawing.Color.DarkViolet;
            this.credentials.Location = new System.Drawing.Point(528, 588);
            this.credentials.Name = "credentials";
            this.credentials.Size = new System.Drawing.Size(424, 26);
            this.credentials.TabIndex = 3;
            this.credentials.Text = "Atestat la informatica -Tripa Alexandru - XII A";
            // 
            // new_game
            // 
            this.new_game.BackColor = System.Drawing.Color.Transparent;
            this.new_game.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("new_game.BackgroundImage")));
            this.new_game.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.new_game.FlatAppearance.BorderSize = 0;
            this.new_game.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.new_game.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.new_game.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.new_game.Font = new System.Drawing.Font("GhostMachine", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_game.Location = new System.Drawing.Point(15, 534);
            this.new_game.Name = "new_game";
            this.new_game.Size = new System.Drawing.Size(100, 60);
            this.new_game.TabIndex = 4;
            this.new_game.Text = "Joc Nou";
            this.new_game.UseVisualStyleBackColor = false;
            this.new_game.Click += new System.EventHandler(this.new_game_Click);
            // 
            // score_summary
            // 
            this.score_summary.AutoSize = true;
            this.score_summary.BackColor = System.Drawing.Color.Transparent;
            this.score_summary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.score_summary.Font = new System.Drawing.Font("GhostMachine", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score_summary.ForeColor = System.Drawing.Color.LawnGreen;
            this.score_summary.Location = new System.Drawing.Point(10, 368);
            this.score_summary.Name = "score_summary";
            this.score_summary.Size = new System.Drawing.Size(95, 26);
            this.score_summary.TabIndex = 5;
            this.score_summary.Text = "summary";
            // 
            // Sudoku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(964, 623);
            this.ControlBox = false;
            this.Controls.Add(this.score_summary);
            this.Controls.Add(this.new_game);
            this.Controls.Add(this.credentials);
            this.Controls.Add(this.verifica);
            this.Controls.Add(this.exit);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Sudoku";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sudoku";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button verifica;
        private System.Windows.Forms.Label credentials;
        private System.Windows.Forms.Button new_game;
        private System.Windows.Forms.Label score_summary;
    }
}

