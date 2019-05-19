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
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
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
               break;
           case "Dino":
               if (growingFlower == null)
               {
                   growingFlower = GameObject.Find("Flowers");
               }    
                   growingFlower.SetActive(false);
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
