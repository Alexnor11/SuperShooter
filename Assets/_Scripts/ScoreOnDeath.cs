using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnDeath : MonoBehaviour
{
    public int amount;

    private void Awake()
    {
        var life = GetComponent<Life>();
        life.onDeth.AddListener(GivePoints);
    }

    private void GivePoints()
    {
        ScoreManager.instance.amount += amount;
    }
}
