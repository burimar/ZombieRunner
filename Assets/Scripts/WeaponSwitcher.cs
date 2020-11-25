using System;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;

    private int nbrOfWeapons;

    void Start()
    {
        nbrOfWeapons = transform.childCount;
        SetActiveWeapon();
    }

    void Update()
    {
        int previousWeapon = currentWeapon;
        
        ProcessKeyInput();
        ProcessMouseWheel();

        if (currentWeapon != previousWeapon) SetActiveWeapon();
    }

    private void ProcessMouseWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            currentWeapon = ((currentWeapon - 1) + nbrOfWeapons) % nbrOfWeapons;
        } else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            currentWeapon = (currentWeapon + 1) % nbrOfWeapons;
        }
    }

    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) currentWeapon = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2)) currentWeapon = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3)) currentWeapon = 2;
    }

    private void SetActiveWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(i == currentWeapon);
            i++;
        }
    }
}