using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScript : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        transform.Translate(0, 0, speed);
    }

}
