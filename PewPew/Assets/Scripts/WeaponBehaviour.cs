using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class WeaponBehaviour : MonoBehaviour
{
    public Transform projectileSpawn;
    public InputActionReference shootingReference = null;
    public GameObject projectile;

    private BaseProjectileBehaviour _pb;
    private bool _onCoolDown;
    private float _lastShotTime;

    private void Shoot()
    {
        var position = projectileSpawn.position;
        GameObject instance = Instantiate(projectile, position, projectileSpawn.rotation);
        _pb = instance.GetComponent<BaseProjectileBehaviour>();

        _pb.dir = transform.forward;
        _pb.startPos = position;
    }

    private void CheckCooldown()
    {
        float elapsedTime = Time.time - _lastShotTime;
        _onCoolDown = !(_pb.cooldown <= elapsedTime);
      
    }
    
    void Start()
    {
        _onCoolDown = false;
    }

    void FixedUpdate()
    {
        float pressed = shootingReference.action.ReadValue<float>(); 

        if(pressed > 0)
        {
            if(!_onCoolDown)
            {
                //Trigger pressed and weapon is not on cooldown
                Shoot();
                _lastShotTime = Time.time;
            }
            CheckCooldown();
        }
    }

}
