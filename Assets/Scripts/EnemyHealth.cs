using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth: MonoBehaviour
{
    [SerializeField] float health = 100f;

    private bool isDead = false;

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");

        if (0 >= (health -= damage))
        {
            Die();
        }
    }

    public bool IsDead()
    {
        return isDead;
    }

    private void Die()
    {
        GetComponent<Animator>().SetTrigger("dead");

        GetComponent<EnemyAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        enabled = false;
    }
}