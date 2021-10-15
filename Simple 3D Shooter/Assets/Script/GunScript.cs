using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

    public PlatformGameManager pgm;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 50;

        Ray r = new Ray(transform.position, forward);

        ///Debug.DrawRay(transform.position, forward, Color.green);

        RaycastHit hit;

        if (Input.GetMouseButtonDown(0)) {
            if (pgm.playerAmmo > 0) {
                pgm.playerAmmo--;
                if (Physics.Raycast(r, out hit, 100f)) {
                    if (hit.collider.CompareTag("Hazard")) {
                        Destroy(hit.collider.gameObject);
                    }
                    if (hit.collider.CompareTag("Token")) {
                        Destroy(hit.collider.gameObject);
                        pgm.tokenCollection++;
                    }
                    ///Debug.Log("Hit " + hit.collider.gameObject.name, hit.collider.gameObject);
                }

            }
        }
    }
}
