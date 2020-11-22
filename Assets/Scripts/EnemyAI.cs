using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target = default;
    [SerializeField] float chaseRange = 10;

    NavMeshAgent navMeshAgent;
    Animator animator;
    float distanceToTarget = Mathf.Infinity;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget <= chaseRange)
        {
            EngageTarget();
        } else
        {
            animator.SetTrigger("idle");
        }
    }

    void EngageTarget()
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            animator.SetBool("attack", false);
            animator.SetTrigger("move");
            navMeshAgent.SetDestination(target.position);
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            animator.SetBool("attack", true);
        }
    }

     void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

}
