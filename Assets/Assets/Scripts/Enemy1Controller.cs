using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy1Controller : MonoBehaviour {

    public float speed;
    private GameController gameController;

	// Use this for initialization
	void Start ()
    {
        gameController = FindObjectOfType<GameController>();
        gameController.scoreText = GameObject.FindWithTag("Score").GetComponent<Text>() as Text;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(!gameController.isGamePaused)
        {
            transform.Translate(new Vector3(Time.deltaTime * speed, 0, 0));
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Fire"))
        {
            gameController.GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
            gameController.deadEnemyPositions.Add(int.Parse(gameObject.name));
            gameController.enemies.Remove(gameObject);
            Destroy(gameObject);
            gameController.IncreaseScore(20);
        }
    }
}
