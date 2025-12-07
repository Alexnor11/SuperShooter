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
        WaveManager.instance.AddWave(this);
        InvokeRepeating("Spawn", startTime, spawnRate);
        Invoke("EndSpawner", endTime);
    }

    void Spawn()
    {
        Instantiate(Enemy, transform.position,transform.rotation);
    }

    void EndSpawner()
    {
        WaveManager.instance.RemoveWave(this);
        CancelInvoke();
    }
}
