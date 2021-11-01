using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{

    public GameObject player2;
    public GameObject camera;
    public Camera cam1;
    public Camera cam2;
    public GameOverManager gameOverManager;
    bool player2Active = false;



    void Awake()    {
        //gameOverManager = GetComponent<GameOverManager>();
        //cam1.rect = new Rect(0, 0, 1, 0.5f);
        cam2.rect = new Rect(0, 0, 1, 0.5f);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) {
            player2.SetActive(true);
            camera.SetActive(true);
            if (!player2Active) {
                cam1.rect = new Rect(0, 0.5f, 1, 0.5f);
                gameOverManager.playersActive++;
                player2Active = true;
                //Debug.Log("Players Active: " + gameOverManager.playersActive);
            }       
        }
    }
}
