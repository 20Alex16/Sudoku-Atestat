using System;
using System.IO;
using System.Windows.Forms;

namespace Generare_matrice_sudoku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //matrice = new byte[9, 9];
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


            SudokuGenerator gen = new SudokuGenerator();

            byte[,] mat = gen.GenereazaMatrice();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                    Console.Write("{0} ", mat[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine($"Am gasit si salvat solutiile cerute!");

            outStream.Close();
        }
    }
}
