using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WavesGameMode : MonoBehaviour
{
    [SerializeField] Life playerLife;
    [SerializeField] Life playerBaseLife;

    private void Start()
    {
        playerLife.onDeth.AddListener(OnPlayerDied);
        playerBaseLife.onDeth.AddListener(OnPlayerBaseDied);
        EnemyManager.instance.onChanged.AddListener(CheckWinCondition);
        WaveManager.instance.onChanged.AddListener(CheckWinCondition);
    }

    private void CheckWinCondition()
    {
        if(EnemyManager.instance.enemies.Count <= 0 && WaveManager.instance.waves.Count <= 0)
        {
            SceneManager.LoadScene("WinScreen");
        }        
    }

    void OnPlayerDied()
    {
        SceneManager.LoadScene("LoseScreen");
    }

    void OnPlayerBaseDied()
    {
        SceneManager.LoadScene("LoseScreen");
    }
}
