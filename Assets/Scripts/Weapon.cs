using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera firstPersonCam;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 3;
    [SerializeField] ParticleSystem muzzleFlash;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            PlayMuzzleFlash();
            PerformRaycast();
        }
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void PerformRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(firstPersonCam.transform.position, firstPersonCam.transform.forward, out hit, range))
        {
            EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
        }

    }
}
