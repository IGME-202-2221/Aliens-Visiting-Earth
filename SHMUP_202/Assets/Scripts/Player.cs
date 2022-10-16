using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    float speed = 10f;

    Vector3 playerPosition = Vector3.zero;
    Vector3 direction = Vector3.zero;
    Vector3 velocity = Vector3.zero;

    float totalCamHeight;
    float totalCamWidth;

    private bool hit = false;
    public bool Hit { get { return hit; }  set { hit = value; } }

    private int health = 100;
    public int Health { get { return health; } set { health = value; } }

    private int score;
    public int Score { get { return score; } set { score = value; } }

    float invicibilityTime;

    [SerializeField]
    GameObject enemyBullet;
    
    // Start is called before the first frame update
    void Start()
    {
        // makes sure vehicle starts whereever it was placed, and not at 0, 0, 0
        playerPosition = transform.position;

        // store camera dimensions
        totalCamHeight = Camera.main.orthographicSize;
        totalCamWidth = totalCamHeight * Camera.main.aspect;

        score = 0;

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // velocity is direcion * speed * deltaTime
        // this is a vector with a direction and magnitude
        velocity = direction * speed * Time.deltaTime;

        // increment position based on velocity
        playerPosition += velocity;

        // validate position so player stays on screen
        if (playerPosition.x > totalCamWidth)
        {
            playerPosition.x = totalCamWidth;
        }
        if (playerPosition.x < -totalCamWidth)
        {
            playerPosition.x = -totalCamWidth;
        }

        if (playerPosition.y > totalCamHeight)
        {
            playerPosition.y = totalCamHeight;
        }
        if (playerPosition.y < -totalCamHeight)
        {
            playerPosition.y = -totalCamHeight;
        }

        // draw the new (validated) position
        transform.position = playerPosition;

        // if the player is hit, deal damage
        if (hit)
        {
            // provide the player with i-frames
            if (invicibilityTime < .4f)
            {
                invicibilityTime += Time.deltaTime;
            }
            else
            {
                // decrement player health
                hit = false;
                health -= enemyBullet.GetComponent<EnemyBulletManager>().Damage;
            }
        }
        else
        {
            invicibilityTime = 0;
        }

        // if player dies, end the game
        if (health <= 0)
        {
            // end the game
            Time.timeScale = 0f;
        }
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // get the value from the context
        direction = context.ReadValue<Vector2>();
    }
}
