using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
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
        else
        {
            transform.position = new Vector2(transform.position.x + speed, transform.position.y);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            Debug.Log("Hit");
            Destroy(gameObject);
        }
        if (coll.tag == "Wall" && left == true)
        {
            left = false;
        }
        else if (coll.tag == "Wall" && left == false)
        {
            left = true;
        }
    }
}
