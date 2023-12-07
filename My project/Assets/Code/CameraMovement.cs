using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Variables
    public GameObject player;
    private GameObject instantPlayer;

    public GameObject hp1;
    private GameObject instantHp1;

    public GameObject hp2;
    private GameObject instantHp2;

    void Awake()
    {
        instantPlayer = Instantiate(player, new Vector3(-6.5f, -3.5f, 0), player.transform.rotation);

        instantHp1 = Instantiate(hp1, new Vector3(0, 0, 0), hp1.transform.rotation);
        instantHp2 = Instantiate(hp2, new Vector3(0, 0, 0), hp2.transform.rotation);
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(instantPlayer.transform.position.x, transform.position.y, -10);
        instantHp1.transform.position = new Vector3(instantPlayer.transform.position.x - 6.75f, transform.position.y + 4 , 0);
        instantHp2.transform.position = new Vector3(instantPlayer.transform.position.x - 8.0f, transform.position.y + 4, 0);

        int currentHealth = PlayerPrefs.GetInt("Health");

        if (currentHealth == 2)
        {
            instantHp1.SetActive(false);
        }
        else if (currentHealth == 1)
        {
            instantHp2.SetActive(false);
        }
    }
}
