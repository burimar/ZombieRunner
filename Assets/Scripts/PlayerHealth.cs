using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] Canvas damageTakenCanvas;

    void Start()
    {
        damageTakenCanvas.enabled = false;
    }

    public void TakeDamage(float damage)
    {
        StartCoroutine(ShowDamageReceivedCanvas());
        DecreaseHealth(damage);
    }

    private IEnumerator ShowDamageReceivedCanvas()
    {
        damageTakenCanvas.enabled = true;
        yield return new WaitForSeconds(0.3f);
        damageTakenCanvas.enabled = false;
    }

    private void DecreaseHealth(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }

}
