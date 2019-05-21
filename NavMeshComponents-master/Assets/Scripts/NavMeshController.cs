using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    public Vector3 destination = new Vector3(1, 0, 2);
    private Vector3 oldDest;
    
    //saving happiness score 
    public float happyDino; 

    private NavMeshAgent agent;

    //so that you can call update score
    public GameObject displayScore;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destination);

        oldDest = destination;

        happyDino = PlayerPrefs.GetFloat("Happy");

    }

    // Update is called once per frame
    void Update()
    {
        if (destination != oldDest)
        {
            agent.SetDestination(destination);
            oldDest = destination;
        }
        
        if (Input.GetMouseButtonDown(0)) //Was the mouse clicked?
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction, Color.green);
         
            RaycastHit raycastHit = new RaycastHit();

            if (Physics.Raycast(ray, out raycastHit)) //Raycast returns true if it hits something, and populates raycasthit with info about that hit
            {
                destination = raycastHit.point; //set the destination to the location that was clicked on
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Flower") == true)
        {
            Destroy(other.gameObject);
            Debug.Log("I hit a flower");
            //Dino Care goes up instantiate a little heart
            happyDino++;
            displayScore.GetComponent<DisplayingScore>().UpdateText();
            PlayerPrefs.SetFloat("Happy",happyDino);
            PlayerPrefs.Save();
        }
        
    }

    

    private void OnMouseDown() //this is if the mouse collids with the Dino 
    {
        Debug.Log("MouseDown Called");
        
    }
}
