using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    public AudioClip takeHitClip;

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        if (takeHitClip != null && GetComponent<AudioSource>())
        {
            GetComponent<AudioSource>().PlayOneShot(takeHitClip);
        }
    }
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

