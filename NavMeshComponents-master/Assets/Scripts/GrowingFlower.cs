using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingFlower : MonoBehaviour
{
    private Vector3 budSpawn;
    private Vector3 offsetBud;
    private GameObject growingFlower;
    
    // Start is called before the first frame update
    void Start()
    {
        offsetBud = new Vector3(0,.10f,0);
        growingFlower = GameObject.Find("Flowers");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction, Color.green);
         
        RaycastHit raycastHit = new RaycastHit();
        
        if (Physics.Raycast(ray, out raycastHit)) //Raycast returns true if it hits something, and populates raycasthit with info about that hit
        {
            budSpawn = raycastHit.point; //set the destination to the location that was clicked on
        }

        budSpawn += offsetBud;

        //GameObject newBud = Instantiate(Resources.Load<GameObject>("Prefabs/BudFlower"));
        //Instantiate it under a parent so we can save that parent moving between scenes 
        GameObject newBud = Instantiate(Resources.Load<GameObject>("Prefabs/BudFlower"), budSpawn, Quaternion.identity,  growingFlower.transform);
        //newBud.transform.position = budSpawn;
    }
}
