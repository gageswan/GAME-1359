using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentHit : MonoBehaviour {

    ParticleSystem hitParticles;

    // Start is called before the first frame update
    void Start()
    {
        hitParticles = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Hit(Vector3 hitPoint) {
        hitParticles.transform.position = hitPoint;
        hitParticles.Play();
    }
}
