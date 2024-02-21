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

    Animator animator;

    public AudioClip roarClip;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerHealth>().gameObject;
        animator = GetComponentInChildren<Animator>();
        enemyState = EnemyState.chase;
        agent.speed = moveSpeed;
        agent.stoppingDistance = attackRange;
        lastAttackTime = Time.time;
    }

    private void Update()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);
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
        agent.updateRotation = true;
        agent.stoppingDistance = attackRange;
        agent.SetDestination(player.transform.position);
    }

    void AttackUpdate()
    {
        if (Vector3.Distance(player.transform.position, transform.position) > attackRange + 1f)
        {
            enemyState = EnemyState.chase;
            return;
        }


        FacePlayer();
        if (Time.time  -  lastAttackTime < attackInterval)
        {
            return;
        }
        lastAttackTime = Time.time;
        player.GetComponent<PlayerHealth>().TakeDamage(LevelManager.Instance.enemyDamage);
    }

    void FacePlayer()
    {
        transform.forward = player.transform.position - transform.position;
    }
}
