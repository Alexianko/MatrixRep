using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolMatrixApp
{
    class Graph
    {
        public Matrix adjacency;

        public Graph(Matrix value) => adjacency = value;

        public void SearchWidth(int dot)
        {
            //int length = adjacency.LineCount;
            bool[] used = new bool[adjacency.LineCount];
            Queue<int> q = new Queue<int>();
            q.Enqueue(dot);
            int current;
            while (q.Count != 0)
            {
                current = q.Dequeue();
                Console.WriteLine($"Пройдена точка {current}");
                used[current] = true;
                for(int i=0; i< adjacency.LineCount; i++)
                {
                    if (adjacency[dot, i] != 0)
                    {
                        q.Enqueue(i);
                    }
                }
            }
            //осталось вернуть что-то адекватное
        }
        

        public void SearchDepth(int dot)
        {
            bool[] used = new bool[adjacency.LineCount];

            IterateDepth(dot, used);
            //осталось вернуть что-то адекватное
        }

        public void IterateDepth(int dot, bool[] used)
        {
            Console.WriteLine($"Пройдена точка {dot}");
            for (int i = 0; i < adjacency.LineCount; i++)
            {
                if (adjacency[dot, i] != 0)
                {
                    used[i] = true;
                    IterateDepth(i, used);
                }
            }
        }

        public double[] Dijkstra(int dot)
        {
            //int length = adjacency.LineCount;
            Queue<int> q = new Queue<int>();
            bool[] used = new bool[adjacency.LineCount];
            double[] costs = new double[adjacency.LineCount];

            for (int i=0; i< adjacency.LineCount; i++)
            {
                costs[i] = Double.PositiveInfinity;
            }

            costs[dot] = 0;
            q.Enqueue(dot);
            while (q.Count()>0)
            {
                 int current = q.Dequeue();
                Console.WriteLine($"Пройдена точка {current}");
                used[current] = true;
                for (int i = 0; i < adjacency.LineCount; i++)
                {
                    
                    if (!used[i] && !Double.IsPositiveInfinity(adjacency[current, i]) && costs[i] > costs[current] + adjacency[current, i])
                    {
                        costs[i] = costs[current] + adjacency[current, i];
                        q.Enqueue(i);
                    }
                }
            }
            //здесь вывод тоже оформим
            return costs;
        }

        public Matrix Floyd()
        {
            //int length = adjacency.LineCount;

            for (int i = 0; i < adjacency.LineCount; i++)
            {
                for (int j = 0; j < adjacency.LineCount; j++)
                {
                    if (adjacency[i, j] == 0 && i!=j)
                    {
                        adjacency[i, j] = Double.PositiveInfinity;
                    }
                }
            }
            
            for (int i=0; i < adjacency.LineCount; i++)
            {
                for (int j=0; j < adjacency.LineCount; j++)
                {
                    for (int k = 0; k < adjacency.LineCount; k++) 
                    {
                        if (adjacency[j, k] > (adjacency[j, i] + adjacency[i, k]))
                        {
                            adjacency[j, k] = adjacency[j, i] + adjacency[i, k];
                        }
                    }
                }
            }

            return adjacency;
        }


        public Matrix Prima()
        {
            //int length = adjacency.LineCount;
            bool[] used = new bool[adjacency.LineCount];
            Matrix result = new double[adjacency.LineCount, adjacency.LineCount];
            used[0] = true;
            int temp_dot = 1;
            while (temp_dot > 0)
            {
                double temp = Double.PositiveInfinity;
                int temp_start = -1;
                temp_dot = -1;
                for (int i = 0; i < adjacency.LineCount; i++)
                {
                    if (used[i])
                    {
                        for (int j = 0; j < adjacency.LineCount; j++)
                        {
                            if (!used[j] && adjacency[i, j] != 0 && temp > adjacency[i, j])
                            {
                                temp = adjacency[i, j];
                                temp_start = i;
                                temp_dot = j;
                            }
                        }
                    }

                }
                if (temp_dot != -1) {
                    used[temp_dot] = true;
                    result[temp_start, temp_dot] = adjacency[temp_start, temp_dot];
                    result[temp_dot, temp_start] = adjacency[temp_start, temp_dot];
                }
            }
            //осталось вернуть что-то адекватное
            return result;
        }
    }
}
