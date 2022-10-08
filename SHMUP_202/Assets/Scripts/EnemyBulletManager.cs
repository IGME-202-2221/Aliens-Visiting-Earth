using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletManager : MonoBehaviour
{
    // this script handles the movement, etc. for enemy bullets only
    [SerializeField]
    float speed = 5f;

    [SerializeField]
    int damage = 10;
    public int Damage { get { return damage; } }

    [SerializeField]
    GameObject player;

    Vector3 direction = new Vector3(-1, 0, 0);
    Vector3 velocity = Vector3.zero;

    float totalCamHeight;
    float totalCamWidth;

    // Start is called before the first frame update
    void Start()
    {
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

        // check for collisions with player
        if (AABBCollision(gameObject, player))
        {
            // if there is a collision, set player's hit bool to true
            player.GetComponent<Player>().Hit = true;
            DestroyBullet(gameObject);
            Debug.Log("collision");
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
    public bool AABBCollision(GameObject bullet, GameObject player)
    {
        if ((bullet.GetComponent<SpriteInfo>().MinX < player.GetComponent<SpriteInfo>().MaxX) &&
            (bullet.GetComponent<SpriteInfo>().MaxX > player.GetComponent<SpriteInfo>().MinX) &&
            (bullet.GetComponent<SpriteInfo>().MaxY > player.GetComponent<SpriteInfo>().MinY) &&
            (bullet.GetComponent<SpriteInfo>().MinY < player.GetComponent<SpriteInfo>().MaxY))
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
        Destroy(bullet);
    }
}
