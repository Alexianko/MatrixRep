using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolMatrixApp
{
    class Matrix
    {
        double[,] matrix;
        private int lines;
        private int rows;
        public int LineCount => lines;
        public int RowCount => rows;

        public Matrix(double[,] mat)
        {
            matrix = mat;
            lines = matrix.GetLength(0);
            rows = matrix.GetLength(1);
        }
        public Matrix(int n, int m)
        {
            matrix = new double[n, m];
            lines = n;
            rows = m;
        }

        public double this[int i, int j]
        {
            get => matrix[i, j];
            set => matrix[i, j] = value;
        }

        public static implicit operator Matrix(double[,] mat)
        {
            return new Matrix(mat);
        }


        /*public int GetLength(int i)
        {
            return matrix.GetLength(i);
        }*/

        //модифицированный
        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.RowCount == matrix2.LineCount)
            {
                double[,] result = new double[matrix1.LineCount, matrix2.RowCount];
                for (int i = 0; i < matrix1.LineCount; i++)
                {
                    for (int j = 0; j < matrix2.RowCount; j++)
                    {
                        result[i, j] = 0;
                        for (int n = 0; n < matrix1.RowCount; n++)
                        {
                            result[i, j] += matrix1[i, n] * matrix2[n, j];
                        }
                    }
                }
                return result;
            }
            else
            {
                throw new Exception("Невозможно умножить");
            }
        }

        public static Matrix operator *(Matrix matrix, double value)
        {
            double[,] result = new double[matrix.LineCount, matrix.RowCount];
            for (int i = 0; i < matrix.LineCount; i++)
            {
                for (int j = 0; j < matrix.RowCount; j++)
                {
                    result[i, j] = matrix[i, j] * value;
                }
            }
            return result;
        }

        public static Matrix operator *(double value, Matrix matrix)
        {
            return matrix * value;
        }


        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    str += $"{matrix[i, j]}\t";
                }
                str += "\n";
            }
            return str;
        }
    }
}
