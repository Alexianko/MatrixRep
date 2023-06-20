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
            int length = adjacency.LineCount;
            bool[] used = new bool[length];
            Queue<int> q = new Queue<int>();
            q.Enqueue(dot);
            int current;
            while (q.Count != 0)
            {
                current = q.Dequeue();
                Console.WriteLine($"Пройдена точка {current}");
                used[current] = true;
                for(int i=0; i<length; i++)
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
            int length = adjacency.LineCount;
            bool[] used = new bool[length];

            IterateDepth(dot, used);
            //осталось вернуть что-то адекватное
        }

        public void IterateDepth(int dot, bool[] used)
        {
            Console.WriteLine($"Пройдена точка {dot}");
            int length = adjacency.LineCount;
            for (int i = 0; i < length; i++)
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
            int length = adjacency.LineCount;
            Queue<int> q = new Queue<int>();
            bool[] used = new bool[length];
            double[] costs = new double[length];

            for (int i=0; i<length;i++)
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
                for (int i = 0; i < length; i++)
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
            int length = adjacency.LineCount;

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (adjacency[i, j] == 0 && i!=j)
                    {
                        adjacency[i, j] = Double.PositiveInfinity;
                    }
                }
            }
            
            for (int i=0; i < length; i++)
            {
                for (int j=0; j < length; j++)
                {
                    for (int k = 0; k < length; k++) 
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
            int length = adjacency.LineCount;
            bool[] used = new bool[length];
            Matrix result = new double[length, length];
            used[0] = true;
            int temp_dot = 1;
            while (temp_dot > 0)
            {
                double temp = Double.PositiveInfinity;
                int temp_start = -1;
                temp_dot = -1;
                for (int i = 0; i < length; i++)
                {
                    if (used[i])
                    {
                        for (int j = 0; j < length; j++)
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
