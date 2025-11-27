using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject Enemy;
    public float startTime;
    public float endTime;
    public float spawnRate;

    private void Start()
    {
        InvokeRepeating("Spawn", startTime, spawnRate);
        Invoke("CancelInvoke", endTime);
    }

    void Spawn()
    {
        Instantiate(Enemy, transform.position,transform.rotation);
    }
}
