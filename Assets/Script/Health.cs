using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public bool isPlayer;
    public AudioClip deathClip;

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

    public virtual void TakeDamage(float damage)
    { 
        # if UNITY_EDITOR
        Debug.Log("TakeDamage");
        # endif
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

    public virtual void Death()
    {
        if (isPlayer)
        {
            
        }
        else
        {
            //Enemyd ied
            LevelManager.Instance.waveManager.EnemyKilled();
            Destroy(gameObject);
        }

        GetComponent<AudioSource>().PlayOneShot(deathClip);
    }
}
