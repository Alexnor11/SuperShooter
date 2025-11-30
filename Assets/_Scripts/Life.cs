using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    public float amount;
    public UnityEvent onDeth;

    private void Update()
    {
        if(amount <= 0)
        {
            onDeth.Invoke();
            Destroy(gameObject);
        }
    }
}
