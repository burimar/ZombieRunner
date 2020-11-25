using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{

    [SerializeField] int currentWeapon = 0;

    void Start()
    {
        ActivateWeapon();
    }

    private void ActivateWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(i == currentWeapon);
            i++;
        }
    }
}