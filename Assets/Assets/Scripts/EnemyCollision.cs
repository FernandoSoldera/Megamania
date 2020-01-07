using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {

    public GameObject wallEnemyLeft;
    public GameObject enemy;
    private GameController gameController;

    // Use this for initialization
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameController.enemies.Remove(collision.gameObject);
        Destroy(collision.gameObject);
        GameObject newEnemy = Instantiate(enemy, new Vector3(wallEnemyLeft.transform.position.x, collision.transform.position.y, 0), new Quaternion());
        newEnemy.name = collision.gameObject.name;
        gameController.enemies.Add(newEnemy);
    }
}
