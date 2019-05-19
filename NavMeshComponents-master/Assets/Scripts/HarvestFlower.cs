using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestFlower : MonoBehaviour
{
    public GameObject gameManager;
    public GameState gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
       gameManagerScript = gameManager.GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Harvest Flower");
        gameManagerScript.addFlower();
        //gameManager.GetComponent<GameState>().addFlower();
        Destroy(gameObject);

    }
}
