using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnFlower : MonoBehaviour
{
    private Vector3 flowerSpawn;

    public Vector3 offsetFlower;
    
    //get the gameState so we can gather how many flowers you have harvested
    public GameObject gameManager;
    public GameState gameManagerScript; 
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameState>();
        offsetFlower = new Vector3(0,.10f,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (gameManagerScript.harvestedFlowers.Count > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction, Color.green);

            RaycastHit raycastHit = new RaycastHit();

            if (Physics.Raycast(ray, out raycastHit)
            ) //Raycast returns true if it hits something, and populates raycasthit with info about that hit
            {
                flowerSpawn = raycastHit.point; //set the destination to the location that was clicked on
            }

            flowerSpawn += offsetFlower;

            GameObject newFlower = Instantiate(Resources.Load<GameObject>("Prefabs/pinkFlower"));
            newFlower.transform.position = flowerSpawn;
            //remove a flower from the list
            gameManagerScript.removeFlower();
        }

    }
}
