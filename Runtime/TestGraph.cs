using System;
using System.Collections.Generic;
using System.Linq;
using Library;
using UnityEngine;

public class TestGraph : MonoBehaviour
{
    public List<GameObject> vertices = new();
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

                var edge = Instantiate(edgePrefab, (v.transform.position + w.transform.position) / 2,
                    Quaternion.identity);
                edge.GetComponent<Edge>().v = v;
                edge.GetComponent<Edge>().w = w;
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