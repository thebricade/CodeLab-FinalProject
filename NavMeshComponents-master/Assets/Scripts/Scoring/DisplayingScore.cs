using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayingScore : MonoBehaviour
{
    public GameObject dinoScore;
    public GameObject dino; 
    public Text displayScore;
    private float happyFloat;
    
    
    // Start is called before the first frame update
    void Start()
    {
        dinoScore = GameObject.Find("ScoreText");
        displayScore = dinoScore.GetComponent<Text>();
        
        happyFloat = dino.GetComponent<NavMeshController>().happyDino;
        happyFloat = PlayerPrefs.GetFloat("Happy");
        displayScore.text = "This is how happy your dino is " + happyFloat;
    }

    // Update is called once per frame
    public void UpdateText()
    {
        happyFloat = dino.GetComponent<NavMeshController>().happyDino;
        displayScore.text = "This is how happy your dino is " + happyFloat;
    }
}
