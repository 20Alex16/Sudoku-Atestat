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

        public SudokuEngine(Panel container, string solvedMatrix)
        {
            mat = new matrice9x9(solvedMatrix);
            mat.Shuffle();
            randomObject = new Random(); randomObject.Next(); // refresh
            missingNumbers = randomObject.Next(15,40);
            //mat.print();
            matB = new matriceSudoku9x9(container, mat.AlterNewMatrix(missingNumbers), 5);
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

        public matriceSudoku9x9(Panel c, matrice9x9 m, int padding = 2)
        {
            container = c;
            mat = new ButtonSudoku[9,9];

            int sz = Math.Min(container.Width, container.Height); // totalSize
            int szB = (sz-8*padding)/9; // buttonSize

            for(int i = 0; i < 9; i++)
                for(int j = 0; j < 9; j++)
                {
                    ButtonSudoku b = new ButtonSudoku()
                    {
                        Width = szB,
                        Height = szB,
                        Location = new Point(i*(padding+szB), j*(padding+szB)),
                        expectedNumber = m.getMatrix()[i,j],
                        Text = (m.getMatrix()[i, j] != 0 ? m.getMatrix()[i, j].ToString() : "")
                    };
                    b.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    mat[i, j] = b;
                    b.Parent = container;
                }

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
    }
}
