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
    float speed;

    Vector3 bulletPosition = Vector3.zero;
    Vector3 direction = Vector3.zero;
    Vector3 velocity = Vector3.zero;

    private List<GameObject> bullets = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move all bullets in list based on their direction vector
        for (int i = 0; i < bullets.Count; i++)
        {
            
        }

        // check collisions for all bullets

        // if there are any collisions with enemies, damage objects and destroy bullets

        // check for bullets leaving screen bounds, and destroy accordingly
    }

    
    // call SpawnBullet based on player input
    public void OnFire(InputAction.CallbackContext context)
    {
        SpawnBullet();
    }

    public GameObject SpawnBullet()
    {
        // instantiate a new bullet and set its initial spawn location based on player position
        Vector3 spawnPoint = transform.position;
        GameObject newBullet = Instantiate(bullet, spawnPoint, Quaternion.identity);

        // add newBullet to a list of bullets
        bullets.Add(newBullet);

        return newBullet;
    }


}
