namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            //BFS bfs = new BFS();
            //bfs.Search(1);

            //DFS dfs = new DFS();
            //dfs.Search(1);

            Prims prims = new Prims();
            prims.MinimumCostSpanningTree();
        }
    }
}
