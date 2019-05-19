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

   // private GamePlace currentState;
    
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
    
}
