using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReticle : MonoBehaviour
{
    private GameObject _leftController;
    private GameObject _rightController;
    
    private GameObject _cannonTransformLeft;
    private GameObject _cannonTransformRight;

    

    // Start is called before the first frame update
    void Start()
    {
        _leftController = GameObject.Find("LeftHand Controller");     
        _rightController = GameObject.Find("RightHand Controller");     

        _cannonTransformLeft = GameObject.Find("CannonTransformLeft");   
        _cannonTransformRight = GameObject.Find("CannonTransformRight");   
    }

    // Update is called once per frame
    void Update()
    {
        _cannonTransformLeft.transform.rotation = _leftController.transform.rotation;
        _cannonTransformRight.transform.rotation = _rightController.transform.rotation;
    }
}
