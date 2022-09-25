using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;

    Vector3 playerPosition = Vector3.zero;
    Vector3 direction = Vector3.right;
    Vector3 velocity = Vector3.zero;

    float totalCamHeight;
    float totalCamWidth;

    // Start is called before the first frame update
    void Start()
    {
        // makes sure vehicle starts whereever it was placed, and not at 0, 0, 0
        playerPosition = transform.position;

        // store camera dimensions
        totalCamHeight = Camera.main.orthographicSize;
        totalCamWidth = totalCamHeight * Camera.main.aspect;
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
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // get the value from the context
        direction = context.ReadValue<Vector2>();

        // prevents snapping back to default orientatino
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.back, direction);
        }
    }
}