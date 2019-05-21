using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GamePlace
{
    MainMenu,
    Pause, 
    Dino,
    Garden
}

public class GameState : MonoBehaviour
{
    public static GameState instance;

    public List<int> harvestedFlowers;

    private GameObject growingFlower;
    private GameObject photographers;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
            growingFlower = GameObject.Find("Flowers");
            photographers = GameObject.Find("Photographers");
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(harvestedFlowers.Count);
    }

    public void ChangeState(string currentState)
    {
        Debug.Log("Change state running");
        switch (currentState)
        { 
           case "Garden":
               SceneManager.LoadScene("Garden");
               if (growingFlower == null)
               {
                   growingFlower = GameObject.Find("Flowers");
               }
               else
               {
                   growingFlower.SetActive(true);
               }
               photographers.SetActive(false);
               break;
           case "Dino":
               if (growingFlower == null)
               {
                   growingFlower = GameObject.Find("Flowers");
               }    
                   growingFlower.SetActive(false);
               photographers.SetActive(true);
               SceneManager.LoadScene("Dino");
               break;
        }
    }

    public void addFlower()
    {
        harvestedFlowers.Add(1);
        //Debug.Log("ran addFlower");
    }

    public void removeFlower()
    {
        harvestedFlowers.Remove(1);
    }
    
    
}
