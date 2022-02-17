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
        private ButtonSudoku selectedButton = null;
        private DropdownMenu9b dropdown;

        public SudokuEngine(Panel container, string solvedMatrix)
        {
            dropdown = new DropdownMenu9b(new string[]{ // butoane de la 1 la 9
                "1", "2", "3", "4", "5", "6", "7", "8", "9"
            });
            dropdown.Parent = container;

            mat = new matrice9x9(solvedMatrix);
            mat.Shuffle();

            randomObject = new Random(); randomObject.Next(); // refresh
            missingNumbers = randomObject.Next(15,40);

            matB = new matriceSudoku9x9(container, mat.AlterNewMatrix(missingNumbers), dropdown, 5);
        }
    }

    public class matrice9x9
    {
        private byte[,] mat;

        public matrice9x9(string solvedMatrix) {
            mat = new byte[9,9];
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

        private matrice9x9()
        {
            mat = new byte[9,9];
        }

        public matrice9x9 AlterNewMatrix(int changesLeft) // restricted to 40 missings!
        {
            changesLeft = clamp(changesLeft, 15, 40);
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
        private Button[,] mat;
        private Panel container;
        private DropdownMenu9b dropdown;
        private ButtonSudoku selectedButton = null;

        private Color colorBdefault = Color.Wheat;
        private Color colorBPending = Color.DarkSeaGreen;
        private Color colorBCompletion = Color.LightPink;
        private Color colorBRight = Color.Green;
        private Color colorBWrong = Color.Red;

        public matriceSudoku9x9(Panel c, matrice9x9 m, DropdownMenu9b drpmnu, int padding = 2)
        {
            container = c;
            dropdown = drpmnu;
            mat = new ButtonSudoku[9,9];

            int sz = Math.Min(container.Width, container.Height); // totalSize
            int szB = (sz-8*padding)/9; // buttonSize

            byte[,] auxiliaryMatrix = m.getMatrix();

            for(int i = 0; i < 9; i++)
                for(int j = 0; j < 9; j++)
                {
                    ButtonSudoku b = new ButtonSudoku()
                    {
                        Width = szB,
                        Height = szB,
                        Location = new Point(i*(padding+szB), j*(padding+szB)),
                        expectedNumber = auxiliaryMatrix[i,j],
                        Text = (auxiliaryMatrix[i, j] != 0 ? m.getMatrix()[i, j].ToString() : ""),
                        BackColor = (auxiliaryMatrix[i, j] != 0 ? colorBdefault : colorBPending),
                        isPlayable = auxiliaryMatrix[i,j] == 0
                    };
                    b.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

                    if(b.isPlayable)
                        b.Click += (o, e) =>
                        {
                            if (selectedButton == b) dropdown.Visible = !dropdown.Visible;
                            else
                            {
                                selectedButton = b;
                                dropdown.Visible = true;
                                dropdown.Location = new Point(b.Location.X+b.Width+1, b.Location.Y+1);
                            }
                        };

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
            };

            Graphics graphics = container.CreateGraphics();
            Brush br = new SolidBrush(Color.MediumPurple);

            container.Paint += (o, e) =>
            {
                graphics.FillRectangle(br, 0, 2 * padding + 3 * szB, 8 * padding + 9 * szB, padding); // horizontal upper
                graphics.FillRectangle(br, 0, 5 * padding + 6 * szB, 8 * padding + 9 * szB, padding); // horizontal lower

                graphics.FillRectangle(br, 2 * padding + 3 * szB, 0, padding, 8 * padding + 9 * szB); // vertical left
                graphics.FillRectangle(br, 5 * padding + 6 * szB, 0, padding, 8 * padding + 9 * szB); // vertical right
            };
        }
    }

    public class ButtonSudoku : Button
    {
        public byte expectedNumber = 0;
        public bool isPlayable;
    }

    public class DropdownMenu9b : Panel
    {
        private int bSize = 30;
        private List<Button> buttonList;
        private int padding = 2;

        public event EventHandler ButtonPicked;

        public DropdownMenu9b(object[] items, int x = 0, int y = 0)
        {
            Location = new Point(x, y);
            Size = new Size(bSize*3+2*padding, bSize*3+2*padding);
            buttonList = new List<Button>();
            Visible = false; ///////////////////////////////////////////////// if it doesnt work, change this!!!

            for(int i = 0; i < 3; i++)
                for(int j = 0; j < 3; j++)
                {
                    Button b = new Button()
                    {
                        Location = new Point(i*(bSize+padding), j*(bSize+padding)),
                        Size = new Size(bSize, bSize),
                        Font = new Font("Times New Roman", 15),
                        FlatStyle = FlatStyle.Flat,
                        BackColor = Color.Aquamarine,
                        Text = (j*3+i+1).ToString()
                    };

                    b.Click += (o, e) => ButtonPicked?.Invoke(this, new Button9EventArgs(Convert.ToInt32(b.Text)));

                    buttonList.Add(b);
                    b.Parent = this;
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
