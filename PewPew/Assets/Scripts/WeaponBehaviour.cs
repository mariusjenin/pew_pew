using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class WeaponBehaviour : MonoBehaviour
{
    public Transform projectileSpawn;
    public InputActionReference shootingReference = null;
    public GameObject projectile;

    private BaseProjectileBehaviour pb;
    private bool onCoolDown;
    private float lastShotTime;

    private void shoot()
    {
        GameObject instance = Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
        pb = instance.GetComponent<BaseProjectileBehaviour>();

        pb.dir = transform.forward;
        pb.startPos = projectileSpawn.position;
    }

    private void checkCooldown()
    {
        float elapsedTime = Time.time - lastShotTime;
        onCoolDown = !(pb.cooldown <= elapsedTime);
      
    }
    
    void Start()
    {
        onCoolDown = false;
    }

    void FixedUpdate()
    {
        float pressed = shootingReference.action.ReadValue<float>(); 

        if(pressed > 0)
        {
            if(!onCoolDown)
            {
                //Trigger pressed and weapon is not on cooldown
                shoot();
                lastShotTime = Time.time;
            }
            checkCooldown();
        }
    }

}
