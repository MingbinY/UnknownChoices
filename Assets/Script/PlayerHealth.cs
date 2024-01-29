using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    public override void Death()
    {
        if (isPlayer)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            //Enemy died
            LevelManager.Instance.waveManager.EnemyKilled();
            Destroy(gameObject);
        }
    }
}

