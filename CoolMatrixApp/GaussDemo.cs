using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolMatrixApp
{
    class GaussDemo
    {
        double[,] equation;
        double[] unknown;

        public GaussDemo(double[,] eq)
        {
            equation = eq;
            unknown = new double[equation.GetLength(0)-1];
        }

        public void PrintGauss()
        {
            int n = equation.GetLength(0) - 1;
            int m = equation.GetLength(1);
            for (int i=0; i < m; i++)
            {
                Console.Write("[");
                for (int j =0; j < n; j++)
                {
                    Console.Write($"{equation[j,i]} \t");
                }
                Console.Write("| \t");
                Console.Write($"{equation[n, i]}");
                Console.WriteLine("]");
            }
        }

        public double[] GaussProcess()
        {

            PrintGauss();
            Console.WriteLine();
            int n = equation.GetLength(0) - 1;
            int m = equation.GetLength(1);
            for (int t=0; t<n; t++)
            {
                double max_value=0;
                int max_position = 0;
                for(int i = t; i < m; i++)
                {
                    if (Math.Abs(equation[t, i]) > max_value)
                    {
                        max_value = Math.Abs(equation[t, i]);
                        max_position = i;
                    }
                }
                for(int i=0; i<n+1; i++)
                {
                        double tmp = equation[i, t];
                        equation[i, t] = equation[i , max_position];
                        equation[i , max_position] = tmp;
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

                for (int i = 0; i < m; i++)
                {
                    if (i != t)
                    {
                        double multiplier = equation[t, t];
                        double diver = equation[t, i];
                        for (int j = 0; j < n + 1; j++)
                        {
                            equation[j, i] = (equation[j, i] * multiplier - diver * equation[j, t]);
                        }
                    }
                }

                PrintGauss();
                Console.WriteLine();

            }

            PrintGauss();
            return null;
        }
    }
}
