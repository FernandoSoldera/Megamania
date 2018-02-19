using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour {

    public float horizontalSpeed;
    public float verticalSpeed;
    
	void Update () {
        Movement();
    }

    private void Movement()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(new Vector3(Time.deltaTime * horizontalSpeed, Time.deltaTime * verticalSpeed, 0));
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(new Vector3(Time.deltaTime * -horizontalSpeed, Time.deltaTime * verticalSpeed, 0));
        }
        else
        {
            transform.Translate(new Vector3(0, Time.deltaTime * verticalSpeed, 0));
        }
    }
}
