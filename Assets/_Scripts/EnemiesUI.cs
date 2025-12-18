using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemiesUI : MonoBehaviour
{
    TMP_Text text;

    private void Start()
    {
        text = GetComponent<TMP_Text>();
        EnemyManager.instance.onChanged.AddListener(RefreshText);
    }

    void RefreshText()
    {
        text.text = "Reamining Elements: " + EnemyManager.instance.enemies.Count;
    }
}
