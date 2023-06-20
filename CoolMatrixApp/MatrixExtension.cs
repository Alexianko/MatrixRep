using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolMatrixApp
{
    static class MatrixExtension
    {
        static public double GetDeterminator(this Matrix mat)
        {
            double sum = 0;
            int line = mat.LineCount;
            int row = mat.RowCount;
            if (line != row)
            {
                throw new Exception("Невозможно вычислить определитель для не квадратной матрицы");
            }
            if (line == 1)
            {
                return mat[0, 0];
            }
            if (line == 2)
            {
                return mat[0, 0] * mat[1, 1] - mat[0, 1] * mat[1, 0];
            }
            else
            {
                for (int i = 0; i < line; i++)
                {
                    sum += mat[i, 0] * GetMatrixMinor(mat, i, 0);
                }
            }
            return sum;
        }



        static public Matrix LowerRangeAdd(this Matrix mat, int x, int y)
        {

            int line = mat.LineCount-1;
            int row = mat.RowCount-1;
            double[,] newMat = new double[line, row];
            int _i = 0;
            for (int i = 0; i < line; i++)
            {
                int _j = 0;
                if (i == x)
                {
                    _i++;
                }
                for (int j = 0; j < row; j++)
                {
                    if (j == y)
                    {
                        _j++;
                    }
                    newMat[i, j] = mat[i + _i, j + _j];
                }
            }
            return newMat;
        }

        static public double GetMatrixMinor(this Matrix mat, int i, int j)
        {
            return (1 - ((i + j) % 2) * 2) * mat.LowerRangeAdd(i, j).GetDeterminator();
        }

        static public Matrix Inverse(this Matrix mat)
        {
            int length = mat.GetLength(0);
            double[,] _mat = new double[length, length];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    _mat[i, j] = GetMatrixMinor(mat, j, i);
                }
            }
            return _mat;
        }

         


        /*public double[,] GetReverseMatrix(Matrix mat)
        {
            int length = mat.GetMatrixRowCount();
            double[,] _mat = new double[length, length];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    _mat[i, j] = GetMatrixMinor(mat, j, i);
                }
            }
            return _mat;
        }*/
    }
}
