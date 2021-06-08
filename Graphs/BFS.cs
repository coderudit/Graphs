using System;
using System.Collections.Generic;

namespace Graphs
{
    class BFS
    {
        int[,] adjacencyMatrix = new int[,] { { 0,0,0,0,0,0,0,0}, { 0, 0, 1, 1, 1, 0, 0, 0 }, { 0, 1, 0, 1, 0, 0, 0, 0 },
            { 0, 1, 1, 0, 1, 1, 0, 0}, {0, 1,0,1,0,1,0,0 }, {0, 0,0,1,1,0,1,1 }, { 0, 0,0,0,0,1,0,0}, { 0, 0,0,0,0,1,0,0} };

        public void Search(int i)
        {
            Console.Write($"{i} ");

            var queue = new Queue<int>();
            queue.Enqueue(1);

            int[] visitedArray = new int[8];
            visitedArray[i] = 1;

            while (queue.Count > 0)
            {
                int element = queue.Dequeue();
                for (int visited = 1; visited < visitedArray.Length; visited++)
                {
                    if (visitedArray[visited] == 0 && adjacencyMatrix[element, visited] == 1)
                    {
                        Console.Write($"{visited} ");
                        queue.Enqueue(visited);
                        visitedArray[visited] = 1;
                    }
                }
            }
        }
    }
}
