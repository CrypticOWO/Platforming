using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    public float speed;     //Control speed of movement
    float move;             //Control direction of movement

    public float jump;      //Control speed of the jump

    public bool isJumping;

    Rigidbody2D rb;         //Store the rigidbody of an object

    public int maxHealth;
    public int currentHealth;

    public Transform startPos;
    public Transform currentPos;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        jump = 400f;
        rb = GetComponent<Rigidbody2D>();      //Get the rigidbody of the object

        maxHealth = 2;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");                            //When any of the horizontal keys are pressed
        rb.velocity = new Vector2(speed * move, rb.velocity.y);        //Change the direction of the object

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            isJumping = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }

        if (other.gameObject.CompareTag("Respawn"))
        {
            TakeDamage(1);
        }
    }

    void TakeDamage(int amount)
    {
        currentHealth -= amount;
        transform.position = new Vector2(startPos.position.x, startPos.position.y);

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
