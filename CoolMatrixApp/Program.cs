using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolMatrixApp
{
    class Program
    {
        static void Main(string[] args)
        {

            /*Matrix matrix = new Matrix(new double[,]{ {5, 4, -2, 5},
                              {2, 3, 5, 1},
                              {4, 1, 3, 2},
                              {-2, 2, 3, -1} });
            
            matrix.PrintMatrix();
            Console.WriteLine($"Показатель : {matrix.GetMatrixPok(matrix)}");*/

            /*Matrix m = new double[,]{ {1, 2, 3, 6},
                              {4, 5, 6, 9},
                              {7, 8, 0, -6}};*/
            /*GaussDemo gd = new GaussDemo(new double[,]{ 
                              {1, 4, 7},
                              {2, 5, 8},
                              {3, 6, 0},
                              {6, 9, -6}});*/
            /*GaussDemo gd = new GaussDemo(new double[,]{
                              {4, 2, 1},
                              {2, 4, 2},
                              {1, 2, 4},
                              {12, 18, 21}});*/
            //gd.GaussProcess();


            /*Matrix m = new double[,]{
                { 5, 4, -2, 5},
                { 2, 3, 5, 1},
                { 4, 1, 3, 2},
                { -2, 2, 3, -1}
            };*/

            /*Matrix m = new double[,]{ {1, 2, 3, 6},
                                    {4, 5, 6, 9},
                                    {7, 8, 0, -6}};*/

            /*Matrix m = new double[,]{ {1, 7, 3},
                                      {2, 5, -1},
                                      {4, 8, -2}};*/

            /*Console.WriteLine(m);
            LU lu = new LU(m);
            //lu.FindIssue();
            Console.WriteLine();
            Console.WriteLine(lu.GetL());
            Console.WriteLine();
            Console.WriteLine(lu.GetU());
            Console.WriteLine();
            Console.WriteLine(m.GetDeterminator());
            Console.WriteLine(lu.GetL().GetDeterminator());
            Console.WriteLine(lu.GetU().GetDeterminator());*/
            //Console.WriteLine();
            //Kramer mm = new Kramer(m);
            //mm.FindIssue();
            //Console.WriteLine(mm.FindIssue());

            /*  Дейкстра
             * Matrix m = new double[,]{
                { 0,  7,  9,  0, 0, 14},
                { 7,  0,  10, 15, 0, 0},
                { 9,  10, 0,  11, 0, 2},
                { 0,  15, 11, 0, 6, 0},
                { 0,  0,  0,  6, 0, 9},
                { 14, 0,  2,  0, 9, 0}
            };

            Graph gr = new Graph(m);
            Console.WriteLine(gr.adjacency);
            double[] dixtra = gr.Dijkstra(0);
            for(int i=0; i<dixtra.GetLength(0); i++)
            {
                Console.WriteLine($"{dixtra[i]}\t");
            }*/

            /* Флойд
             * Matrix m = new double[,]{
                { 0, 1, 6, 0},
                { 0, 0, 4, 1},
                { 0, 0, 0, 0},
                { 0, 0, 1, 0}
            };

            Console.WriteLine(m);
            Console.WriteLine();
            Graph gr = new Graph(m);
            Console.WriteLine(gr.Floyd());*/

            Matrix m = new double[,]{
                { 0, 3, 4, 0, 1},
                { 3, 0, 5, 0, 0},
                { 4, 5, 0, 2, 6},
                { 1, 0, 2, 0, 7},
                { 0, 0, 6, 7, 0}
            };

            Console.WriteLine(m);
            Console.WriteLine();
            Graph gr = new Graph(m);
            Console.WriteLine(gr.Prima());

            Console.ReadLine();
        }
        
    }
}
