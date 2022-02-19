using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Generare_matrice_sudoku
{
    public class SudokuGenerator {
        public byte[,] matrice { get;  private set; }

        public SudokuGenerator()
        {
            matrice = new byte[9, 9];
        }

        public byte[,] GenereazaMatrice()
        {
            int sol = 1;
            object ret = true; // orice valoare, doar ca sa nu dea eroare
            backtrackingGen(0,0, () =>
            {
                ret = matrice.Clone();
            }, ref sol, new Random());
            return ret as byte[,];
        }

        public void backtrackingGen(int i, int j, Action callback, ref int solutii_necesare, Random rand)
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

            int seed = rand.Next(1, 10);

            for (int k = seed, ok = 1; k != seed - ok && solutii_necesare > 0; k = Math.Max((k + 1) % 10, 1), ok = 0)
            //for (int k = 1; k <= 9; k++)
            {
                matrice[i, j] = Convert.ToByte(k);
                int newI = i + (j + 1) / 9, newJ = (j + 1) % 9;

                if (verifica())
                    backtrackingGen(newI, newJ, callback, ref solutii_necesare, rand);

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
                    if (frecvVec[matrice[i, j]] == true && matrice[i, j] != 0)
                        return false;
                    else
                        frecvVec[matrice[i, j]] = true;

            return true;
        }

        public bool checkH(int row)
        {
            bool[] frecvVec = getFrecvVec();
            for (int i = 0; i < 9; i++)
                if (frecvVec[matrice[row, i]] && matrice[row, i] != 0)
                    return false;
                else
                    frecvVec[matrice[row, i]] = true;

            return true;
        }

        public bool checkV(int col)
        {
            bool[] frecvVec = getFrecvVec();
            for (int i = 0; i < 9; i++)
                if (frecvVec[matrice[i, col]] && matrice[i, col] != 0)
                    return false;
                else
                    frecvVec[matrice[i, col]] = true;

            return true;
        }

        private bool[] getFrecvVec() => new bool[] {
            false, false, false, false, false,
            false, false, false, false, false
        };
    }
}
