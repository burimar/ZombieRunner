using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera firstPersonCam = default;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 20;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] ParticleSystem muzzleFlash = default;
    [SerializeField] GameObject hitEffect = default;
    [SerializeField] Ammo ammoSlot = default;
    [SerializeField] AmmoType ammoType = default;

    private bool canShoot = true;

    void OnEnable()
    {
        canShoot = true;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.HasAmmoLeft(ammoType))
        {
            ammoSlot.ReduceAmmo(ammoType);
            PlayMuzzleFlash();
            PerformRaycast();
            yield return new WaitForSeconds(timeBetweenShots);
        }
        else
        {
            Debug.Log("No more ammo");
        }
        canShoot = true;
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
        GameObject hitEffect = Instantiate(this.hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(hitEffect, 0.1f);
    }
}
