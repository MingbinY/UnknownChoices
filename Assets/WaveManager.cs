using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public List<Transform> spawnPoints;
    [SerializeField]
    private List<GameObject> CubesList;
    public GameObject enemyPrefab;

    int killCount = 0;

    private void Awake()
    {
        if (spawnPoints.Count <= 0)
        {
            Application.Quit();
        }

        killCount = 0;
    }

    public void SpawnEnemy()
    {
        foreach (Transform t in spawnPoints)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, t.position, Quaternion.identity);
        }
    }

    public void LevelEnd()
    {
        killCount = 0;
        // Cube的UI和数值生成
        // 显示Cube
        foreach (GameObject cube in CubesList){
            cube.SetActive(true);
        }
    }

    public void EnemyKilled()
    {
        killCount++;
    }
}
