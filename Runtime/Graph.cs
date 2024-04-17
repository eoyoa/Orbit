using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

// maybe put stuff like "known isomorphisms" or "clique number" stuff in the future.
public class Graph<T>
{
    public AdjacencyMatrix<T> AdjacencyMatrix { get; }
    public HashSet<T> VertexSet => AdjacencyMatrix.VertexSet;

    public Graph(AdjacencyMatrix<T> adjacencyMatrix)
    {
        AdjacencyMatrix = adjacencyMatrix;
    }

    public Graph(HashSet<T> vertexSet, IAdjacencyFunction<T> adjacencyFunction)
    {
        AdjacencyMatrix = new AdjacencyMatrix<T>(vertexSet, adjacencyFunction);
    }

    public bool CheckAdjacent(T v, T w)
    {
        return AdjacencyMatrix.CheckAdjacent(v, w);
    }
}

// try to consolidate into graph.
public class AdjacencyMatrix<T>
{
    [NotNull] private readonly Dictionary<T, Dictionary<T, bool>> _matrix = new();
    public HashSet<T> VertexSet => new HashSet<T>(_matrix.Keys);


    public AdjacencyMatrix(Dictionary<T, Dictionary<T, bool>> matrix)
    {
        // warning! should validate that all (v,w) pairs actually exist in the future
        _matrix = matrix;
    }
    public AdjacencyMatrix(HashSet<T> vertexSet, IAdjacencyFunction<T> adjacencyFunction)
    {
        foreach (var v in vertexSet)
        {
            _matrix[v] = new Dictionary<T, bool>();
            foreach (var w in vertexSet)
            {
                _matrix[v][w] = adjacencyFunction.CheckAdjacent(v, w);
            }
        }
    }

    public bool CheckAdjacent(T v, T w)
    {
        return _matrix[v][w];
    }
}