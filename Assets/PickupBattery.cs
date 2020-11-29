using UnityEngine;

public class PickupBattery : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with " + collision.ToString());
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponentInChildren<FlashLightSystem>().ReloadBattery();
            Destroy(gameObject);
        }
    }

}
