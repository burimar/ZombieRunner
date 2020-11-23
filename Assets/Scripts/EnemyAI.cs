using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target = default;
    [SerializeField] float chaseRange = 10;
    [SerializeField] float lookSpeed = 5;

    NavMeshAgent navMeshAgent;
    Animator animator;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }

        // TODO: how is the zombie getting idle again?
        // animator.SetTrigger("idle");
    }

    void EngageTarget()
    {
        FaceTarget();

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

    void FaceTarget()
    {
        Vector3 riectionToTarget = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(riectionToTarget.x, 0, riectionToTarget.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, lookSpeed);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

}
