using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayingScore : MonoBehaviour
{
    public GameObject dinoScore;
    public GameObject dino;
    private GameObject growingFlower;
    
    public Text displayScore;
    private float happyFloat;
    private Vector3 photographerStart;
    
    
    // Start is called before the first frame update
    void Start()
    {
        growingFlower = GameObject.Find("Photographers"); //parent 
        dinoScore = GameObject.Find("ScoreText");
        displayScore = dinoScore.GetComponent<Text>();
        
        happyFloat = dino.GetComponent<NavMeshController>().happyDino;
        happyFloat = PlayerPrefs.GetFloat("Happy");
        displayScore.text = "Dino happiness level:  " + happyFloat;
        
        photographerStart = new Vector3(5f,1f,10.1f);
        
    }

    // Update is called once per frame
    public void UpdateText()
    {
        happyFloat = dino.GetComponent<NavMeshController>().happyDino;
        displayScore.text = "Dino happiness level:" + happyFloat;
    }

    public void SpawnPhotographer()
    {
        if (happyFloat > 10 && happyFloat < 20)
        {
            GameObject newPhotographer = Instantiate(Resources.Load<GameObject>("Prefabs/Photographer"), photographerStart, Quaternion.identity,  growingFlower.transform);
        }

        if (happyFloat > 25)
        {
            Vector3 newPhotographerPosition = new Vector3(photographerStart.x - photographerStart.x, photographerStart.y,
                photographerStart.z);
            GameObject newPhotographer = Instantiate(Resources.Load<GameObject>("Prefabs/Photographer"), newPhotographerPosition , Quaternion.identity,  growingFlower.transform);
        }
    }
}
