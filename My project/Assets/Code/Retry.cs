using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public PlayerMovement player;

    public void ResetTheGame()
    {
        SceneManager.LoadScene("Level 1");

        Debug.Log("Balls");
        player.currentHealth = 3;
        player.ActivateGameObjects();
    }
}
