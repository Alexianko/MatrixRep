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

        public Matrix(double[,] mat) => matrix = mat;
        public Matrix(int n, int m) => matrix = new double[n,m];

        public double this [int i, int j]
        {
            get => matrix[i, j];
            set => matrix[i, j] = value;
        }

        public static implicit operator Matrix(double[,] mat)
        {
            return new Matrix(mat);
        }

        public int LineCount => matrix.GetLength(0);
        public int RowCount => matrix.GetLength(1);

        public int GetLength(int i)
        {
            return matrix.GetLength(i);
        }

        //модифицированный
        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetLength(1) == matrix2.GetLength(0))
            {
                double[,] result = new double[matrix1.GetLength(0), matrix2.GetLength(1)];
                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix2.GetLength(1); j++)
                    {
                        result[i, j] = 0;
                        for (int n = 0; n < matrix1.GetLength(1); n++)
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
            int line = matrix.GetLength(0);
            int row = matrix.GetLength(1);
            double[,] result = new double[line, row];
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < row; j++)
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
            int line = matrix.GetLength(0);
            int row = matrix.GetLength(1);
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    str += $"{matrix[i, j]}\t";
                }
                str += "\n";
            }
            return str;
        }

        /*public static implicit operator string(Matrix mat)
        {
            string str="";
            int line = mat.GetLength(0);
            int row = mat.GetLength(1);
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    str+=$"{mat[i, j]}\t";
                }
                str += "\n";
            }
            return str;
        }*/
    }


    /*{
        double[,] matrix;

        public Matrix(double[,] matrix)
        {
            this.matrix = matrix;
        }

        public Matrix(int lines, int rows)
        {
            matrix = new double[lines,rows];
        }

        public int GetMatrixLineCount()
        {
            return matrix.GetLength(0);
        }
        

        public int GetMatrixRowCount()
        {
            return matrix.GetLength(1);
        }

        public double GetMatrixElement(int line, int row)
        {
            return matrix[line, row];
        }

        public double SetMatrixElement(double value, int line, int row)
        {
            return matrix[line, row] = value;
        }

        /*public double[,] MultiplyBy(double[,] mat)
        {
            int length = mat.GetLength(0);
            double[,] _mat = new double[length, length];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    _mat[i, j] = 0;
                    for (int n = 0; n < length; n++)
                    {
                        _mat[i, j] += matrix[i, n] * mat[n, j];
                    }
                }
            }
            return _mat;
        }*/

        /*public double[,] MultiplyBy(Matrix value)
        {
            int length = this.GetMatrixRowCount();
            double[,] _mat = new double[length, length];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    _mat[i, j] = 0;
                    for (int n = 0; n < length; n++)
                    {
                        _mat[i, j] += matrix[i, n] * value.GetMatrixElement(n, j);
                    }
                }
            }
            return _mat;
        }

        public double[,] MultiplyBy(double value)
        {
            int line = matrix.GetLength(0);
            int row = matrix.GetLength(1);
            double[,] _mat = new double[line, row];
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    matrix[i, j] += matrix[i, j] * value;
                }
            }
            return _mat;
        }
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public double[,] GetReverseMatrix(Matrix mat)
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
        }

        public double GetMatrixPok(double[,] mat)
        {
            double sum = 0;
            int length = mat.GetLength(0);
            if (length != mat.GetLength(1))
            {
                throw new Exception("Невозможно вычислить определитель для не квадратной матрицы");
            }
            if (length == 1)
            {
                return mat[0, 0];
            }
            if (length == 2)
            {
                return mat[0, 0] * mat[1, 1] - mat[0, 1] * mat[1, 0];
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    sum += mat[i, 0] * GetMatrixMinor(mat, i, 0);
                }
            }
            return sum;
        }

        public double GetMatrixPok(Matrix mat)
        {
            double sum = 0;
            int line = mat.GetMatrixLineCount();
            int row = mat.GetMatrixRowCount();
            if (line != row)
            {
                throw new Exception("Невозможно вычислить определитель для не квадратной матрицы");
            }
            if (line == 1)
            {
                return mat.GetMatrixElement(0, 0);
            }
            if (line == 2)
            {
                return mat.GetMatrixElement(0, 0) * mat.GetMatrixElement(1, 1) - mat.GetMatrixElement(0, 1) * mat.GetMatrixElement(1, 0);
            }
            else
            {
                for (int i = 0; i < line; i++)
                {
                    sum += mat.GetMatrixElement(i, 0) * GetMatrixMinor(this, i, 0);
                }
            }
            return sum;
        }

        public double GetMatrixPok()
        {
            double sum = 0;
            int line = this.GetMatrixLineCount();
            int row = this.GetMatrixRowCount();
            if (line != row)
            {
                throw new Exception("Невозможно вычислить определитель для не квадратной матрицы");
            }
            if (line == 1)
            {
                return matrix[0, 0];
            }
            if (line == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else
            {
                for (int i = 0; i < line; i++)
                {
                    sum += matrix[i, 0] * GetMatrixMinor(this, i, 0);
                }
            }
            return sum;
        }

        public double GetMatrixMinor(double[,] mat, int i, int j)
        {
            return (1 - ((i + j) % 2) * 2) * GetMatrixPok(LowerRangeAdd(mat, i, j));
        }

        public double GetMatrixMinor(Matrix mat, int i, int j)
        {
            return (1 - ((i + j) % 2) * 2) * mat.LowerRangeAdd(i, j).GetMatrixPok();
        }

        public double GetMatrixMinor(int i, int j)
        {
            return (1 - ((i + j) % 2) * 2) * this.GetMatrixPok(this.LowerRangeAdd(i, j));
        }

        //Дополнение матрицы
        public double[,] LowerRangeAdd(double[,] mat, int x, int y)
        {
            int length = mat.GetLength(0) - 1;
            double[,] newMat = new double[length, length];
            int _i = 0;
            for (int i = 0; i < length; i++)
            {
                int _j = 0;
                if (i == x)
                {
                    _i++;
                }
                for (int j = 0; j < length; j++)
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

        public Matrix LowerRangeAdd(int x, int y)
        {
            int line = this.GetMatrixLineCount()-1;
            int row = this.GetMatrixRowCount()-1;
            Matrix newMat = new Matrix(line, row);
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
                    newMat.SetMatrixElement(matrix[i + _i, j + _j], i, j);
                }
            }
            return newMat;
        }

        //Вывод матрицы на экран
        public void PrintMatrix()
        {
            int length = matrix.GetLength(0);
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Console.Write($"{matrix[i, j]}\t");
                }
                Console.WriteLine();
            }
        }
    }*/
}
