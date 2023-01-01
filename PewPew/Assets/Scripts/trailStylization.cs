using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailStylization : MonoBehaviour
{
    TrailRenderer tr;
    public float frequency;

    private int frameCount;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<TrailRenderer>();
        tr.startWidth = Mathf.Min(0.5f);
        tr.endWidth = 0;
        frameCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(frameCount == frequency)
        {
            tr.emitting = !tr.emitting;
            frameCount = 0;
        }

        frameCount ++;

    }
}
