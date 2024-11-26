namespace API.Utils {
  public static class Utils {
    static int[,] MagicAlgorithm(int[,] graph) {
      int V = graph.GetLength(0);
      int[,] dist = new int[V, V];

      // Initialize the distance matrix with the input graph matrix
      for (int i = 0; i < V; i++) {
        for (int j = 0; j < V; j++) {
          dist[i, j] = graph[i, j];
        }
      }

      // Update the distance matrix
      for (int k = 0; k < V; k++) {
        for (int i = 0; i < V; i++) {
          for (int j = 0; j < V; j++) {
            if (dist[i, j] > dist[i, k] + dist[k, j]) {
              dist[i, j] = dist[i, k] + dist[k, j];
            }
          }
        }
      }

      return dist;
    }
  }
}