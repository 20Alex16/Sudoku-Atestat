using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku_Atestat
{
    public class SudokuEngine
    {
        private matrice9x9 mat; // matrice de numere(byte)
        private matriceSudoku9x9 matB; // matrice de butoane
        private int missingNumbers;
        private Random randomObject;
        private DropdownMenu9b dropdown;

        public SudokuEngine(Point gameLocation, int gameSize, Form container)
        {
            dropdown = new DropdownMenu9b(container, new string[]{ // butoane de la 1 la 9
                "1", "2", "3", "4", "5", "6", "7", "8", "9"
            });
            dropdown.Parent = container;

            mat = new matrice9x9(); // generam o matrice noua la fiecare joc nou //solvedMatrix);
            mat.Shuffle();

            randomObject = new Random(); randomObject.Next(); // refresh
            missingNumbers = randomObject.Next(10, 25);

            matB = new matriceSudoku9x9(container, gameLocation, gameSize, mat, missingNumbers, dropdown, 5);
        }

        public int nimerite
        {
            get { return matB.gameScore.nailedCells; }
        }

        public int gresite
        {
            get { return matB.gameScore.wrongCells; }
        }

        public void Reset() // joc nou
        {
            mat = new matrice9x9();
            mat.Shuffle();
            missingNumbers = randomObject.Next(10, 25);
            matB.NewGame(mat, missingNumbers);
        }

        public void Start() => matB.StartGame();

        public bool isRunning() => matB.isRunning();

        public bool Verifica() => matB.Check();
    }

    public class matrice9x9
    {
        private byte[,] mat;
        private Generare_matrice_sudoku.SudokuGenerator generator = new Generare_matrice_sudoku.SudokuGenerator();

        public matrice9x9(string solvedMatrix) { // varianta 1: citire din fisier
            mat = new byte[9, 9];
            int i = 0, j = 0;
            foreach (var strRow in solvedMatrix.Split('\n'))
            {
                j = 0;
                foreach (var strValue in strRow.Split(' '))
                {
                    mat[i, j++] = Convert.ToByte(strValue);
                }
                i++;
                if (i == 9) break; // this is for testing
            }
        }

        public matrice9x9() // varianta 2: generare backtracking
        {            
            mat = generator.GenereazaMatrice();
        }

        public matrice9x9 AlterNewMatrix(int changesLeft) // restricted to 30 missing places!
        {
            changesLeft = clamp(changesLeft, 5, 30);
            matrice9x9 rez = new matrice9x9();
            for (int i = 0; i < 9; i++) // shallow copy
                for (int j = 0; j < 9; j++)
                    rez.mat[i, j] = this.mat[i, j];

            // now make some variables go poof!
            Random rand = new Random(); rand.Next(); // refresh
            int x, y; // parameter naming issue =//
            while(changesLeft > 0)
            {
                x = rand.Next(0,9);
                y = rand.Next(0,9);

                if(rez.mat[x,y] != 0)
                {
                    rez.mat[x, y] = 0;
                    changesLeft--;
                }
            }

            return rez;
        }

        public int clamp(int x, int mi, int ma) => Math.Min(ma, Math.Max(x,mi));

        #region matrixShuffle
        public void Shuffle() // @TODO: Shuffle with random actions
        {
            //List<Func<matrice9x9>> shuffleFuncList = new List<Func<matrice9x9>>();
            //shuffleFuncList.Add(Rot180);
            //shuffleFuncList.Add(RotRight90);
            //shuffleFuncList.Add(RotLeft90);
            //shuffleFuncList.Add(MirrorHorizontally);
            //shuffleFuncList.Add(MirrorVertically);
            //shuffleFuncList.Add(MirrorPrincipalDiagonal);
            //shuffleFuncList.Add(MirrorSecondaryDiagonal);

            Random rand = new Random(); rand.Next();
            for(int i = 1; i < rand.Next(5,10); i++)
            {
                switch (rand.Next(1, 7))
                {
                    case 0: this.Rot180(); break;
                    case 1: this.RotRight90(); break;
                    case 2: this.RotLeft90(); break;
                    case 3: this.MirrorHorizontally(); break;
                    case 4: this.MirrorVertically(); break;
                    case 5: this.MirrorPrincipalDiagonal(); break;
                    case 6: this.MirrorSecondaryDiagonal(); break;
                    default: break; // no transformation
                }
            }
            
        }

        private static void ShuffleList<T>(IList<T> list, Random rng)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private void swap(ref byte a, ref byte b)
        {
            byte c = b;
            b = a;
            a = c;
        }

        private matrice9x9 Rot180()
        {
            this.MirrorPrincipalDiagonal().MirrorSecondaryDiagonal();

            return this;
        }

        private matrice9x9 RotRight90()
        {
            this.MirrorSecondaryDiagonal().MirrorVertically();

            return this;
        }

        private matrice9x9 RotLeft90()
        {
            this.MirrorSecondaryDiagonal().MirrorVertically();

            return this;
        }

        private matrice9x9 MirrorHorizontally()
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 9; j++)
                    swap(ref mat[i,j], ref mat[9-i-1,j]);

            return this;
        }

        private matrice9x9 MirrorVertically()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 5; j++)
                    swap(ref mat[i, j], ref mat[i, 9-j-1]);

            return this;
        }

        private matrice9x9 MirrorPrincipalDiagonal()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < i; j++)
                    swap(ref mat[i,j], ref mat[j,i]);

            return this;
        }

        private matrice9x9 MirrorSecondaryDiagonal()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 9 - i - 1; j++)
                    swap(ref mat[i, j], ref mat[9 - j - 1, 9 - i - 1]);

            return this;
        }
        #endregion

        public byte[,] getMatrix()
        {
            return mat;
        }

        public void print()
        {
            for(int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                    Console.Write(mat[i,j] + " ");
                Console.WriteLine();
            }
        }
    }

    public class matriceSudoku9x9
    {
        public struct score
        {
            public int nailedCells; // { public get; public set; }
            public int wrongCells; // { public get; public set; }

            public score(int nc = 0, int wc = 0)
            {
                this.nailedCells = nc;
                this.wrongCells = wc;
            }
        }

        private ButtonSudoku[,] mat;
        private Form container;
        private DropdownMenu9b dropdown;
        private ButtonSudoku selectedButton = null;
        private int buttonShadowWidth = 3;
        private RevealValue valoare_adevarata;

        private int gameSize;
        private bool gameState = false;
        public score gameScore;

        private Color colorBdefault = Color.FromArgb(45,226,230);
        private Color colorBPending = Color.FromArgb(3,94,232);
        private Color colorBCompletion = Color.FromArgb(234, 187, 252);
        private Color colorBRight = Color.LightGreen;
        private Color colorBWrong = Color.FromArgb(222, 128, 109);
        private Color colorBSelected = Color.FromArgb(254, 117, 254);
        private Color foreColor = Color.FromArgb(151,0,204);
        private Color mouseOverColor = Color.FromArgb(232, 194, 3);

        public matriceSudoku9x9(Form c, Point gl, int gs, matrice9x9 m, int missingNumbers, DropdownMenu9b drpmnu, int padding = 12)
        {
            container = c;
            dropdown = drpmnu;
            gameSize = gs;
            gameScore = new score();
            mat = new ButtonSudoku[9,9];

            int startX = gl.X, startY = gl.Y;

            int sz = gameSize; //Math.Min(gameWidth, gameHeight); // totalSize
            int szB = (sz-8*padding)/9; // buttonSize

            valoare_adevarata = new RevealValue(container, szB, szB, 22, foreColor, Color.Yellow);

            byte[,] fullMatrix = m.getMatrix();
            byte[,] fillMatrix = m.AlterNewMatrix(missingNumbers).getMatrix();

            for(int i = 0; i < 9; i++)
                for(int j = 0; j < 9; j++)
                {
                    ButtonSudoku b = new ButtonSudoku()
                    {
                        Width = szB,
                        Height = szB,
                        Location = new Point(i*(padding+szB) + startX + (i/3) * padding, j*(padding+szB) + startY + (j/3) * padding),
                        expectedNumber = fullMatrix[i,j],
                        Text = (fillMatrix[i, j] != 0 ? m.getMatrix()[i, j].ToString() : ""),
                        BackColor = (fillMatrix[i, j] != 0 ? colorBdefault : colorBPending),
                        isPlayable = fillMatrix[i,j] == 0,
                        butonI = i,
                        butonJ = j
                    };
                    //b.Font = new Font("Seven Segment", 22F);//new Font("Microsoft Sans Serif", 22F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    b.Font = new Font(UseCustomFont.getFont(), 22F, FontStyle.Bold);//"Seven Segment", 22F);//new Font("Microsoft Sans Serif", 22F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    b.FlatAppearance.MouseOverBackColor = b.isPlayable ? mouseOverColor : Color.Empty;
                    b.ForeColor = foreColor;

                    b.Click += (o, e) =>
                    {
                        if (!b.isPlayable) return;
                        if (!gameState) return;

                        if (selectedButton == b)
                        {
                            deselectButton();
                            dropdown.Visible = false;
                        }
                        else
                        {
                            selectButton(b);

                            dropdown.Location = new Point(
                                b.Location.X + (b.butonI > 6 ? -dropdown.Width-1 : b.Width+1),
                                b.Location.Y + (b.butonJ > 6 ? -dropdown.Height+b.Height-2 : 0)
                            );

                            dropdown.Visible = true;
                        }
                    };

                    b.MouseEnter += (o, e) =>
                    {
                        if (gameState) return;
                        if (!b.isPlayable) return;
                        if (b.expectedNumber.ToString() == b.Text) return;

                        valoare_adevarata.Value = b.expectedNumber;

                        valoare_adevarata.Location = new Point(
                            b.Location.X + (b.butonI > 6 ? -valoare_adevarata.Width - 3 : valoare_adevarata.Width + 3),
                            b.Location.Y + (b.butonJ > 6 ? -valoare_adevarata.Height - 3 : valoare_adevarata.Height + 3)
                        );
                        valoare_adevarata.Visible = true;
                    };

                    b.MouseLeave += (o, e) => valoare_adevarata.Visible = false;

                    mat[i, j] = b;
                    b.Parent = container;
                }

            dropdown.ButtonPicked += (o, e) =>
            {
                if (selectedButton != null)
                {
                    selectedButton.Text = ((Button9EventArgs)e).value.ToString();
                    selectedButton.BackColor = colorBCompletion;
                }
                dropdown.Visible = false;
            };

            Brush br = new SolidBrush(Color.Tomato);
            Brush brShadow = new SolidBrush(foreColor); //FromArgb(204, 37, 37));

            container.Paint += (o, e) =>
            {
                //e.Graphics.FillRectangle(br, startX, 2 * padding + 3 * szB + startY, 8 * padding + 9 * szB, padding); // horizontal upper
                //e.Graphics.FillRectangle(br, startX, 5 * padding + 6 * szB + startY, 8 * padding + 9 * szB, padding); // horizontal lower

                //e.Graphics.FillRectangle(br, 2 * padding + 3 * szB + startX, startY, padding, 8 * padding + 9 * szB); // vertical left
                //e.Graphics.FillRectangle(br, 5 * padding + 6 * szB + startX, startY, padding, 8 * padding + 9 * szB); // vertical right

                applyButtonShadow(e.Graphics, brShadow);
            };
        }

        public void NewGame(matrice9x9 m, int missingNumbers)
        {
            dropdown.Visible = false;
            valoare_adevarata.Visible = false;
            selectedButton = null;
            gameState = false; // still required to press start

            byte[,] fullMatrix = m.getMatrix();
            byte[,] fillMatrix = m.AlterNewMatrix(missingNumbers).getMatrix();

            //renew button texts and their colors
            //renew isplayable!!!

            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    ButtonSudoku b = mat[i, j];
                    b.Text = (fillMatrix[i, j] != 0 ? m.getMatrix()[i, j].ToString() : "");
                    b.BackColor = (fillMatrix[i, j] != 0 ? colorBdefault : colorBPending);
                    b.isPlayable = fillMatrix[i, j] == 0;
                    b.expectedNumber = fullMatrix[i, j];
                    b.FlatAppearance.MouseOverBackColor = b.isPlayable ? mouseOverColor : Color.Empty;
                }

        }

        public bool isRunning() => gameState;

        public void StartGame() => gameState = true;

        public bool Check()
        {
            gameState = false;
            dropdown.Visible = false;
            deselectButton();

            bool ok = true;
            gameScore.nailedCells = gameScore.wrongCells = 0;

            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (!mat[i, j].isOk())
                    {
                        ok = false;
                        mat[i, j].BackColor = colorBWrong;
                        gameScore.wrongCells++;
                    }
                    else
                        if (mat[i, j].isPlayable)
                        {
                            mat[i, j].BackColor = colorBRight;
                            gameScore.nailedCells++;
                        }

            return ok;
        }

        private void selectButton(ButtonSudoku b) // this should be used only when running the game
        {
            deselectButton();

            selectedButton = b;
            selectedButton.BackColor = colorBSelected;
        }

        private void deselectButton() // this should be used only when running the game
        {
            if (selectedButton == null) return;

            if (selectedButton.Text != "")
                selectedButton.BackColor = colorBCompletion;
            else
                selectedButton.BackColor = colorBPending;

            selectedButton = null;
        }

        public void applyButtonShadow(Graphics gr, Brush br)
        {
            foreach (var btn in mat)
            {
                gr.FillRectangle(br, btn.Location.X + btn.Width, btn.Location.Y, buttonShadowWidth, btn.Height+ buttonShadowWidth); // vert
                gr.FillRectangle(br, btn.Location.X, btn.Location.Y + btn.Height, btn.Width, buttonShadowWidth); // horiz
            }
        }
    }

    public class ButtonSudoku : Button
    {
        public byte expectedNumber = 0;
        public bool isPlayable;
        public int butonI, butonJ;

        public ButtonSudoku()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
        }

        public bool isOk()
        {
            if (!isPlayable) return true;
            if (Text == "") return false;
            return Convert.ToByte(Text) == expectedNumber;
        }
    }

    public class DropdownMenu9b : Panel
    {
        private int bSize = 35;
        private List<Button> buttonList;
        private int padding = 2;

        public event EventHandler ButtonPicked;

        public DropdownMenu9b(Form container, object[] items, int x = 0, int y = 0)
        {
            Location = new Point(x, y);
            Size = new Size(bSize*3+2*padding, bSize*3+2*padding);
            buttonList = new List<Button>();
            Visible = false;
            Parent = container;
            BackColor = Color.CadetBlue;

            for(int i = 0; i < 3; i++)
                for(int j = 0; j < 3; j++)
                {
                    Button b = new Button()
                    {
                        Location = new Point(i * (bSize + padding), j * (bSize + padding)),
                        Size = new Size(bSize, bSize),
                        //Font = new Font("Seven Segment", 16),
                        //Font = new Font(UseCustomFont.getFont(), 16F, FontStyle.Bold), //"Seven Segment", 16),
                        Font = new Font(UseCustomFont.getFont(), 16F, FontStyle.Bold),
                        FlatStyle = FlatStyle.Flat,
                        BackColor = Color.Aquamarine,
                        Text = (j*3+i+1).ToString(),
                        ForeColor = Color.DarkBlue
                        //Parent = container
                    };

                    b.FlatAppearance.MouseOverBackColor = Color.CadetBlue;
                    b.FlatAppearance.BorderSize = 0;
                    b.Click += (o, e) => ButtonPicked?.Invoke(this, new Button9EventArgs(Convert.ToInt32(b.Text)));

                    buttonList.Add(b);
                    b.Parent = this;
                }
        }
    }

    public class RevealValue : Label
    {
        private int value = 0;

        public RevealValue(Form container, int sizeX, int sizeY, int fSize, Color fc, Color bc)
        {
            Text = value.ToString();
            Size = new Size(sizeX, sizeY);
            ForeColor = fc;
            BackColor = bc;
            Font = new Font(UseCustomFont.getFont(), fSize, FontStyle.Bold);
            Visible = false;
            Parent = container;

            TextAlign = ContentAlignment.MiddleCenter;
        }

        public int Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
                Text = value.ToString();
            }
        }
    }

    public class Button9EventArgs : EventArgs
    {
        public int value;

        public Button9EventArgs(int val)
        {
            value = val;
        }
    }
}
