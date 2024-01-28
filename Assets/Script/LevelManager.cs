using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public int currentLevel;

    [Header("Enemy Stats")]
    public float enemyHealth;
    public float enemyAttack;

    private void Awake()
    {
        Instance = this;
        currentLevel = -1;
    }

    public void NextLevel()
    {
        currentLevel++;
        enemyHealth = Mathf.Pow(1.5f, currentLevel);
        enemyAttack = currentLevel+1;
    }
}
