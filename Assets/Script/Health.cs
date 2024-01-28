using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public bool isPlayer;

    private void Start()
    {
        if (isPlayer)
        {

        }
        else
        {
            maxHealth = LevelManager.Instance.enemyHealth;
        }

        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (health < damage)
        {
            health = 0;
        }
        else
        {
            health -= damage;
        }

        if (health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        if (isPlayer)
        {
            
        }
        else
        {
            //Enemy died
            LevelManager.Instance.waveManager.EnemyKilled();
            Destroy(gameObject);
        }
    }
}
