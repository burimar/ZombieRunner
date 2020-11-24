using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{

    [SerializeField] Camera fpsCamera;
    [SerializeField] RigidbodyFirstPersonController fpsController;
    [SerializeField] float zoomIn = 25;
    [SerializeField] float zoomInMouseSensitivity = 1;
    
    private float zoomOriginal = -1;
    private float mouseSensitivityOriginal = -1;

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            ToggleZoom();
        }
    }

    private void ToggleZoom()
    {
        if (zoomOriginal == -1)
        {
            ZoomIn();
        }
        else
        {
            ZoomOut();
        }
    }

    private void ZoomIn()
    {
        zoomOriginal = fpsCamera.fieldOfView;
        fpsCamera.fieldOfView = zoomIn;

        mouseSensitivityOriginal = fpsController.mouseLook.XSensitivity;
        fpsController.mouseLook.XSensitivity = zoomInMouseSensitivity;
        fpsController.mouseLook.YSensitivity = zoomInMouseSensitivity;
    }

    private void ZoomOut()
    {
        fpsCamera.fieldOfView = zoomOriginal;
        zoomOriginal = -1;

        fpsController.mouseLook.XSensitivity = mouseSensitivityOriginal;
        fpsController.mouseLook.YSensitivity = mouseSensitivityOriginal;
        mouseSensitivityOriginal = -1;
    }

}
