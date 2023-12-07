using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public PlayerMovement player;
    public int currentHealth;

    public void ResetTheGame()
    {
        SceneManager.LoadScene("Level 1");

        Debug.Log("Balls");
        currentHealth = PlayerPrefs.GetInt("Health", 3);
        PlayerMovement.instance.ResetPlayerHealth();
    }
}
