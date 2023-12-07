using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    public float speed;     // Control speed of movement
    float move;             // Control direction of movement

    public float jump;      // Control speed of the jump
    bool isGrounded;        // Track if the player is grounded

    Rigidbody2D rb;         // Store the rigidbody of an object

    // Variables for health
    public int maxHealth;
    public int currentHealth;

    public GameObject hp1;
    public GameObject hp2;

    public int targetSceneBuildIndex = 1;

    public static PlayerMovement instance;

    void Awake()
    {
    // Check if the current scene is the target scene
        if (IsInTargetScene())
        {
            hp1.SetActive(true);
            hp2.SetActive(true);
            maxHealth = 3;
            ResetPlayerHealth();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        jump = 400f;
        rb = GetComponent<Rigidbody2D>();      // Get the rigidbody of the object
        //maxHealth = 3;
        LoadPlayerHealth();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");                            // When any of the horizontal keys are pressed
        rb.velocity = new Vector2(speed * move, rb.velocity.y);        // Change the direction of the object

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            isGrounded = false;
        }
        if (transform.position.y < -7)
        {
            TakeDamage();
            TakeDamage();
            TakeDamage();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (other.gameObject.CompareTag("Respawn"))
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        currentHealth -= 1;
        PlayerPrefs.SetInt("Health", currentHealth);
        PlayerPrefs.Save();

        if (currentHealth == 2)
        {
            hp1.SetActive(false);
        }
        else if (currentHealth == 1)
        {
            hp2.SetActive(false);
        }
        if (currentHealth == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void LoadPlayerHealth()
    {
        // Load the player's health from PlayerPrefs, default to max health if not found
        currentHealth = PlayerPrefs.GetInt("Health", maxHealth);
    }

    bool IsInTargetScene()
    {
        // Get the current scene's build index
        int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;

        // Check if the current scene's build index matches the target scene build index
        return currentSceneBuildIndex == targetSceneBuildIndex;
    }

    public void ResetPlayerHealth()
    {
        currentHealth = maxHealth; // Reset to the maximum health value
        PlayerPrefs.SetInt("Health", currentHealth);
        PlayerPrefs.Save();
    }


}
