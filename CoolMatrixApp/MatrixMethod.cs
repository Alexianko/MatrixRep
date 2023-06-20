using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolMatrixApp
{
    class MatrixMethod
    {
        Matrix data;
        Matrix issues;

        public MatrixMethod(Matrix mat)
        {
            int line = mat.LineCount;
            int row = mat.RowCount;
            data = new double[line, row - 1];
            issues = new double[line, 1];
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (j != row - 1)
                    {
                        data[i, j] = mat[i, j];
                    }
                    else
                    {
                        issues[i, 0] = mat[i, j];
                    }
                }
            }
        }

        public Matrix FindIssue()
        {
            if (data.GetDeterminator() != 0)
            {
                Matrix inv = data.Inverse();
                Matrix result = inv * issues;

                result *= (1 / data.GetDeterminator());
                return result;
            }
            else
            {
                Console.WriteLine("Невозможно решить");
                return null;
            }
        }

    }
}
