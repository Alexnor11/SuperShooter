using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WavesGameMode : MonoBehaviour
{
    [SerializeField] Life PlayerLife;
    [SerializeField] Life playerBaseLife;
    

    private void Start()
    {
        PlayerLife.onDeath.AddListener(OnPlayerDied);
        playerBaseLife.onDeath.AddListener(OnPlayerBaseDied);
        EnemyManager.instance.onChanged.AddListener(CheckWinCondition);
        WaveManager.instance.onChanged.AddListener(CheckWinCondition);
    }

    void OnPlayerDied()
    {
        SceneManager.LoadScene("LoseScreen");
    }

    void OnPlayerBaseDied()
    {
        SceneManager.LoadScene("LoseScreen");
    }

    private void CheckWinCondition()
    {
        if(EnemyManager.instance.enemies.Count <= 0 && WaveManager.instance.waves.Count <= 0)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
}
