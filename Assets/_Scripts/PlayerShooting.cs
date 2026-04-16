using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject shootPoint;

    public void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            GameObject clone = Instantiate(bullet);
            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;
        }
    }
}
