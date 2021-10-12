using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum BarbarinWarriorOpponentState
{
    CHASE,
    ATTACK
}

public class BarbarinWarriorAIController : MonoBehaviour
{
    private BarbarinWarriorAnimations barbarinOpponentAnim;
    private NavMeshAgent barbarinWarriorAgent;
    private Transform target;
    private float waitBeforeAttack = 2.5f;
    private float attackTimer;
    private BarbarinWarriorOpponentState barbarinWarriorState;

    public float moveSpeed;
    public float attackDistance;
    public float chasePlayerAfterAttackDistance;
    public GameObject attackPoint;

    private void Awake()
    {
        barbarinOpponentAnim = GetComponent<BarbarinWarriorAnimations>();
        barbarinWarriorAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;
    }

    private void Start()
    {
        barbarinWarriorState = BarbarinWarriorOpponentState.CHASE;
        attackTimer = waitBeforeAttack;
    }

    private void Update()
    {
        if(barbarinWarriorState == BarbarinWarriorOpponentState.CHASE)
        {
            Chase();
        }

        if(barbarinWarriorState == BarbarinWarriorOpponentState.ATTACK)
        {
            Attack();
        }
    }

    private void Chase()
    {
        barbarinWarriorAgent.SetDestination(target.position);
        barbarinWarriorAgent.speed = moveSpeed;

        if (barbarinWarriorAgent.velocity.sqrMagnitude == 0)
        {
            barbarinOpponentAnim.Walk(false);
            barbarinOpponentAnim.Sprint(false);
        }
        else
        {
            barbarinOpponentAnim.Sprint(true);
            barbarinOpponentAnim.Walk(false);
        }

        if (Vector3.Distance(transform.position, target.position) <= attackDistance)
        {
            barbarinWarriorState = BarbarinWarriorOpponentState.ATTACK;
        }
    }

    private void Attack()
    {
        barbarinWarriorAgent.velocity = Vector3.zero;
        barbarinWarriorAgent.isStopped = true;

        barbarinOpponentAnim.Walk(false);
        barbarinOpponentAnim.Sprint(false);

        attackTimer += Time.deltaTime;

        if(attackTimer > waitBeforeAttack)
        {
            if(Random.Range(0, 2) > 0)
            {
                barbarinOpponentAnim.Attack_1();
            }
            else
            {
                barbarinOpponentAnim.Attack_2();
            }

            attackTimer = 0;
        }

        if(Vector3.Distance(transform.position, target.position) > attackDistance + chasePlayerAfterAttackDistance)
        {
            barbarinWarriorAgent.isStopped = false;
            barbarinWarriorState = BarbarinWarriorOpponentState.CHASE;
        }
    }

    private void ActivateAttackPoint()
    {
        attackPoint.SetActive(true);
    }

    private void DeactivateAttackPoint()
    {
        if (attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }
    }
}
