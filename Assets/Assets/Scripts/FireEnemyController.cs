using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemyController : MonoBehaviour {
    
    public float verticalSpeed;

    void Update()
    {
        transform.Translate(new Vector3(0, Time.deltaTime * -verticalSpeed, 0));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
