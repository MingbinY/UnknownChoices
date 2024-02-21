using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public WaveManager waveManager;
    public int currentLevel;

    [Header("Enemy Stats")]
    public float enemyHealth;
    public float enemyDamage;

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
        currentLevel++;
        enemyHealth = 1+Mathf.Pow(1.6f, currentLevel);
        enemyDamage = currentLevel+1;
        waveManager.SpawnEnemy();
    }
}
