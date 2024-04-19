using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Obsolete]
// more like temporary stopgap.
// hopefully replaced eventually.
public class EdgeSegment : MonoBehaviour
{
    public GameObject v;
    public GameObject w;
    private Rigidbody _rigidbody;

    // Update is called once per frame
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (_rigidbody)
        {
            _rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
        }
    }

    void Update()
    {
        var midpoint = (v.transform.position + w.transform.position) / 2;
        if (!_rigidbody)
        {
            transform.position = midpoint;
            return;
        }

        var restoringForce = (midpoint - transform.position);

        _rigidbody.AddForce(restoringForce);
        _rigidbody.drag = _rigidbody.velocity.magnitude;
    }
}
