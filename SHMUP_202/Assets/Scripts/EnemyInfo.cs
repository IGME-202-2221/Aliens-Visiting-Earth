using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;

    [SerializeField]
    int health = 100;

    [SerializeField]
    int enemyType;

    public int Health { get { return health; } set { health = value; } }

    Vector3 tempPosition;

    Vector3 direction = new Vector3(0, -1, 0);
    public Vector3 Direction { get { return direction; } set { direction = value; } }

    Vector3 velocity = Vector3.zero;

    float totalCamHeight;
    float totalCamWidth;

    bool collided = false;
    public bool Collided { get { return collided; } set { collided = value; } }
    float flashTime;
    
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
        // do different movement based on this object's enemy type
        // (1: type 1, 2: type 2)
        switch (enemyType)
        {
            // enemy type 1 just moves vertically
            case 1:
                // update enemy position
                velocity = direction * speed * Time.deltaTime;

                // validate collision
                tempPosition = transform.position + velocity;
                HandleBoundsCollisions();
                transform.position = tempPosition;
                break;

            case 2:
                // movement code for enemy type 2
                break;


            default:
                break;
        
        }

        // check collision
        // if so, flash red for a short amount of time
        if (collided)
        {
            if (flashTime < .1f)
            {
                flashTime += Time.deltaTime;
                GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                collided = false;
            }
        }
        else
        {
            flashTime = 0;
            GetComponent<SpriteRenderer>().color = Color.white;
        }

    }

    // method that has enemies bounds off walls
    public void HandleBoundsCollisions()
    {
        // if enemy collides with a wall,
        // reverse direction
        if (GetComponent<SpriteInfo>().MinX < -totalCamWidth)
        {
            tempPosition.x = -totalCamWidth + 1;
            direction = -direction;
        }
        if (GetComponent<SpriteInfo>().MaxX > totalCamWidth)
        {
            tempPosition.x = totalCamWidth - 1;
            direction = -direction;
        }
        if (GetComponent<SpriteInfo>().MinY < -totalCamHeight)
        {
            tempPosition.y = -totalCamHeight + 1;
            direction = -direction;
        }
        if (GetComponent<SpriteInfo>().MaxY > totalCamHeight)
        {
            tempPosition.y = totalCamHeight - 1;
            direction = -direction;
        }
    }

}
