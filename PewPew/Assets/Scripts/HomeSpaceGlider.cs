using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeSpaceGlider : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform shipTransform;
    [SerializeField] private float heightMaxShip;
    [SerializeField] private float heightMinShip;
    [SerializeField] private float speedOscillationShip;
    [SerializeField] private float speedRotation;

    private bool _shipDirection; // true -> up | false -> down

    // Start is called before the first frame update
    void Start()
    {
        _shipDirection = true;
    }

    private void FixedUpdate()
    {
        var heightShip = shipTransform.localPosition.y;
        if (_shipDirection)
        {
            if (heightShip > heightMaxShip)
            {
                _shipDirection = false;
            }
        }
        else
        {
            if (heightShip < heightMinShip)
            {
                _shipDirection = true;
            }
        }
        var move = _shipDirection ? speedOscillationShip/2 : -speedOscillationShip;
        var t = (float)Math.Abs((heightMaxShip - heightShip) / (heightMaxShip - heightMinShip) - 0.5)*2;
        var amount =  1-t; 

        shipTransform.Translate(new Vector3(0f,0f, move*(1-t)*0.9f +move*0.1f), Space.Self);
        cameraTransform.Rotate(0,-speedRotation,0,Space.Self);
    }
}