using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStation : MonoBehaviour {
    List<WeaponComponent> components;
    GameObject turretBarrel;
    GameObject weaponStation;
    float barrelSpeed = 5;
    float stationSpeed = 20;

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

        if (Input.GetKey(KeyCode.W))
        {
            float originalAngle = turretBarrel.transform.rotation.x;
            turretBarrel.transform.Rotate(Vector3.left, originalAngle + barrelSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            float originalAngle = turretBarrel.transform.rotation.x;
            turretBarrel.transform.Rotate(Vector3.right, originalAngle + barrelSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        { //TODO
            float originalAngle = weaponStation.transform.rotation.y;
            weaponStation.transform.Rotate(Vector3.down, originalAngle + stationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        { //TODO
            float originalAngle = weaponStation.transform.rotation.y;
            weaponStation.transform.Rotate(Vector3.up, originalAngle + stationSpeed * Time.deltaTime);
        }
    }

    void OnGUI()
    {
        foreach (var component in components)
        {
            component.OnGUI();
        }
    }
}
