using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HedgehogTeam.EasyTouch;

public class TapSceneChange : MonoBehaviour
{
    public GameObject gameManager;
    public GameState gameManagerScript;
    public string whereToGo;
    
    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameState>();
    }

    // Subscribe to events
    void OnEnable()
    {
        EasyTouch.On_SimpleTap += On_SimpleTap;
    }

    void OnDisable()
    {
        UnsubscribeEvent();
    }

    void OnDestroy()
    {
        UnsubscribeEvent();
    }

    void UnsubscribeEvent()
    {
        EasyTouch.On_SimpleTap -= On_SimpleTap;
    }

    // Simple tap
    private void On_SimpleTap(Gesture gesture)
    {
        
        // Verification that the action on the object
        if (gesture.pickedObject == gameObject)
        {
            gameManagerScript.ChangeState(whereToGo);

        }

    }
}
