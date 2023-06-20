using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolMatrixApp
{
    class Gauss
    {
        Matrix equation;

        public Gauss(Matrix mat) => equation = mat;
        public Gauss(double[,] mat) => equation = mat;

        public Matrix GaussProcess()
        {
            Matrix copy = equation;
            int line = copy.LineCount;
            int row = copy.RowCount-1;

            //прямой ход
            for (int t = 0; t < row; t++)
            {
                double max_value = 0;
                int max_position = 0;
                for (int i = t; i < line; i++)
                {
                    if (Math.Abs(copy[i, t]) > max_value)
                    {
                        max_value = Math.Abs(copy[t, i]);
                        max_position = i;
                    }
                }
                for (int i = 0; i < row + 1; i++)
                {
                    double tmp = copy[t, i];
                    copy[t, i] = copy[max_position, i];
                    copy[max_position, i] = tmp;
                }

                /*for(int i=0; i < m; i++)
                {
                    if (i != t)
                    {
                        double multiplier = equation[t, i] / equation[t, t];
                        for(int j=0; j < n + 1; j++)
                        {
                            equation[j, i] -= multiplier * equation[j, t];
                        }
                    }
                }*/

                for (int i = 0; i < line; i++)
                {
                    if (i != t)
                    {
                        double multiplier = copy[t, t];
                        double diver = copy[i, t];
                        for (int j = 0; j < row + 1; j++)
                        {
                            copy[i, j] = (copy[i, j] * multiplier - diver * copy[t, j]);
                        }
                    }
                }

            }

            // обратный ход
            Matrix result = new double[line,1];
            for(int i = 0; i < line; i++)
            {
                bool flag = true;
                for(int j = 0; j < row; j++)
                {
                    if (i == j)
                    {
                        if (copy[i, j] == 0)
                        {
                            flag = false;
                        }
                    }
                    else
                    {
                        if (copy[i, j] != 0)
                        {
                            flag = false;
                        }
                    }

                }
                if (flag)
                {
                    result[i, 0] = equation[i, row] / equation[i, i];
                }
                else
                {
                    Console.WriteLine("Имеет бесконечное множество решений");
                    return null;
                }
            }
            return result;
        }
    }
}
