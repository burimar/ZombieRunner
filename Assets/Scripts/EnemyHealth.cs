using UnityEngine;

public class EnemyHealth: MonoBehaviour
{
    [SerializeField] float health = 10f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }

}