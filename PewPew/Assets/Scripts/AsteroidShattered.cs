using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Formats.Alembic.Importer;

public class AsteroidShattered : MonoBehaviour
{
    private AlembicStreamPlayer sp;
    private float startTime;
    public Vector3 asteroidScale;

    void Start()
    {
        sp = GetComponent<AlembicStreamPlayer>();
        startTime = Time.time;
        Vector3 actualScale = transform.localScale;
        actualScale.x *= asteroidScale.x;
        actualScale.y *= asteroidScale.y;
        actualScale.z *= asteroidScale.z;

        transform.localScale = actualScale;
    }

    void Update()
    {
        float currentT = Time.time - startTime;
        sp.CurrentTime = currentT;

        if(currentT > sp.EndTime)
            Destroy(gameObject);
    }
}
