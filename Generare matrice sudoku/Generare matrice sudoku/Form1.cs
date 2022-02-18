using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Generare_matrice_sudoku
{
    public partial class Form1 : Form
    {
        public byte[,] matrice;

        public Form1()
        {
            InitializeComponent();
            matrice = new byte[9, 9];
            /*
            byte[,]{
                {3, 4, 5, 6, 7, 8, 9, 1, 2}, 
                {6, 7, 8, 9, 1, 2, 5, 3, 4}, 
                {9, 1, 2, 3, 4, 5, 6, 7, 8}, 
                {1, 2, 3, 4, 5, 6, 7, 8, 9}, 
                {4, 5, 6, 7, 8, 9, 1, 2, 3}, 
                {7, 8, 9, 1, 2, 3, 4, 5, 6}, 
                {8, 9, 7, 2, 6, 1, 3, 4, 5}, 
                {5, 6, 1, 8, 3, 7, 2, 9, 4}, 
                {2, 3, 4, 5, 9, 4, 8, 6, 0}
            };//*/
            //Console.WriteLine(verifica());

            StreamWriter outStream = new StreamWriter("outputMatrices.txt");

            FormClosing += (o, e) => outStream.Close();

            int solutii_necesare = 10;

            backtrackingGen(0, 0, () =>
            {
                writeMatrix(outStream);
                afisMat();
                Console.WriteLine("matrice gasita!");
                Thread.Sleep(100);
            }, ref solutii_necesare);

            outStream.Close();
        }

        public void backtrackingGen(int i, int j, Action callback, ref int solutii_necesare, int seed = 1657311953)
        {
            if (i == 9)
            {
                if (solutii_necesare > 0)
                {
                    solutii_necesare--;
                    callback();
                }
                return;
            }

            for (int k = seed % 10, ok = 1; k != seed % 10 - ok && solutii_necesare > 0; k = Math.Max((k + 1) % 10, 1), ok = 0)
            //for (int k = 1; k <= 9; k++)
            {
                matrice[i, j] = Convert.ToByte(k);
                int newI = i + (j + 1) / 9, newJ = (j + 1) % 9;

                if (verifica())
                    backtrackingGen(newI, newJ, callback, ref solutii_necesare, newJ == 8 ? seed / 10 : seed);

                matrice[i, j] = 0;
            }
        }

        public void afisMat()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                    Console.Write("{0} ", matrice[i, j]);
                Console.WriteLine();
            }
                Console.WriteLine();
        }

        public void writeMatrix(StreamWriter sr)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                    sr.Write("{0} ", matrice[i, j]);
                sr.WriteLine();
            }
            sr.WriteLine();
        }

        public bool verifica()
        {
            for (int i = 0; i < 9; i++)
                if (!checkZ(i) || !checkV(i) || !checkH(i))
                    return false;

            return true;
        }

        public bool checkZ(int zona)
        {
            bool[] frecvVec = getFrecvVec();
            int _i = zona / 3 * 3;
            int _j = zona % 3 * 3;

            for (int i = _i; i <= _i + 2; i++)
                for (int j = _j; j <= _j + 2; j++)
                    if (frecvVec[matrice[i, j]] == true && matrice[i,j]!=0)
                        return false;
                    else
                        frecvVec[matrice[i, j]] = true;

            //Console.WriteLine("Verifica!");
            return true;
        }

        public bool checkH(int row)
        {
            bool[] frecvVec = getFrecvVec();
            for (int i = 0; i < 9; i++)
            {
                //Console.WriteLine(matrice[row, i]);
                if (frecvVec[matrice[row, i]] && matrice[row, i] != 0)
                    return false;
                else
                    frecvVec[matrice[row, i]] = true;
            }

            //Console.WriteLine("Verifica! orizontal");
            return true;
        }

        public bool checkV(int col)
        {
            bool[] frecvVec = getFrecvVec();
            for (int i = 0; i < 9; i++)
            {
                //Console.WriteLine(matrice[i, col]);
                if (frecvVec[matrice[i, col]] && matrice[i, col] != 0)
                    return false;
                else
                    frecvVec[matrice[i, col]] = true;
            }

            //Console.WriteLine("Verifica! vertical");
            return true;
        }

        public bool[] getFrecvVec() => new bool[] {
            false, false, false, false, false,
            false, false, false, false, false
        };
    }
}
