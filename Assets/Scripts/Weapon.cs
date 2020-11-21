using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera firstPersonCam;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 3;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] ParticleSystem hitEffect;

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
            ShowHitEffect(hit);
            EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
        }

    }

    private void ShowHitEffect(RaycastHit hit)
    {
        ParticleSystem hitEffect = Instantiate(this.hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        hitEffect.Play();
        Destroy(hitEffect, 0.1f);
    }
}
