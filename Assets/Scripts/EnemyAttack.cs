using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target = default;
    [SerializeField] float damage = 40f;

    void Start()
    {
        
    }

    public void AttackHitEvent()
    {
        if (target == null) return;

        Debug.Log("Hit you noob");

    }
    
}
