using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float starttTime;
    public float endTime;
    public float spawnRate;

    private void Start()
    {
        InvokeRepeating("Spawn", starttTime, spawnRate);
        Invoke("CancelInvoke", endTime);

        Spawn();
    }
    void Spawn()
    {
        Instantiate(prefab, transform.position, transform.rotation); 
    }
}
