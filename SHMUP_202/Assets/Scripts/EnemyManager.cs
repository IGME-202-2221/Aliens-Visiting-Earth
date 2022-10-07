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


    // Start is called before the first frame update
    void Start()
    {
        // store camera dimensions
        totalCamHeight = Camera.main.orthographicSize;
        totalCamWidth = totalCamHeight * Camera.main.aspect;

        spawnedEnemies.Add(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {

    }


    public GameObject SpawnEnemy()
    {
        GameObject newEnemy;

        newEnemy = Instantiate(enemyPrefabs[0], RandomSpawnPoint(), Quaternion.identity);
        
        return newEnemy;
    }

    public Vector3 RandomSpawnPoint()
    {
        // determine where enemy spawns
        Vector3 spawnPoint = new Vector3(totalCamWidth - 1f, Random.Range(-totalCamHeight, totalCamHeight), 0);

        return spawnPoint;
    }
}
