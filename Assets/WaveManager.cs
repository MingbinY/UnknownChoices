using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public List<Transform> spawnPoints;
    [SerializeField]
    private List<GameObject> cubesList;
    public GameObject enemyPrefab;

    public int killCount = 0;
    public bool levelEnded = true;
    private void Awake()
    {
        if (spawnPoints.Count <= 0)
        {
            Application.Quit();
        }

        killCount = 0;
    }

    private void Update()
    {
        if (killCount == 5)
        {
            levelEnded = true;
            LevelEnd();
        }
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
        foreach (GameObject cube in cubesList){
            cube.SetActive(true);
        }
    }

    public void EnemyKilled()
    {
        killCount++;
    }

    public void HidePriceCube()
    {
        foreach (GameObject cube in cubesList) 
        {
            cube.SetActive(false);
        }
    }
}
