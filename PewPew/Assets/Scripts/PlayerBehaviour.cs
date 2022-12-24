using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public float _hp = 100;
    public Slider hpSliderUi;

    void FixedUpdate()
    {
        if(_hp <= 0)
        {
            Debug.Log("YOU LOST.");
            //TODO: UI: lost screen.
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("asteroid"))
        {
            GameObject asteroidGo = other.gameObject;
            Destroy(asteroidGo);
            _hp -= 10;
            hpSliderUi.value = Mathf.Max(_hp, 0);
        }
    }
}
