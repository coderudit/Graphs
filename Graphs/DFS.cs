using System;
using System.Collections.Generic;

namespace Graphs
{
    class DFS
    {
        int[] visitedArray = new int[8];
        int[,] adjacencyMatrix = new int[,] { { 0,0,0,0,0,0,0,0}, { 0, 0, 1, 1, 1, 0, 0, 0 }, { 0, 1, 0, 1, 0, 0, 0, 0 },
            { 0, 1, 1, 0, 1, 1, 0, 0}, {0, 1,0,1,0,1,0,0 }, {0, 0,0,1,1,0,1,1 }, { 0, 0,0,0,0,1,0,0}, { 0, 0,0,0,0,1,0,0} };

        public void Search(int i)
        {
            if (visitedArray[i] == 0)
            {
                Console.Write($"{i} ");
                visitedArray[i] = 1;

                for (int visited = 1; visited < visitedArray.Length; visited++)
                {
                    if (visitedArray[visited] == 0 && adjacencyMatrix[i, visited] == 1)
                    {
                        Search(visited);
                    }
                }
            }
        }
    }
}
