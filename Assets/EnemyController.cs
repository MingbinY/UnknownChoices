using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    chase,
    attack,
}

public class EnemyController : MonoBehaviour
{
    EnemyState enemyState = EnemyState.chase;
    public GameObject player;
    public float attackRange = 1f;
    public float attackInterval = 1f;
    float lastAttackTime = 0f;
    public float moveSpeed = 3f;

    NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerHealth>().gameObject;
        enemyState = EnemyState.chase;
        agent.speed = moveSpeed;
        agent.stoppingDistance = attackRange-0.2f;
        lastAttackTime = Time.time;
    }

    private void Update()
    {
        if (enemyState == EnemyState.chase)
        {
            ChaseUpdate();
        }
        else if (enemyState == EnemyState.attack)
        {
            AttackUpdate();
        }
    }

    void ChaseUpdate()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < attackRange)
            enemyState = EnemyState.attack;
        agent.stoppingDistance = attackRange - 0.2f;
        agent.SetDestination(player.transform.position);
    }

    void AttackUpdate()
    {
        if (Vector3.Distance(player.transform.position, transform.position) > attackRange)
            enemyState = EnemyState.chase;

        if (Time.time  -  lastAttackTime < attackInterval)
        {
            return;
        }
        lastAttackTime = Time.time;
        player.GetComponent<PlayerHealth>().TakeDamage(LevelManager.Instance.enemyDamage);
    }
}
