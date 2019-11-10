using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    public GameObject player;

    public GameObject EnemyPrefab;

    public float enemyLimit;
    float currentEnemies;

    public Text scoreText;

    public GameObject particlePrefab;

    int score;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

    }
    // Use this for initialization
    void Start () {
        //time to execute , rate to be called
        InvokeRepeating("SpawnEnemy", 0.0f, 2.5f);
        score = 0;
    }
	
	// increase score and show the message un canvas
    public void EnemyDown()
    {
        currentEnemies--;
        score++;
        if (scoreText!=null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    // spawn a new enemy
    void SpawnEnemy()
    {
        if (currentEnemies < enemyLimit)
        {
            Enemy newEnemy = Instantiate(EnemyPrefab,transform.position,Quaternion.identity).GetComponent<Enemy>();
            // set the direction of the enemy to a random direction
            newEnemy.ChangeDirection(new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)), 0f);
            currentEnemies++;
        }
    }

    // create and destroy some particles to simulate a explotion
    public void MiniExplotion(Vector3 position)
    {
        if (particlePrefab != null)
        {
            Destroy(Instantiate(particlePrefab, position, Quaternion.identity),5f);
        }
        
    }

}
