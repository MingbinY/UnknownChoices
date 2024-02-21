using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OutcomeController : MonoBehaviour
{
    public bool isKnownOutcome;
    public GameObject outcomeUI;

    public float knownOutcomeHealth = 5;
    public float knownOutcomeAttack = 1;

    public float unknownOutcomeHealthPenalty = 0.7f;
    public float unknownOutcomeAttack = 20;

    public void OnSelectPrice()
    {
        //Give Player Price
        if (isKnownOutcome)
            KnownOutcome();
        else
            UnknowOutcome();

        GameManager.Instance.RewardSelected(!isKnownOutcome);
        LevelManager.Instance.waveManager.HidePriceCube();
        LevelManager.Instance.NextLevel();
    }

    public void KnownOutcome()
    {
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        Gun gun = FindObjectOfType<Gun>();
        playerHealth.health += knownOutcomeHealth;
        if (playerHealth.health > playerHealth.maxHealth)
        {
            playerHealth.health = playerHealth.maxHealth;
        }
        gun.damage += knownOutcomeAttack;
    }

    public void UnknowOutcome()
    {
        bool isBad = Random.Range(0,100) <= 50 ? false : true;

        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        Gun gun = FindObjectOfType<Gun>();

        if (isBad)
        {
            playerHealth.TakeDamage(playerHealth.maxHealth * unknownOutcomeHealthPenalty);
            gun.damage += 0.5f * knownOutcomeAttack;
        }
        else
        {
            playerHealth.health += 2 * knownOutcomeHealth;
            if (playerHealth.health > playerHealth.maxHealth)
            {
                playerHealth.health = playerHealth.maxHealth;
            }
            gun.damage += 1.5f * gun.damage;
        }
    }
}
