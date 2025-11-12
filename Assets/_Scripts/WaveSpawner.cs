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
        WaveManager.instance.waves.Add(this);

        InvokeRepeating("Spawn", starttTime, spawnRate);
        Invoke("EndSpawner", endTime);

        Spawn();
    }
    void Spawn()
    {
        Instantiate(prefab, transform.position, transform.rotation); 
    }
    void EndSpawner()
    {
        WaveManager.instance.waves.Remove(this);
        CancelInvoke();
    }
}
