using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void Start()
    {
        EnemyManager.instance.AddEnemy(this);
    }

    private void OnDestroy()
    {
        EnemyManager.instance.RemoveEnemy(this);
    }
}
