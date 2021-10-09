using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public PlatformGameManager pgm;
    
    Rigidbody rb;

    public float speed = 2.0f;
    public float jumpSpeed = 5.0f;


    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Ray r = new Ray(transform.position, Vector3.down);

        RaycastHit hit;

        //Movement XY
        {
            if (h > 0) {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (h < 0) {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (v > 0) {
                transform.position += Vector3.forward * speed * Time.deltaTime;
            }
            if (v < 0) {
                transform.position += Vector3.back * speed * Time.deltaTime;
            }
        }

        //Jump Validation
        if (Input.GetButtonDown("Jump")) {
            if (Physics.Raycast(r, out hit, 0.1f)) {
                if (hit.collider.CompareTag("Surface")) {
                    Jump(); }
            }
        }

        if (Input.GetMouseButtonDown(0)) {
            if (pgm.playerAmmo > 0) {
                pgm.playerAmmo--;
            }
        }
    }
    void Jump() {
        rb.velocity = new Vector3(
            rb.velocity.x,
            jumpSpeed,
            rb.velocity.y
            );
    }
} 
