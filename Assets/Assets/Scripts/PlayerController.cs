using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public GameObject fire;
    public float fireTime;
    private float timeCanFire;

    void Start()
    {
        timeCanFire = 0;
    }

    void Update() {
        if (Input.GetButton("Fire1"))
        {
            if (Time.time > timeCanFire)
            {
                Shoot();
                timeCanFire = Time.time + fireTime;
            }
        }
        Movement();
    }

    private void Movement()
    {
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(new Vector3(Time.deltaTime * speed, 0, 0));
        }
        else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(new Vector3(Time.deltaTime * -speed, 0, 0));
        }
    }

    private void Shoot()
    {
        Instantiate(fire, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation);
    }
}
