using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Binoculars : WeaponComponent
{
    float zoomLevel = 60.0f;
    float originalZoomLevel;
    float targetZoomLevel;
    Camera mainCamera;
    
    public override void Initialize () {
        base.Initialize();
        mainCamera = Camera.main;
        originalZoomLevel = mainCamera.fieldOfView;
        targetZoomLevel = originalZoomLevel;
    }

    public override void Update() {
        if (Input.GetKeyDown(KeyCode.B))
        {
            ToggleComponent();
        }

        if (targetZoomLevel != mainCamera.fieldOfView)
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, targetZoomLevel, 5.0f * Time.deltaTime);
        }
    }

    public override void ActivateComponent () {
        base.ActivateComponent();
        targetZoomLevel = zoomLevel;
    }

    public override void DeactivateComponent () {
        base.DeactivateComponent();
        targetZoomLevel = originalZoomLevel;
    }
}
