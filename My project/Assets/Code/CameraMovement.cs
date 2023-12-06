using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Variables
    public GameObject Player;
        private GameObject InstantPlayer;

    public GameObject UI;
        private GameObject instantUI;

    //public GameObject hp1;
        //private Transform instanthp1;
    //public GameObject hp2;
        //private Transform instanthp2;

    void Start()
    {
        InstantPlayer = Instantiate(Player, new Vector3(-6.5f, -3.5f, 0), Player.transform.rotation);

        instantUI = Instantiate(UI, new Vector3(0, 0, 0), UI.transform.rotation);

        //instanthp1 = Instantiate(hp1, new Vector3(-420, -205, 0), hp1.transform.rotation);
        //instanthp2 = Instantiate(hp2, new Vector3(-460, -205, 0), hp2.transform.rotation);

        int currentHealth = PlayerPrefs.GetInt("Health");
        if (currentHealth == 2)
        {
            //hp1.SetActive(false);
        }
        if (currentHealth == 1)
        {
            //hp2.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(InstantPlayer.transform.position.x, transform.position.y, -10);
    }
}
