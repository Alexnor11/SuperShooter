using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    void Start()
    {
        EnemyManager.instance.enemies.Add(this);
    }
    private void OnDestroy()
    {
        EnemyManager.instance.enemies.Remove(this);
    }
}
