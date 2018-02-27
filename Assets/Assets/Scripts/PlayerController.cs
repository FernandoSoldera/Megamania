using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float fireTime;
    private float timeCanFire;
    public float totalGameTime;

    public GameObject fire;
    public Image lifeBar;
    public Image lifeBarBackground;

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
        if(lifeBar.rectTransform.sizeDelta.x < lifeBarBackground.rectTransform.sizeDelta.x)
        {
            CountTime();
        }
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

    private void CountTime()
    {
        lifeBar.rectTransform.sizeDelta = new Vector2(Time.time*100/totalGameTime * 3.7f, 20);
    }
}
