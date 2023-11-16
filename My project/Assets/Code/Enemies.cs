using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    //Variables
    Health damage;

    public GameObject hitPoints;

    public float speed;

    public bool left = true;

    // Start is called before the first frame update
    void Start()
    {
        left = true;
        damage = hitPoints.GetComponent<Health>();
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
            damage.TakeDamage(1);
        }
        if (coll.tag == "Wall" && left == true)
        {
            Debug.Log("hit");
            left = false;
        }
        else if (coll.tag == "Wall" && left == false)
        {
            Debug.Log("hit");
            left = true;
        }
    }
}
