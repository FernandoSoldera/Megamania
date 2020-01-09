using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float fireTime;
    private float timeCanFire;
    public float totalGameTime;
    public float timeRestart = 0;
    private bool isStarting = true;
    public GameObject playerLifeStartingAudio;

    public GameObject fire;
    public Image lifeBar;
    public Image lifeBarBackground;

    private GameController gameController;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        timeCanFire = 0;
        timeRestart = Time.time;
    }

    void Update()
    {
        if(Input.GetButton("F1"))
        {
            //reset
            isStarting = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetButton("F2"))
        {
            //quit
            Application.Quit();
        }
        if (!gameController.isGamePaused)
        {
            if (Input.GetButton("Fire1"))
            {
                if (Time.time > timeCanFire)
                {
                    Shoot();
                    timeCanFire = Time.time + fireTime;
                }
            }
            Movement();
            if (lifeBar.rectTransform.sizeDelta.x <= lifeBarBackground.rectTransform.sizeDelta.x)
            {
                if (isStarting)
                {
                    StartingLife();
                }
                else
                {
                    CountTime();
                }
            }
            else
            {
                //gameover
                gameController.isGamePaused = true;
                gameController.destroyEnemies();
                gameObject.transform.position = new Vector3(0, -0.92f, 0);
            }
        }
    }

    public void StartingLife()
    {
        lifeBar.rectTransform.sizeDelta = new Vector2(370f - ((Time.time - timeRestart) * 250), 20);
        if(lifeBar.rectTransform.sizeDelta.x <= 0)
        {
            isStarting = false;
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
        float realTime = Time.time - timeRestart;
        lifeBar.rectTransform.sizeDelta = new Vector2(realTime * 100/totalGameTime * 3.7f, 20);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("FireEnemy"))
        {
            Destroy(collision.gameObject);
            if (gameController.lifes.Count > 0)
            {
                StartCoroutine(gameController.PlayerDied(gameObject));
                isStarting = true;
            }
            else
            {
                //gameover
                gameController.isGamePaused = true;
                gameController.destroyEnemies();
                gameObject.transform.position = new Vector3(0, -0.92f, 0);
            }
        }
    }
}
