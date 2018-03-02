using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(Time.deltaTime * speed, 0, 0));
	}
}
