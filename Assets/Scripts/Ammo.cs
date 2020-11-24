using UnityEngine;

public class Ammo : MonoBehaviour
{

    [SerializeField] int ammoAmount = 10;

    public bool HasAmmoLeft()
    {
        return ammoAmount > 0;
    }

    public void ReduceAmmo()
    {
        ammoAmount--;
    }

}
