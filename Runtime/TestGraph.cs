using System;
using System.Collections.Generic;
using System.Linq;
using Library;
using UnityEngine;

public class TestGraph : MonoBehaviour
{
    public List<GameObject> vertices = new();
    public List<EdgeSegment> edges = new();
    public GameObject edgePrefab;
    
    private Graph<GameObject> _graph;

    private void Awake()
    {
        _graph = new Graph<GameObject>(new HashSet<GameObject>(vertices), new TestAdjacencyFunction());
    }

    private void Start()
    {
        // lame way of doing this
        // - consider AdjacencyMatrix holding edge objects instead of bool, so we can just keep refs

        foreach (var v in vertices)
        {
            foreach (var w in vertices.Where(w => _graph.CheckAdjacent(v, w)))
            {
                if (!edgePrefab)
                {
                    Debug.LogWarning("no edge prefab");
                    return;
                }

                var edgeObject = Instantiate(edgePrefab, (v.transform.position + w.transform.position) / 2,
                    Quaternion.identity);
                var edge = edgeObject.GetComponent<EdgeSegment>();
                edge.v = v;
                edge.w = w;

                var putInList = true;
                foreach (var otherEdge in edges.Where(otherEdge => (otherEdge.v == edge.v && otherEdge.w == edge.w) ||
                                                                   (otherEdge.v == edge.w && otherEdge.w == edge.v)))
                {
                    putInList = false;
                }

                if (!putInList)
                {
                    Destroy(edgeObject);
                    continue;
                }

                edges.Add(edge);
            }
        }
    }
}

class TestAdjacencyFunction : IAdjacencyFunction<GameObject>
{
    public bool CheckAdjacent(GameObject v, GameObject w)
    {
        return !v.Equals(w);
    }
}