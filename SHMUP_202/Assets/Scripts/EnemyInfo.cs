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
    Vector3 enemyPosition;
    Vector3 direction = new Vector3(0, -1, 0);
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
        // do different movement based on this object's enemy type
        // (1: type 1, 2: type 2)
        switch (enemyType)
        {
            // enemy type 1 just moves vertically
            case 1:
                // update enemy position
                velocity = direction * speed * Time.deltaTime;

                // check y bounds
                enemyPosition = transform.position + velocity;
                if (enemyPosition.y > totalCamHeight + 1)
                {
                    enemyPosition.y = -totalCamHeight;
                }
                if (enemyPosition.y < -totalCamHeight - 1)
                {
                    enemyPosition.y = totalCamHeight;
                }
                transform.position =enemyPosition;
                break;

            case 2:
                // movement code for enemy type 2
                break;


            default:
                break;
        
        }


        

    }
}
