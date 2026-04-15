using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject shootPoint;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject clone = Instantiate(bullet);
            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;
        }
    }
}
