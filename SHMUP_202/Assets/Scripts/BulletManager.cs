using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    // this script will handle movement of bullets
    // check for collisions/out of bounds
    // and destroying bullets accordingly

    [SerializeField]
    GameObject player;

    [SerializeField]
    float speed = 5f;

    [SerializeField]
    int damage = 10;

    Vector3 direction = new Vector3(1, 0, 0);
    Vector3 velocity = Vector3.zero;

    float totalCamHeight;
    float totalCamWidth;
    
    List<GameObject> enemyList;

    GameObject enemyManager;



    // Start is called before the first frame update
    void Start()
    {
        // search for enemy manager object and retrieve that one for reference
        enemyManager = GameObject.Find("EnemyManager");

        // store camera dimensions
        totalCamHeight = Camera.main.orthographicSize;
        totalCamWidth = totalCamHeight * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        // move bullet
        velocity = direction * speed * Time.deltaTime;

        // store new position for validation
        Vector3 newPosition = transform.position + velocity;
        // draw the new (validated) position
        transform.position = newPosition;

        // check for coillision with each enemy
        // get reference to list of spawned enemies
        enemyList = enemyManager.GetComponent<EnemyManager>().SpawnedEnemies;

        for (int i = 0; i < enemyList.Count; i++)
        {
            if (AABBCollision(gameObject, enemyList[i]))
            {
                // indicate a collision occured
                enemyList[i].GetComponent<EnemyInfo>().Collided = true;

                DestroyBullet(gameObject);
            }
        }

        // check for out of bounds
        // if out of bounds, terminate bullet
        if (transform.position.x > totalCamWidth)
        {
            DestroyBullet(gameObject);
        }
        if (transform.position.x < -totalCamWidth)
        {
            DestroyBullet(gameObject);
        }
        if (transform.position.y > totalCamHeight)
        {
            DestroyBullet(gameObject);
        }
        if (transform.position.y < -totalCamHeight)
        {
            DestroyBullet(gameObject);
        }
    }

    // checks AABB collision with 2 game objects
    public bool AABBCollision(GameObject bullet, GameObject enemy)
    {
        if ((bullet.GetComponent<SpriteInfo>().MinX < enemy.GetComponent<SpriteInfo>().MaxX) &&
            (bullet.GetComponent<SpriteInfo>().MaxX > enemy.GetComponent<SpriteInfo>().MinX) &&
            (bullet.GetComponent<SpriteInfo>().MaxY > enemy.GetComponent<SpriteInfo>().MinY) &&
            (bullet.GetComponent<SpriteInfo>().MinY < enemy.GetComponent<SpriteInfo>().MaxY))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    /// <summary>
    /// destroy's bullet object and removes it from the list of active bullets
    /// </summary>
    /// <param name="bullet">bullet to destroy</param>
    public void DestroyBullet(GameObject bullet)
    {
        // search list of bullets for the bullet to remove
        //for (int i = 0; i < player.GetComponent<Fire>().Bullets.Count; i++)
        //{
        //    if (player.GetComponent<Fire>().Bullets[i].Equals(bullet))
        //    {
        //        player.GetComponent<Fire>().Bullets.Remove(bullet);
        //    }
        //}

        Destroy(bullet);
    }
}
