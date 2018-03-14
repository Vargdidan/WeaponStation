using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStation : MonoBehaviour {
    List<WeaponComponent> components;
    GameObject turretBarrel;
    GameObject weaponStation;
    GameObject projectileOrigin;
    GameObject projectile;
    Transform bulletParent;
    float barrelSpeed = 30;
    float stationSpeed = 45;
    float initialForce = 10;
    bool isFireing = false;

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
        projectileOrigin = GameObject.Find("ProjectileOrigin");
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isFireing)
            {
                StartCoroutine(FireProjectile());
                isFireing = true;
            }
            else
            {
                StopAllCoroutines();
                isFireing = false;
            }
        }
    }

    void OnGUI()
    {
        foreach (var component in components)
        {
            component.OnGUI();
        }
        GUIStyle textStyle = new GUIStyle();
        textStyle.fontSize = 15;
        GUI.Label(new Rect(Screen.width / 2 - 30, Screen.height - 30, 30, 30), "Initial force", textStyle);
        initialForce = GUI.HorizontalSlider(new Rect(Screen.width/2 - 100, Screen.height - 15, 200, 200), initialForce, 0, 30);
    }

    public IEnumerator FireProjectile()
    {
        while (true)
        {
            projectile = Instantiate(Resources.Load("Projectile"), projectileOrigin.transform.position, projectileOrigin.transform.rotation) as GameObject;
            projectile.GetComponent<Rigidbody>().velocity = initialForce * projectileOrigin.transform.forward;

            yield return new WaitForSeconds(2f);
        }
    }
}
