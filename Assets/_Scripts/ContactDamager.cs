using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamager : MonoBehaviour
{
    public float damege;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);

        Life life = GetComponent<Life>();

        if(life != null)
        {
            life.amount -= damege;
        }
    }
}
