using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject enemy;

	// Use this for initialization
	void Start () {
        for (int i=0; i < 15; i++)
        {

        }
        Instantiate(enemy, new Vector2(1,1), new Quaternion());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
