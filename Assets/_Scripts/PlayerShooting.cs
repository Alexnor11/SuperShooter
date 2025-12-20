using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject shootPoint;
    public ParticleSystem muzzleEffect;
    public AudioSource shootSound;
    public int bulletsAmount;
    public float fireRate;

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnFire(InputValue value)
    {
        animator.SetBool("Shooting", value.isPressed);

        if (value.isPressed)
        {
            InvokeRepeating("Shoot", fireRate, fireRate);
        }
        else
        {
            CancelInvoke();
        }
     }

    private void Shoot()
    {
        if (bulletsAmount > 0 && Time.timeScale > 0)
        {
            bulletsAmount--;

            GameObject clone = Instantiate(bullet);

            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;

            muzzleEffect.Play();
            shootSound.Play();
        }
    }
}
