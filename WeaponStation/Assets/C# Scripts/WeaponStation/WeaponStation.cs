using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStation : MonoBehaviour {
    List<WeaponComponent> components;
    GameObject turretBarrel;
    GameObject weaponStation;
    float barrelSpeed = 30;
    float stationSpeed = 45;

    // Use this for initialization
    void Start () {
        components = new List<WeaponComponent>();
        components.Add(new Binoculars());
        components.Add(new Overlay());

        foreach (var component in components)
        {
            component.Initialize();
        }

        turretBarrel = GameObject.Find("TurretOrigin");
        weaponStation = GameObject.Find("WeaponStation");
	}
	
	// Update is called once per frame
	void Update () {
        foreach (var component in components)
        {
            component.Update();
        }

        CheckInput();
    }

    void CheckInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            turretBarrel.transform.Rotate(Vector3.left, barrelSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            turretBarrel.transform.Rotate(Vector3.right, barrelSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            weaponStation.transform.Rotate(Vector3.down, stationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            weaponStation.transform.Rotate(Vector3.up, stationSpeed * Time.deltaTime);
        }
    }

    void OnGUI()
    {
        foreach (var component in components)
        {
            component.OnGUI();
        }
        GUI.HorizontalSlider(new Rect(Screen.width/2 - 100, Screen.height - 15, 200, 200), 30, 10, 70);
    }
}
