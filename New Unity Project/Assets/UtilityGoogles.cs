﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityGoogles : MonoBehaviour {
    List<GoogleComponent> components;

    // Use this for initialization
    void Start () {
        components = new List<GoogleComponent>();
        components.Add(new Binoculars());

        foreach (var com in components)
        {
            com.Initialize();
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (var com in components)
            {
                com.ActivateComponent();
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            foreach (var com in components)
            {
                com.DeactivateComponent();
            }
        }

        foreach (var com in components)
        {
            com.Update();
        }
    }
}
