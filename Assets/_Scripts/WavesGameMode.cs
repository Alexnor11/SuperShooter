using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WavesGameMode : MonoBehaviour
{
    [SerializeField] Life PlayerLife;
    [SerializeField] Life playerBaseLife;

    private void Awake()
    {
        PlayerLife.onDeath.AddListener(OnPlayerDied);
        playerBaseLife.onDeath.AddListener(OnPlayerBaseDied);
    }

    void OnPlayerDied()
    {
        SceneManager.LoadScene("LoseScreen");
    }

    void OnPlayerBaseDied()
    {
        SceneManager.LoadScene("LoseScreen");
    }

    private void Update()
    {
        if(EnemyManager.instance.enemies.Count <= 0 && WaveManager.instance.waves.Count <= 0)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
}
