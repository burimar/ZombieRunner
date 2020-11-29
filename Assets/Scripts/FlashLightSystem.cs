using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float intensityDecay = 0.1f;

    Light flashLight = default;

    void Start()
    {
        flashLight = GetComponent<Light>();
    }

    
    void Update()
    {
        DecreaseLightIntensity();
    }

    private void DecreaseLightIntensity()
    {
        if (flashLight.intensity > 0)
        {
            flashLight.intensity -= intensityDecay * Time.deltaTime;
        }
    }

}
