using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectileBehaviour : MonoBehaviour
{
    public GameObject projectileMesh;
    public float cooldown;
    public float range;
    public float speed = 1;

    public Vector3 startPos;
    public Vector3 dir; //Forward dir of cannon

    private Vector3 targetPos;
    private Vector3 total;
    private float startTime;


    void Start()
    {
        targetPos = startPos + (dir * range);
        startTime = Time.time;
    }

    void FixedUpdate()
    {
        if(transform.position == targetPos)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            float timeElapsed = (Time.time - startTime) * speed*5;

            float t = timeElapsed / targetPos.magnitude;

            transform.position = Vector3.Lerp(startPos, targetPos, t);


        }

    }
}
