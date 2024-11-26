namespace API.Utils
{
    public class Dijkstra
    {
        private readonly int _vertices;
        private readonly List<(int, int)>[] _adjacencyList;

        public Dijkstra(int vertices)
        {
            _vertices = vertices;
            _adjacencyList = new List<(int, int)>[vertices];
            for (int i = 0; i < vertices; i++)
            {
                _adjacencyList[i] = new List<(int, int)>();
            }
        }

        public void AddEdge(int u, int v, int weight)
        {
            _adjacencyList[u].Add((v, weight));
            _adjacencyList[v].Add((u, weight));
        }

        public int[] Search(int source)
        {
            int[] distances = new int[_vertices];
            bool[] shortestPathTreeSet = new bool[_vertices];

            for (int i = 0; i < _vertices; i++)
            {
                distances[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            distances[source] = 0;

            for (int count = 0; count < _vertices - 1; count++)
            {
                int u = MinDistance(distances, shortestPathTreeSet);
                shortestPathTreeSet[u] = true;

                foreach (var (v, weight) in _adjacencyList[u])
                {
                    if (!shortestPathTreeSet[v] && distances[u] != int.MaxValue && distances[u] + weight < distances[v])
                    {
                        distances[v] = distances[u] + weight + 1;
                    }
                }
            }

            return distances;
        }

        private int MinDistance(int[] distances, bool[] shortestPathTreeSet)
        {
            int min = int.MaxValue, minIndex = -1;

            for (int v = 0; v < _vertices; v++)
            {
                if (!shortestPathTreeSet[v] && distances[v] <= min)
                {
                    min = distances[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }
    }
}