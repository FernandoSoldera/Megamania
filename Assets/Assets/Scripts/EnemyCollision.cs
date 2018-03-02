using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {

    public GameObject wallEnemyLeft;
    public GameObject newEnemy;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Instantiate(newEnemy, new Vector3(wallEnemyLeft.transform.position.x, collision.transform.position.y, 0), new Quaternion());
    }
}
