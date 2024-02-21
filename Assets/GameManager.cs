using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    float timer;
    public List<int> randomWave;
    public List<int> stableWave;

    public GameObject gameoverUI;

    private void Awake()
    {
        Instance = this;
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    public void RewardSelected(bool isRandom)
    {
        if (isRandom)
        {
            randomWave.Add(LevelManager.Instance.currentLevel);
        }
        else
        {
            stableWave.Add(LevelManager.Instance.currentLevel);
        }
    }

    public float GetGameTime()
    {
        return timer;
    }

    public void GameOver(bool isWin)
    {
        gameoverUI.SetActive(true);
        gameoverUI.GetComponentInChildren<GameStatsUI>().AssignStatsToUI(isWin);
        MusicManager.Instance.StopMusic();
        EnemyController[] enemies = FindObjectsOfType<EnemyController>();
        foreach (EnemyController enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }
    }
}
