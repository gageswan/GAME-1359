using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulMovement : MonoBehaviour
{

    public GameObject player;
    GameObject ghoul;

    public float ghoulSpeed = .02F;

    private float startTime;

    private float distance;


    // Start is called before the first frame update
    void Start()
    {
        ghoul = this.gameObject;

        startTime = Time.time;

        distance = Vector3.Distance(ghoul.transform.position, player.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        float distCovered = (Time.time - startTime) * ghoulSpeed;

        //float fractionOfJourney = distCovered / distance;
        distance = Vector3.Distance(ghoul.transform.position, player.transform.position);
        //ghoul.transform.position = Vector3.Lerp(ghoul.transform.position, player.transform.position, fractionOfJourney);
        if (distance <= 15) {
            ghoul.transform.position = Vector3.MoveTowards(ghoul.transform.position, player.transform.position, ghoulSpeed);
        }
    }
}
