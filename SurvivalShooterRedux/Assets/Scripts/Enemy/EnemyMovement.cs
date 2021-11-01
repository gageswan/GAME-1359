using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    GameObject[] players;
    List<Transform> playerTransforms = new List<Transform>();
    List<PlayerHealth> playerHealths = new List<PlayerHealth>();
    Transform playerTarget;
    Transform enemy;    
    GameObject playerT;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;
    float distance = Mathf.Infinity;


    void Awake ()
    {
        //enemy = transform.parent;
/*        if (enemy != null) {
            Debug.Log("Am Enemy!");
        }
        else {
            Debug.Log("Oh *%&^!");
        }*/
        players = GameObject.FindGameObjectsWithTag("Player");
/*         if (players != null) {
            Debug.Log("Found Players!");
        }
       else {
            Debug.Log("No Players!");
        }*/
        //playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
        foreach (GameObject player in players) {
            playerTransforms.Add(player.transform);
            //Debug.Log("Adding Players to List!");
        }
        foreach (GameObject player in players) {
            playerHealths.Add(player.GetComponent<PlayerHealth>());
        }
        /*        for (int i = 0; i < playerTransforms.Count; i++) {
                    Debug.Log(playerTransforms[i].position.y + " " +
                        playerTransforms[i].position.x + " " +
                        playerTransforms[i].position.z);
                }*/
    }

    void Update ()
    {
        //playerT = null;

        if (enemyHealth.currentHealth > 0){
            for (int i = 0; i < playerTransforms.Count; i++) {
                //if (playerHealths[i].currentHealth != 0) { 
                    Vector3 diff = playerTransforms[i].position - transform.position;
                    float currentDistance = diff.sqrMagnitude;
                    if (currentDistance < distance) {
                        playerTarget = playerTransforms[i];
                        distance = currentDistance;
                    }
                //}
            nav.SetDestination(playerTarget.position); 
            }
        }
        else{
            nav.enabled = false;
        }
    }
}
