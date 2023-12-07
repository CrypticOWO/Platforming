using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Variables
    public GameObject Player;
    private GameObject InstantPlayer;

    public GameObject hp1;
    private GameObject instanthp1;

    public GameObject hp2;
    private GameObject instanthp2;

    void Awake()
    {
        InstantPlayer = Instantiate(Player, new Vector3(-6.5f, -3.5f, 0), Player.transform.rotation);

        instanthp1 = Instantiate(hp1, new Vector3(-6.5f, 0f, 0), hp1.transform.rotation);
        instanthp2 = Instantiate(hp2, new Vector3(-4.5f, 0f, 0), hp2.transform.rotation);

        instanthp1.SetActive(true);
        hp2.SetActive(true);

        int currentHealth = PlayerPrefs.GetInt("Health");

        if (currentHealth == 2)
        {
            hp1.SetActive(false);
        }
        if (currentHealth == 1)
        {
            hp2.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(InstantPlayer.transform.position.x, transform.position.y, -10);
    }
}
