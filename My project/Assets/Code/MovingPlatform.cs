using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //Variables
    public float speed;

    public bool left = true;

    // Start is called before the first frame update
    void Start()
    {
        left = true;
        speed = 0.015f;
    }

    // Update is called once per frame
    void Update()
    {
        if (left)
        {
            transform.position = new Vector2(transform.position.x - speed, transform.position.y);
        }
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
