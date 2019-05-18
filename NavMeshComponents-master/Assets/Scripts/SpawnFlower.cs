using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlower : MonoBehaviour
{
    private Vector3 flowerSpawn;

    public Vector3 offsetFlower;
    // Start is called before the first frame update
    void Start()
    {
        offsetFlower = new Vector3(0,.10f,0);
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
            flowerSpawn = raycastHit.point; //set the destination to the location that was clicked on
        }

        flowerSpawn += offsetFlower;
        
        GameObject newFlower = Instantiate(Resources.Load<GameObject>("Prefabs/pinkFlower"));
        newFlower.transform.position = flowerSpawn;

    }
}
