using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    // updateRotation is used to rotate the projectile mesh in the direction it is moving
    private bool updateRotation = true;

    void Update()
    {
        if (updateRotation)
        {
            Vector3 velocity = GetComponent<Rigidbody>().velocity;
            transform.rotation = Quaternion.LookRotation(velocity);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        updateRotation = false;
    }
}
