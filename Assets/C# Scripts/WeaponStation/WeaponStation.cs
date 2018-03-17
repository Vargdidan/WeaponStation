using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStation : MonoBehaviour {
    private Overlay hudOverlay;
    private List<WeaponComponent> components;
    private GameObject turretBarrel;
    private GameObject weaponStation;
    private GameObject projectileOrigin;
    private Transform bulletParent;
    private float barrelSpeed;
    private float stationSpeed;
    private bool isFireing;

    // Use this for initialization
    void Start () {
        hudOverlay = new Overlay();
        hudOverlay.Initialize();

        components = new List<WeaponComponent>();
        components.Add(new Binoculars());
        foreach (var component in components)
        {
            component.Initialize();
        }

        turretBarrel = GameObject.Find("TurretOrigin");
        weaponStation = GameObject.Find("WeaponStation");
        projectileOrigin = GameObject.Find("ProjectileOrigin");
        barrelSpeed = 30;
        stationSpeed = 45;
        isFireing = false;
    }
	
	// Update is called once per frame
	void Update () {
        CheckInput();

        foreach (var component in components)
        {
            component.Update();
        }
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void OnGUI()
    {
        hudOverlay.Draw();
    }

    private IEnumerator FireProjectile()
    {
        while (true)
        {
            GameObject projectile = Instantiate(Resources.Load("Projectile"), projectileOrigin.transform.position, GetStartAngle()) as GameObject;
            projectile.GetComponent<Rigidbody>().velocity = hudOverlay.GetInitialForce() * projectile.transform.forward;
            projectile.GetComponent<ProjectileScript>().SetBackburnerForce(hudOverlay.GetBackburnerForce());
            yield return new WaitForSeconds(2f);
        }
    }

    private Quaternion GetStartAngle()
    {
        Quaternion fireRotation = projectileOrigin.transform.rotation;
        //Calculate a spread on the start angle so that impact point varies a bit from projectile to projectile
        fireRotation = Quaternion.RotateTowards(fireRotation, Random.rotation, Random.Range(0.0f, hudOverlay.GetMaxSpreadAngle()));
        return fireRotation;
    }
}
