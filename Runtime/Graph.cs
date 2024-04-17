using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

// maybe put stuff like "known isomorphisms" or "clique number" stuff in the future.
public class Graph<T>
{
    public AdjacencyList<T> AdjacencyList { get; }
    public HashSet<T> VertexSet => AdjacencyList.VertexSet;

    public Graph(AdjacencyList<T> adjacencyList)
    {
        AdjacencyList = adjacencyList;
    }

    public Graph(HashSet<T> vertexSet, IAdjacencyFunction<T> adjacencyFunction)
    {
        AdjacencyList = new AdjacencyList<T>(vertexSet, adjacencyFunction);
    }

    public bool CheckAdjacent(T v, T w)
    {
        return AdjacencyList.CheckAdjacent(v, w);
    }

    // untested
    public override bool Equals(object obj)
    {
        return obj is Graph<T> graph && Equals(graph);
    }

    // untested
    private bool Equals(Graph<T> other)
    {
        return Equals(AdjacencyList, other.AdjacencyList);
    }

    // TODO: make Equals with Isomorphism

    public override int GetHashCode()
    {
        return (AdjacencyList != null ? AdjacencyList.GetHashCode() : 0);
    }
}

// try to consolidate into graph.
public class AdjacencyList<T>
{
    [NotNull] private readonly Dictionary<T, HashSet<T>> _matrix = new();
    public HashSet<T> VertexSet => new HashSet<T>(_matrix.Keys);
    
    public AdjacencyList(Dictionary<T, HashSet<T>> matrix)
    {
        _matrix = matrix;
    }
    public AdjacencyList(HashSet<T> vertexSet, IAdjacencyFunction<T> adjacencyFunction)
    {
        foreach (var v in vertexSet)
        {
            _matrix[v] = new HashSet<T>();
            foreach (var w in vertexSet)
            {
                if (adjacencyFunction.CheckAdjacent(v, w))
                {
                    _matrix[v].Add(w);
                }
            }
        }
    }

    public bool CheckAdjacent(T v, T w)
    {
        if (!_matrix.ContainsKey(v))
        {
            // potentially throw error in the future
            return false;
        }
        return _matrix[v].Contains(w);
    }

    // untested
    public override bool Equals(object obj)
    {
        return obj is AdjacencyList<T> adjacencyList && Equals(adjacencyList);
    }

    // untested
    private bool Equals(AdjacencyList<T> adjacencyList)
    {
        if (adjacencyList.VertexSet.Count != this.VertexSet.Count) return false;
        foreach (var (v, neighborhood) in _matrix)
        {
            if (neighborhood.Any(w => !adjacencyList.CheckAdjacent(v, w)))
            {
                return false;
            }
            // TODO: didn't check nonadjacent vertices are still nonadjacent
            // TODO: move this to an IdentityIsomorphism
        }

        return true;
    }
}