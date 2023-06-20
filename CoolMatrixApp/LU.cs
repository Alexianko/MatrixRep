using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolMatrixApp
{
    class LU
    {
        Matrix A;
        Matrix L;
        Matrix U;
        
        public Matrix GetL() => L;
        public Matrix GetU() => U;

        public LU(Matrix value)
        {
            A = value;
            int length = A.LineCount;
            L = new double[length, length];
            U = new double[length, length];
            for (int i = 0; i < length; i++)
            {
                for(int j = 0; j < length; j++)
                {
                    U[i, j] = 0;
                    if (i == j)
                    {
                        L[i, j] = 1;
                    }
                    else
                    {
                        L[i, j] = 0;
                    }
                }
            }

            FindIssue();
        }

        private void FindIssue()
        {
            int length = A.LineCount;
            for (int i = 0; i < length; i++)
            {
                for(int j = 0; j < length; j++)
                {
                    double temp = 0;
                    if (i > j)
                    {
                        for(int k = 0; k <= j; k++)
                        {
                            temp += (L[i,k]*U[k,j]);
                        }
                        L[i, j] = (A[i, j] - temp) / U[j, j];
                    }
                    else
                    {
                        for (int k = 0; k <= i; k++)
                        {
                            temp += (L[i, k] * U[k, j]);
                        }
                        U[i, j] = A[i, j] - temp;
                    }
                }
            }
        }
    }
}
