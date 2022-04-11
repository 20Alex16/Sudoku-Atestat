
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
            this.effects = new System.Windows.Forms.Button();
            this.info = new System.Windows.Forms.Button();
            this.info_label = new System.Windows.Forms.Label();
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
            this.exit.Font = new System.Drawing.Font("Seven Segment", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.verifica.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.credentials.Font = new System.Drawing.Font("Seven Segment", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.credentials.ForeColor = System.Drawing.Color.DarkViolet;
            this.credentials.Location = new System.Drawing.Point(420, 592);
            this.credentials.Name = "credentials";
            this.credentials.Size = new System.Drawing.Size(502, 22);
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
            this.new_game.Font = new System.Drawing.Font("Seven Segment", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.score_summary.BackColor = System.Drawing.Color.Silver;
            this.score_summary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.score_summary.Font = new System.Drawing.Font("Seven Segment", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score_summary.ForeColor = System.Drawing.Color.LawnGreen;
            this.score_summary.Location = new System.Drawing.Point(10, 368);
            this.score_summary.Name = "score_summary";
            this.score_summary.Padding = new System.Windows.Forms.Padding(7);
            this.score_summary.Size = new System.Drawing.Size(114, 36);
            this.score_summary.TabIndex = 5;
            this.score_summary.Text = "summary";
            // 
            // effects
            // 
            this.effects.BackColor = System.Drawing.Color.Transparent;
            this.effects.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("effects.BackgroundImage")));
            this.effects.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.effects.FlatAppearance.BorderSize = 0;
            this.effects.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.effects.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.effects.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.effects.Font = new System.Drawing.Font("Seven Segment", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.effects.Location = new System.Drawing.Point(822, 132);
            this.effects.Name = "effects";
            this.effects.Size = new System.Drawing.Size(100, 60);
            this.effects.TabIndex = 6;
            this.effects.Text = "Efecte";
            this.effects.UseVisualStyleBackColor = false;
            this.effects.Click += new System.EventHandler(this.effects_Click);
            // 
            // info
            // 
            this.info.BackColor = System.Drawing.Color.Transparent;
            this.info.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("info.BackgroundImage")));
            this.info.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.info.Cursor = System.Windows.Forms.Cursors.Default;
            this.info.FlatAppearance.BorderSize = 0;
            this.info.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.info.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.info.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.info.Location = new System.Drawing.Point(865, 511);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(60, 60);
            this.info.TabIndex = 7;
            this.info.UseVisualStyleBackColor = false;
            // 
            // info_label
            // 
            this.info_label.AutoSize = true;
            this.info_label.BackColor = System.Drawing.Color.Plum;
            this.info_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.info_label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.info_label.Font = new System.Drawing.Font("MS Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.info_label.ForeColor = System.Drawing.Color.Indigo;
            this.info_label.Location = new System.Drawing.Point(427, 396);
            this.info_label.Name = "info_label";
            this.info_label.Size = new System.Drawing.Size(432, 149);
            this.info_label.TabIndex = 8;
            this.info_label.Text = "Scopul jocului este sa completezi\r\nfiecare celula libera cu un numar\r\nde la 1 la " +
    "9.\r\nPe fiecare rand, coloana sau\r\nzona(3x3 celule) trebuie sa\r\napara fiecare num" +
    "ar o singura data.\r\nSucces!";
            // 
            // Sudoku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(964, 623);
            this.ControlBox = false;
            this.Controls.Add(this.info_label);
            this.Controls.Add(this.info);
            this.Controls.Add(this.effects);
            this.Controls.Add(this.score_summary);
            this.Controls.Add(this.new_game);
            this.Controls.Add(this.credentials);
            this.Controls.Add(this.verifica);
            this.Controls.Add(this.exit);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.Button effects;
        private System.Windows.Forms.Button info;
        private System.Windows.Forms.Label info_label;
    }
}

