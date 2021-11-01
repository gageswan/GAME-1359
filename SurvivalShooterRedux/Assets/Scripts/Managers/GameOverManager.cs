using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameOverManager : MonoBehaviour
{
    //public PlayerHealth playerHealth;
    GameObject[] players;
    List<PlayerHealth> playerHealths = new List<PlayerHealth>();
    public float restartDelay = 5f;
    public int playersDead = 0;
    public int playersActive = 1;


    Animator anim;
	float restartTimer;


    void Awake()
    {
        anim = GetComponent<Animator>();

        players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in players) {
            playerHealths.Add(player.GetComponent<PlayerHealth>());
        }

    }


    void Update() {
        if (playersDead >= playersActive) {
            GameOver();
        }
/* 
        if (playersMax < playerHealths.Count) {
            playersMax = playerHealths.Count;
            Debug.Log(playersMax);
        }
        for (int i = 0; i < playerHealths.Count; i++)
        {
            if(playerHealths[i].currentHealth <= 0) {
                playersDead++;
                Debug.Log("Player Dead: "+ i);
                playerHealths.RemoveAt(i);
                Debug.Log(playerHealths.Count);

                if (playerHealths.Count == 0) {
                    anim.SetTrigger("GameOver");

                    restartTimer += Time.deltaTime;

                    if (restartTimer >= restartDelay) {
                        Application.LoadLevel(Application.loadedLevel);
                    }
                }
            }
        }*/
    }

    void GameOver() {
        anim.SetTrigger("GameOver");

        restartTimer += Time.deltaTime;

        if (restartTimer >= restartDelay) {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

}
