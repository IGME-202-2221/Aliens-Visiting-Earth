using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    // get a reference to which prefab to spawn
    [SerializeField]
    GameObject bullet;

    [SerializeField]
    float fireCooldown = 1.5f;

    private float timeSinceLastFire;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastFire = fireCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        // increment time since the player last fired
        timeSinceLastFire += Time.deltaTime;

        FireEnemyBullet();
    }

    public void FireEnemyBullet()
    {
        // pevent enemy from firing too quickly
        if (timeSinceLastFire >= fireCooldown)
        {
            SpawnBullet();

            timeSinceLastFire = 0f;
        }
    }

    public GameObject SpawnBullet()
    {
        // instantiate a new bullet and set its initial spawn location based on player position
        Vector3 spawnPoint = transform.position;
        GameObject newBullet = Instantiate(bullet, spawnPoint, Quaternion.identity);

        return newBullet;
    }
}
