using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public WaveManager waveManager;
    public int currentLevel;
    public int maxLevel = 8;

    [Header("Enemy Stats")]
    public float enemyHealth;
    public float enemyDamage;
    public float enemySpeed;

    private void Awake()
    {
        Instance = this;
        currentLevel = -1;
    }

    private void Start()
    {
        NextLevel();
    }

    public void NextLevel()
    {
        if (currentLevel+1 == maxLevel)
        {
            GameManager.Instance.GameOver(true);
            return;
        }
        currentLevel++;
        enemyHealth = 1+Mathf.Pow(1.6f, currentLevel);
        enemyDamage = currentLevel+1;
        enemySpeed += 0.25f;
        waveManager.SpawnEnemy();
    }
}
