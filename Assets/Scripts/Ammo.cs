using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType type;
        public int amount;
    }

    public bool HasAmmoLeft(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).amount > 0;
    }

    public void ReduceAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).amount--;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.type == ammoType)
            {
                return slot;
            }
        }

        return null;
    }

}

public enum AmmoType
{
    Bullet, Shell, Rocket
}
