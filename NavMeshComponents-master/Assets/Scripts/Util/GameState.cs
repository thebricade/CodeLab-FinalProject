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
               break;
           
        }
    }

    public void addFlower()
    {
        harvestedFlowers.Add(1);
        //Debug.Log("ran addFlower");
    }
}
