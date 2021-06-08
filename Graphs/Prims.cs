using System;

namespace Graphs
{
    class Prims
    {
        private static int max = int.MaxValue;

        int[,] cost = new int[,] {
            { max, max, max, max, max, max, max, max},
            { max, max, 25, max, max, max, 5, max },
            { max, 25, max, 12, max, max, max, 10 },
            { max, max, 12, max, 8, max, max, max},
            { max, max, max, 8, max, 16, max, 14 },
            { max, max, max, max, 16, max, 20, 18 },
            { max, 5, max, max, max, 20, max, max},
            { max, max, 10, max, 14, 18, max, max} };

        //Each column here represents a minimum value inside a row in the cost adjacency matrix
        int[] near = new int[8] { max, max, max, max, max, max, max, max };

        //Maintains a list of vertices that have minimum value
        int[,] verticesOfEdge = new int[2, 6];

        public void MinimumCostSpanningTree()
        {
            var values = FindMinimumCostAmongEdges();
            int u = values.Item2;
            int v = values.Item3;
            verticesOfEdge[0, 0] = u;
            verticesOfEdge[1, 0] = v;
            near[u] = 0;
            near[v] = 0;

            //checks for all rows reprsenting a vertex, out of u or v which is near to that vertex.
            for (int index = 1; index < near.GetLength(0); index++)
            {
                //already visited
                if (near[index] != 0)
                {
                    if (cost[index, u] < cost[index, v])
                        near[index] = u;
                    else
                        near[index] = v;
                }
            }

            //Do the above procedure for the remaining array.
            for (int index = 1; index < verticesOfEdge.GetLength(1); index++)
            {
                int vertex = 0;
                int min = int.MaxValue;
                //Find the minimum value and vertex among all the near edges to the previous vertices.
                for (int j = 1; j < near.Length; j++)
                {
                    if (near[j] != 0 && cost[j, near[j]] < min)
                    {
                        min = cost[j, near[j]];
                        vertex = j;
                    }
                }
                verticesOfEdge[0, index] = vertex; //current choosen vertex
                verticesOfEdge[1, index] = near[vertex]; //previous value of that vertex with which it was near to you.
                near[vertex] = 0;//Vertex included

                //Update near array
                for (int j = 1; j < near.GetLength(0); j++)
                {
                    if (near[j] != 0 && cost[j, vertex] < cost[j, near[vertex]])
                        near[j] = vertex;
                }
            }
            int sum = 0;
            for (int j = 0; j < verticesOfEdge.GetLength(1); j++)
            {
                Console.WriteLine($"({verticesOfEdge[0, j]},{verticesOfEdge[1, j]})");
                sum += cost[verticesOfEdge[0, j], verticesOfEdge[1, j]];
            }
            Console.WriteLine($"Sum: {sum}");

        }



        Tuple<int, int, int> FindMinimumCostAmongEdges()
        {
            int u = 0;
            int v = 0;
            int min = int.MaxValue;
            for (int row = 1; row < cost.GetLength(0); row++)
            {
                // Checking only upper diagonal as values are repeated in lower diagonal being an undirected graph.
                for (int column = row; column < cost.GetLength(1); column++)
                {
                    if (cost[row, column] < min)
                    {
                        min = cost[row, column];
                        u = row;
                        v = column;
                    }
                }
            }
            return new Tuple<int, int, int>(min, u, v);
        }

    }
}
