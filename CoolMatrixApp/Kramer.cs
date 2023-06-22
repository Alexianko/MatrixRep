using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolMatrixApp
{
    class Kramer
    {
        Matrix data;
        Matrix issues;


        public Kramer(double[,] dataMat, double[,] issMat)
        {
            data = dataMat;
            issues = issMat;
        }

        public Kramer(Matrix mat)
        {
            int line = mat.LineCount;
            int row = mat.RowCount;
            data = new double[line,row-1];
            issues = new double[line,1];
            for(int i = 0; i < line; i++)
            {
                for(int j = 0; j < row; j++)
                {
                    if (j != row-1)
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
            Matrix result = new double[data.LineCount, 1];
            if (data.GetDeterminator() != 0)
            {
                int lineCount = result.LineCount;
                for(int i = 0; i < result.LineCount; i++)
                {
                    result[i,0] = GetSubMatrix(i).GetDeterminator() / data.GetDeterminator();
                }
                return result;
            }
            else
            {
                throw new Exception("Невозможно решить");
            }
        }

        public Matrix GetSubMatrix(int value)
        {
            int line = data.LineCount;
            int row = data.RowCount;
            Matrix newMat = new double[line, row];
            for(int i = 0; i < line; i++)
            {
                for(int j = 0; j < row; j++)
                {
                    if(j!= value)
                    {
                        newMat[i, j] = data[i,j];
                    }
                    else
                    {
                        newMat[i, j] = issues[i, 0];
                    }
                }
            }
            return newMat;
        }
        
    }
}
