using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Obsolete]
// more like temporary stopgap.
// hopefully replaced eventually.
public class Edge : MonoBehaviour
{
    public GameObject v;
    public GameObject w;

    // Update is called once per frame
    void Update()
    {
        transform.position = (v.transform.position + w.transform.position) / 2;
    }
}
