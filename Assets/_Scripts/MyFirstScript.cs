using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScript : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    void Start()
    {
        print("Speed: " + speed);
    }

    
    void Update()
    {
        
    }
}
