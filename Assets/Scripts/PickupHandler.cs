using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHandler : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        PickupItem pickupItem = collision.transform.GetComponent<PickupItem>();
        if (pickupItem != null)
        {
            HandlePickup(collision.transform, pickupItem);
        }
    }

    private void HandlePickup(Transform transform, PickupItem pickupItem)
    {
        Destroy(transform.gameObject);
    }

}
