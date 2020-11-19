using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera firstPersonCam;
    [SerializeField] float range = 100f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        Physics.Raycast(firstPersonCam.transform.position, firstPersonCam.transform.forward, out hit, range);
        Debug.Log("I hit: " + hit.transform.name);
    }
}
