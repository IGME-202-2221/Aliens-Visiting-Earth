using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fire : MonoBehaviour
{
    // get a reference to which prefab to spawn
    [SerializeField]
    GameObject bullet;

    [SerializeField]
    float fireCooldown = 0.1f;

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
    }

    
    // call SpawnBullet based on player input
    public void OnFire(InputAction.CallbackContext context)
    {
        // pevent player from firing too quickly
        if (timeSinceLastFire >= fireCooldown)
        {
            SpawnBullet();

            timeSinceLastFire = 0f;
        }
    }

    public void SpawnBullet()
    {
        // instantiate a new bullet and set its initial spawn location based on player position
        Vector3 spawnPoint = transform.position;
        GameObject newBullet = Instantiate(bullet, spawnPoint, Quaternion.identity);
    }


}
