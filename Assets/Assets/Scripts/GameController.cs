using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject enemy;
    public GameObject wallLeft;
    private float positionInstantiateEnemyX = -5;
    private float positionInstantiateEnemyY;
    public Text scoreText;
    public List<GameObject> lifes = new List<GameObject>();
    public List<GameObject> enemies = new List<GameObject>();
    public List<int> deadEnemyPositions = new List<int>();
    public GameObject life;
    private float life1positionX = -148.8f;
    private float life1positionY = -162.7f;
    public Canvas canvas;
    public GameObject fireEnemy;
    private float controlFires = 0;
    public GameObject playerDyingSound;
    public bool isGamePaused = false;
    public PlayerController playerController;
    public GameObject IncresingScoreAudio;
    public int level = 1;

    // Use this for initialization
    void Start ()
    {
        playerController = FindObjectOfType<PlayerController>();

        //Instantiate the lifes
        for (int i=0; i<1; i++)
        {
            float position = life1positionX + (40 * i);
            lifes.Add(Instantiate(life, new Vector3(position, life1positionY, 0), new Quaternion(), canvas.transform));
            lifes[i].transform.rotation = Quaternion.Euler(0, 0, -90);
            lifes[i].GetComponent<RectTransform>().localPosition = new Vector3(position, life1positionY, 0);        
        }

        //Instantiate the enemys
        for (int i=0; i < 1; i++)
        {
            if(i % 2 == 1)
            {
                positionInstantiateEnemyY = 1.5F;
            }
            else
            {
                positionInstantiateEnemyY = 0.0F;
            }
            GameObject newEnemy = Instantiate(enemy, new Vector2(wallLeft.transform.position.x + positionInstantiateEnemyX, 3.5F + positionInstantiateEnemyY), new Quaternion());
            newEnemy.name = i.ToString();
            enemies.Add(newEnemy);
            positionInstantiateEnemyX += -1.5F;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!isGamePaused)
        {
            VerifyEnemyFire();
        }
	}

    //Function to increase the score with the parameter
    public void IncreaseScore(float score)
    {
        scoreText.text = (float.Parse(scoreText.text) + score).ToString();
    }

    //Function to verificate if enemys is already to shoot (choose a enemy ramdomly)
    private void VerifyEnemyFire()
    {
        if (controlFires < Time.time)
        {
            GameObject[] enemysList = GameObject.FindGameObjectsWithTag("Enemy1");
            int number = Random.Range(0, enemysList.Length - 1);

            //Debug.Log(number + " " + enemysList.Length);
            //Criar mecanica para somente atirar os inimigos que estao visiveis

            if (gameObject != null && enemysList.Length > 0)
            {
                Instantiate(fireEnemy, new Vector3(enemysList[number].transform.position.x, enemysList[number].transform.position.y - 1, 0), new Quaternion());
            }
            controlFires += 0.5f;
        }
    }

    public IEnumerator PlayerDied(GameObject player)
    {
        playerDyingSound.GetComponent<AudioSource>().Play();
        isGamePaused = true;

        yield return new WaitForSeconds(2f);

        playerController.timeRestart = Time.time;
        playerController.lifeBar.rectTransform.sizeDelta = new Vector2(369, 20);
        player.transform.position = new Vector3(0, -0.92f, 0);

        isGamePaused = false;
        Destroy(lifes[lifes.Count - 1]);
        lifes.Remove(lifes[lifes.Count - 1]);

        destroyEnemies();

        positionInstantiateEnemyX = -5;
        //Instantiate the enemys
        for (int i = 0; i < 15; i++)
        {
            if (!deadEnemyPositions.Contains(i))
            {
                if (i % 2 == 1)
                {
                    positionInstantiateEnemyY = 1.5F;
                }
                else
                {
                    positionInstantiateEnemyY = 0.0F;
                }
                GameObject newEnemy = Instantiate(enemy, new Vector2(wallLeft.transform.position.x + positionInstantiateEnemyX, 3.5F + positionInstantiateEnemyY), new Quaternion());
                newEnemy.name = i.ToString();
                enemies.Add(newEnemy);
            }
            positionInstantiateEnemyX += -1.5F;
        }
        player.GetComponent<AudioSource>().Play();
    }

    public void destroyEnemies()
    {
        foreach (GameObject enemyToDestroy in enemies)
        {
            Destroy(enemyToDestroy);
        }
        enemies = new List<GameObject>();
    }

    public void FinishEnemies()
    {
        StartCoroutine(ChangeLevel());
    }

    public IEnumerator ChangeLevel()
    {
        playerController.isChangingLevel = true;
        IncresingScoreAudio.GetComponent<AudioSource>().Play();
        float timeRemaning = (playerController.totalGameTime - (Time.time - playerController.timeRestart)) / 30;
        playerController.totalGameTime = Time.time + timeRemaning;

        yield return new WaitForSeconds(timeRemaning);

        playerController.totalGameTime = 50f;

        IncresingScoreAudio.GetComponent<AudioSource>().Stop();
        level++;
    }
}
