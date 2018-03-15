using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {
    // updateRotation is used to rotate the projectile mesh in the direction it is moving
    private bool updateRotation = true;
    private bool outOfBackburnerFuel = false;
    private float backburnerForce = 1.0f;
    private double lifeTime = 0;

    void Update()
    {
        //Apply backburner after a set amount of time
        lifeTime += Time.deltaTime;
        if (lifeTime >= 0.2 && !outOfBackburnerFuel)
        {
            GetComponent<Rigidbody>().velocity += backburnerForce * transform.forward;

            if (lifeTime >= 0.4)
            {
                outOfBackburnerFuel = true;
            }
        }

        //Rotate the object in the direction of the velocity
        if (updateRotation)
        {
            Vector3 velocity = GetComponent<Rigidbody>().velocity;
            transform.rotation = Quaternion.LookRotation(velocity);
        }

        //Destroy projectile after a set amount of time
        if (lifeTime >= 20)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        updateRotation = false;
    }

    public void SetBackburnerForce(float force)
    {
        backburnerForce = force;
    }

    //Used for debug
    //void OnGUI()
    //{
    //    GUI.Label(new Rect(Screen.width / 2, 30, 30, 30), lifeTime.ToString());
    //}
}
