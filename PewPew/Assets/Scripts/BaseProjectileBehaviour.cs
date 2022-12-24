using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectileBehaviour : MonoBehaviour
{
    public GameObject projectileMesh;
    public float damages;
    public float cooldown;
    public float range;
    public float speed;

    public Vector3 startPos;
    public Vector3 dir; //Forward dir of cannon

    private Vector3 _targetPos;
    private Vector3 _total;
    private float _startTime;


    void Start()
    {
        _targetPos = startPos + (dir * range);
        _startTime = Time.time;
    }

    void FixedUpdate()
    {
        if(transform.position == _targetPos)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            float timeElapsed = (Time.time - _startTime) * speed*5;

            float t = timeElapsed / _targetPos.magnitude;

            transform.position = Vector3.Lerp(startPos, _targetPos, t);

        }

    }


    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "asteroid")
        {
            GameObject asteroidGo = other.gameObject;
            asteroidGo.GetComponent<Asteroid>().TakeDamages(damages);
            Destroy(gameObject);
        }
    }
}
