using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReticle : MonoBehaviour
{
    private GameObject leftController;
    private GameObject rightController;
    
    private GameObject cannonTransformLeft;
    private GameObject cannonTransformRight;

    

    // Start is called before the first frame update
    void Start()
    {
        leftController = GameObject.Find("LeftHand Controller");     
        rightController = GameObject.Find("RightHand Controller");     

        cannonTransformLeft = GameObject.Find("CannonTransformLeft");   
        cannonTransformRight = GameObject.Find("CannonTransformRight");   
    }

    // Update is called once per frame
    void Update()
    {
        cannonTransformLeft.transform.rotation = leftController.transform.rotation;
        cannonTransformRight.transform.rotation = rightController.transform.rotation;
    }
}
