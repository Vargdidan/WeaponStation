using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStation : MonoBehaviour {
    List<WeaponComponent> components;

    // Use this for initialization
    void Start () {
        components = new List<WeaponComponent>();
        components.Add(new Binoculars());

        foreach (var component in components)
        {
            component.Initialize();
        }
	}
	
	// Update is called once per frame
	void Update () {
        foreach (var component in components)
        {
            component.Update();
        }
    }
}
