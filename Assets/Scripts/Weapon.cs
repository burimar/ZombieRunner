using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera firstPersonCam = default;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 3;
    [SerializeField] ParticleSystem muzzleFlash = default;
    [SerializeField] GameObject hitEffect = default;
    [SerializeField] Ammo ammoSlot = default;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (ammoSlot.HasAmmoLeft())
        {
            ammoSlot.ReduceAmmo();
            PlayMuzzleFlash();
            PerformRaycast();
        }
        else
        {
            Debug.Log("No more ammo");
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
        GameObject hitEffect = Instantiate(this.hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(hitEffect, 0.1f);
    }
}
