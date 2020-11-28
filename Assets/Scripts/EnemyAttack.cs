using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float damage = 20f;

    PlayerHealth target = default;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    // called by animation event
    public void AttackHitEvent()
    {
        if (target != null)
        {
            target.TakeDamage(damage);
        }
    }
    
}
