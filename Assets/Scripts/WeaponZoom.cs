using UnityEngine;

public class WeaponZoom : MonoBehaviour
{

    [SerializeField] float zoomIn = 25;

    private Camera camera;
    private float zoomOriginal = 0f;


    void Start()
    {
        camera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            ToggleZoom();
        }
    }

    private void ToggleZoom()
    {
        if (zoomOriginal > 0f)
        {
            camera.fieldOfView = zoomOriginal;
            zoomOriginal = 0f;
        } else
        {
            zoomOriginal = camera.fieldOfView;
            camera.fieldOfView = zoomIn;
        }
    }

}
