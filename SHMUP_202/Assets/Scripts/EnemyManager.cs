using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // stores the enemy prefabs to choose from
    [SerializeField]
    List<GameObject> enemyPrefabs = new List<GameObject>();

    // store spawned enemies
    public List<GameObject> spawnedEnemies = new List<GameObject>();
    public List<GameObject> SpawnedEnemies { get { return spawnedEnemies; } }

    float totalCamHeight;
    float totalCamWidth;

    // reference to player on the screen
    GameObject player;
    public GameObject Player { get { return player; } }

    // time variables related to spawning as game progresses
    // time since last spawn
    float currentElapsedTime;
    // time in between spawns
    public float timeBetweenSpawn1 = 2.0f;  // for enemy type 1
    float totalElapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");

        // store camera dimensions
        totalCamHeight = Camera.main.orthographicSize;
        totalCamWidth = totalCamHeight * Camera.main.aspect;

        // spawn an enemy upon start
        spawnedEnemies.Add(SpawnEnemyBasic());

        totalElapsedTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // increment totalElapsedTime each frame to store how long the game has been running
        totalElapsedTime += Time.deltaTime;
        currentElapsedTime += Time.deltaTime;

        ContinuousSpawnBasic();

        // depending on how much total time has based,
        // slowly decrement the amount of time in between spawns to increase challenge
        if (totalElapsedTime < 10f)
        {
            timeBetweenSpawn1 = 2f;
        }
        else if (totalElapsedTime < 20f)
        {
            timeBetweenSpawn1 = 1.5f;
        }
        else if (totalElapsedTime < 60f)
        {
            timeBetweenSpawn1 = 1f;
        }
        else
        {
            timeBetweenSpawn1 = 0.5f;
        }
    }

    // spawn an enemy of type basic
    public GameObject SpawnEnemyBasic()
    {
        GameObject newEnemy;

        newEnemy = Instantiate(enemyPrefabs[0], RandomSpawnPoint(), Quaternion.identity);
        // pass a referene to player on screen
        newEnemy.GetComponent<EnemyFire>().Player = player;
        
        return newEnemy;
    }

    public Vector3 RandomSpawnPoint()
    {
        // determine where enemy spawns
        Vector3 spawnPoint = new Vector3(totalCamWidth + 2f, Random.Range(-totalCamHeight, totalCamHeight), 0);

        return spawnPoint;
    }

    public void ContinuousSpawnBasic()
    {
        if (currentElapsedTime >= timeBetweenSpawn1)
        {
            // reset time
            currentElapsedTime = 0;

            // spawn enemy
            spawnedEnemies.Add(SpawnEnemyBasic());
        }
    }
}
