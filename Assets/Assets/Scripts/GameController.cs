using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject enemy;
    public GameObject wallLeft;
    private float positionInstantiateEnemyX;
    private float positionInstantiateEnemyY;
    public Text scoreText;
    private GameObject[] lifes = new GameObject[5];
    public GameObject life;
    private float life1positionX = -148.8f;
    private float life1positionY = -162.7f;
    public Canvas canvas;
    public GameObject fireEnemy;
    private float controlFires = 0;

    // Use this for initialization
    void Start () {

        //Instantiate the lifes
        for(int i=0; i<3; i++)
        {
            float position = life1positionX + (40 * i);
            lifes[i] = Instantiate(life, new Vector3(position, life1positionY, 0), new Quaternion(), canvas.transform);
            lifes[i].transform.rotation = Quaternion.Euler(0,0,-90);
            lifes[i].GetComponent<RectTransform>().localPosition = new Vector3(position, life1positionY, 0);        }

        //Instantiate the enemys
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
        VerifyEnemyFire();
	}

    //Function to increase the score with the parameter
    public void IncreaseScore(float score)
    {
        scoreText.text = (float.Parse(scoreText.text) + score).ToString();
    }

    //Function to verificate if enemys is already to shoot (choose a enemy ramdomly)
    private void VerifyEnemyFire()
    {
        if(controlFires < Time.time)
        {
            GameObject[] enemysList = GameObject.FindGameObjectsWithTag("Enemy1");
            int number = Random.Range(0, enemysList.Length-1);

            Debug.Log(number + " " + enemysList.Length);

            if (gameObject != null)
            {
                Instantiate(fireEnemy, new Vector3(enemysList[number].transform.position.x, enemysList[number].transform.position.y - 1, 0), new Quaternion());
            }
            controlFires+=2;
        }
    }
}
