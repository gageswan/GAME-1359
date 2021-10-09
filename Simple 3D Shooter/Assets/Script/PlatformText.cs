using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformText : MonoBehaviour
{

    public PlatformGameManager pgm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayGameText();
    }

    void DisplayGameText() {
       GetComponentInChildren<Text>().text = pgm.playerAmmo.ToString();
    }
}
