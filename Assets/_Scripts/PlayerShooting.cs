using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject shootPoint;
    public ParticleSystem muzzleEffect;
    public AudioSource shootSound;
    public int bulletsAmount;

    public void OnFire(InputValue value)
    {
        if (value.isPressed && bulletsAmount > 0 && Time.timeScale > 0) 
        {
            bulletsAmount--;
            
            GameObject clone = Instantiate(Bullet);
            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;

            muzzleEffect.Play();
            shootSound.Play();
        }
    }
}
