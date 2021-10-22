using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Shake() {

        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
