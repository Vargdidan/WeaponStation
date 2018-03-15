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
    float backburnerForce = 1;
    float maxSpreadAngle = 1;
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
        foreach (var component in components)
        {
            component.OnGUI();
        }
        GUIStyle textStyle = new GUIStyle();
        textStyle.fontSize = 15;
        GUI.Label(new Rect(Screen.width / 2 - 30, Screen.height - 45, 30, 30), "Initial force", textStyle);
        initialForce = GUI.HorizontalSlider(new Rect(Screen.width/2 - 100, Screen.height - 25, 200, 200), initialForce, 0, 30);
        GUI.Label(new Rect(Screen.width / 2 - 10, Screen.height - 15, 30, 30), initialForce.ToString("F1"), textStyle);

        GUI.Label(new Rect(Screen.width - 30, Screen.height - 180, 30, 30), "B\na\nc\nk\nb\nu\nr\nn", textStyle);
        backburnerForce = GUI.VerticalSlider(new Rect(Screen.width - 15, Screen.height - 215, 200, 200), backburnerForce, 0, 2);
        GUI.Label(new Rect(Screen.width - 25, Screen.height - 15, 30, 30), backburnerForce.ToString("F1"), textStyle);

        GUI.Label(new Rect(20, Screen.height - 150, 30, 30), "S\np\nr\ne\na\nd", textStyle);
        maxSpreadAngle = GUI.VerticalSlider(new Rect(5, Screen.height - 215, 200, 200), maxSpreadAngle, 0, 15);
        GUI.Label(new Rect(5, Screen.height -15, 30, 30), maxSpreadAngle.ToString("F1"), textStyle);
    }

    public IEnumerator FireProjectile()
    {
        while (true)
        {
            projectile = Instantiate(Resources.Load("Projectile"), projectileOrigin.transform.position, projectileOrigin.transform.rotation) as GameObject;
            projectile.GetComponent<Rigidbody>().velocity = initialForce * GetStartAngle();
            projectile.GetComponent<ProjectileScript>().SetBackburnerForce(backburnerForce);
            yield return new WaitForSeconds(2f);
        }
    }

    Vector3 GetStartAngle()
    {
        Quaternion fireRotation = Quaternion.LookRotation(projectileOrigin.transform.forward);
        //Calculate a spread on the start angle so that impact point varies a bit from projectile to projectile
        fireRotation = Quaternion.RotateTowards(fireRotation, Random.rotation, Random.Range(0.0f, maxSpreadAngle));
        return fireRotation * projectileOrigin.transform.forward;
    }
}
