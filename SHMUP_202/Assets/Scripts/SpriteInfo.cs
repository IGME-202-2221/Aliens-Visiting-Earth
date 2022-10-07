using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInfo : MonoBehaviour
{
    // fields
    [SerializeField]
    SpriteRenderer sprite;

    // stores the min and max bounds
    public float MaxX { get { return sprite.bounds.max.x; } }
    public float MinX { get { return sprite.bounds.min.x; } }

    public float MaxY { get { return sprite.bounds.max.y; } }
    public float MinY { get { return sprite.bounds.min.y; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
