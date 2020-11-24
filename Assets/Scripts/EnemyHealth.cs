using UnityEngine;

public class EnemyHealth: MonoBehaviour
{
    [SerializeField] float health = 100f;

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");

        if (0 >= (health -= damage))
        {
            Destroy(gameObject);
        }
    }

}