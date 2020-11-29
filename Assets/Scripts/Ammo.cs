using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots = default;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType type = default;
        public int amount = default;
    }

    public int GetCurrentAmmo(AmmoType ammoType) {
        return GetAmmoSlot(ammoType).amount;
    }

    public bool HasAmmoLeft(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).amount > 0;
    }

    internal void IncreaseAmmo(AmmoType ammoType, int ammoAmount)
    {
        GetAmmoSlot(ammoType).amount += ammoAmount;
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
