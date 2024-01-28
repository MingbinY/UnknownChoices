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
        NextLevel();
    }

    private void Update()
    {
        
    }

    public void NextLevel()
    {
        currentLevel++;
        enemyHealth = Mathf.Pow(1.5f, currentLevel);
        enemyDamage = currentLevel+1;
        waveManager.SpawnEnemy();
    }
}
