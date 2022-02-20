
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
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.Location = new System.Drawing.Point(825, 42);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(99, 56);
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
            this.verifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verifica.Location = new System.Drawing.Point(29, 42);
            this.verifica.Name = "verifica";
            this.verifica.Size = new System.Drawing.Size(99, 56);
            this.verifica.TabIndex = 2;
            this.verifica.Text = "Verifica";
            this.verifica.UseVisualStyleBackColor = false;
            this.verifica.Click += new System.EventHandler(this.verifica_Click);
            // 
            // Sudoku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(964, 623);
            this.ControlBox = false;
            this.Controls.Add(this.verifica);
            this.Controls.Add(this.exit);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Sudoku";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewAge Sudoku";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button verifica;
    }
}

