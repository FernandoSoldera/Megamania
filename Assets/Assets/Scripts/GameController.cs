using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject enemy;
    public GameObject wallLeft;
    private float positionInstantiateEnemyX;
    private float positionInstantiateEnemyY;

    // Use this for initialization
    void Start () {
        for (int i=0; i < 15; i++)
        {
            if(i % 2 == 1)
            {
                positionInstantiateEnemyY = 1.5F;
            }
            else
            {
                positionInstantiateEnemyY = 0.0F;
            }
            Instantiate(enemy, new Vector2(wallLeft.transform.position.x + positionInstantiateEnemyX, 3.5F + positionInstantiateEnemyY), new Quaternion());
            positionInstantiateEnemyX += -1.5F;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
