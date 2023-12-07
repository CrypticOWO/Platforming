using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject hp1;
    public GameObject hp2;

    private void Awake()
    {
        // Ensure only one instance of the UIManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Add methods to reset UI elements as needed
    public void ResetUIElements()
    {
        hp1.SetActive(true);
        hp2.SetActive(true);
    }
}
