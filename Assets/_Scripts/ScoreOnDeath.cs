using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnDeath : MonoBehaviour
{
    public int amount;

    private void Awake()
    {
        var live = GetComponent<Life>();
        live.onDeath.AddListener(GivePoints);
    }

    private void GivePoints()
    {
        ScoreManager.instance.amount += amount;
    }
}
