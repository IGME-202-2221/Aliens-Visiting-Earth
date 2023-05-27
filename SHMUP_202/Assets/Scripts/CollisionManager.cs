//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CollisionManager : MonoBehaviour
//{
//    [SerializeField]
//    GameObject enemyManager;

//    // get a reference to player to access Fire script and list of Bullets
//    [SerializeField]
//    GameObject player;

//    // get a reference to both the list of bullets and list of enemies
//    List<GameObject> enemyList;
//    List<GameObject> bulletList;

//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        // get reference to list of spawned enemies
//        enemyList = enemyManager.GetComponent<EnemyManager>().SpawnedEnemies;

//    }

//    // checks AABB collision with 2 game objects
//    public bool AABBCollision(GameObject bullet, GameObject enemy)
//    {
//        if ((bullet.GetComponent<SpriteInfo>().MinX < enemy.GetComponent<SpriteInfo>().MaxX) &&
//            (bullet.GetComponent<SpriteInfo>().MaxX > enemy.GetComponent<SpriteInfo>().MinX) &&
//            (bullet.GetComponent<SpriteInfo>().MaxY > enemy.GetComponent<SpriteInfo>().MinY) &&
//            (bullet.GetComponent<SpriteInfo>().MinY < enemy.GetComponent<SpriteInfo>().MaxY))
//        {
//            return true;
//        }
//        else
//        {
//            return false;
//        }
//    }
//}
