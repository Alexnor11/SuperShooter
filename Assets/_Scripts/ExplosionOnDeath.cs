using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionOnDeath : MonoBehaviour
{
    public GameObject particlePrefab;
    public AudioSource explosionsSound;

    private void Awake()
    {
        var life = GetComponent<Life>();
        life.onDeth.AddListener(OnDeath);
    }

    void OnDeath()
    {
        Instantiate(particlePrefab, transform.position, transform.rotation);
        Instantiate(explosionsSound);
    }
}

