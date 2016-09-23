using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiral_Matrix
{
    class Program
    {
        public List<int> result = new List<int>();

        static void Main(string[] args)
        {
            int[,] m = new int[,]
            {
              //{1,2,3},{1,2,3},{1,2,3},{1,2,3},{1,2,3},{1,2,3}
              // { 1,2,3,4,5,6}, { 1,2,3,4,5,6}, { 1,2,3,4,5,6}
              { 1,2,3,4},{ 1,2,3,4},{ 1,2,3,4},{ 1,2,3,4},{ 1,2,3,4},{ 1,2,3,4},{ 1,2,3,4}
            };
            Program p = new Program();

            IList<int> res = p.SpiralOrder(m); 
            foreach(int i in res)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }

        public IList<int> SpiralOrder(int[,] matrix)
        {
            if (matrix == null)
            {
                return null;
            }

            int row, col;

            row = matrix.GetLength(0);
            col = matrix.GetLength(1);

            int tr = 0, tc = col - 1;

            int max = (row > col) ? col : row;

            if (row == 1)
            {
                SingleRoworCol(true, matrix);
            }
            else if (col == 1)
            {
                SingleRoworCol(false, matrix);
            }
            else
            {
                for (int i = 0; i <= (max - 1) / 2; i++)
                {
                    //if ((tc >= (col - 1) / 2) || (tr <= (row - 1) / 2))
                    if(result.Count < matrix.Length)
                    {
                        Clockwise(tr, tc, i, matrix, tr, tc);
                        tr++;
                        tc--;
                        //if ((tc >= (col - 1) / 2) || (tr <= (row - 1) / 2))
                        if (result.Count < matrix.Length)
                        {
                            AntiClockwise(tr, tc, i, matrix, tr, tc);
                        }
                    }
                }
            }
            return result;
        }

        private void SingleRoworCol(bool isSingleRow, int[,] matrix)
        {
            if (isSingleRow)
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    result.Add(matrix[0, i]);
                }
            }
            else
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    result.Add(matrix[i, 0]);
                }
            }
        }

        private void Clockwise(int row, int col, int str, int[,] matrix, int tr, int tc)
        {
            int l_row = matrix.GetLength(0) - 1 - str;
            // if ((tr <= (row - 1) / 2))
            if (result.Count < matrix.Length)
            {
                for (int i = str; i <= col; i++)
                {
                    result.Add(matrix[row, i]);
                }
                // if ((tc >= (col - 1) / 2))
                if (result.Count < matrix.Length)
                {
                    for (int i = str + 1; i <= l_row; i++)
                    {
                        result.Add(matrix[i, col]);
                    }
                }
            }
        }

        private void AntiClockwise(int row, int col, int str, int[,] matrix, int tr, int tc)
        {
            //int l_col = matrix.GetLength(1) - 1 - str;
            int l_row = matrix.GetLength(0) - 1 - str;
            // if ((tc >= (col - 1) / 2))
            if (result.Count < matrix.Length)
            {
                for (int i = col; i >= str; i--)
                {
                    result.Add(matrix[l_row, i]);
                }
                // if ((tr <= (row - 1) / 2))
                if (result.Count < matrix.Length)
                {
                    for (int i = l_row - 1; i >= row; i--)
                    {
                        result.Add(matrix[i, str]);
                    }
                }
            }
        }
    }
}
