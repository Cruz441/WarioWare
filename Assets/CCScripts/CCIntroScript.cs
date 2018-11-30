using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCIntroScript : MonoBehaviour {

    public Text introText;

    void Start()
    {
        introText.text = "Catch!";
        Destroy(introText, 2);        
    }
}
