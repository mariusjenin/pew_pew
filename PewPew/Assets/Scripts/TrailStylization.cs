using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailStylization : MonoBehaviour
{
    TrailRenderer _tr;
    public float frequency;

    private int _frameCount;
    // Start is called before the first frame update
    void Start()
    {
        _tr = GetComponent<TrailRenderer>();
        _tr.startWidth = Mathf.Min(0.5f);
        _tr.endWidth = 0;
        _frameCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // ReSharper disable once CompareOfFloatsByEqualityOperator
        if(_frameCount == frequency)
        {
            _tr.emitting = !_tr.emitting;
            _frameCount = 0;
        }

        _frameCount ++;

    }
}
