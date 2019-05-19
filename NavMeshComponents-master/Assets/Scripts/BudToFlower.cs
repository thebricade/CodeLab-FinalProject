﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BudToFlower : MonoBehaviour
{
    private Vector3 budPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("a bud has been planted");
        budPosition = gameObject.transform.position;
        StartCoroutine(GrowingFlower());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GrowingFlower()
    {
        //wait a few seconds and then grow this into a flower
        Debug.Log("how long till it grows?");
        yield return new WaitForSeconds(2);
        Debug.Log("it's growing!");
        GameObject newFlower = Instantiate(Resources.Load<GameObject>("Prefabs/pinkFlower"));
        newFlower.transform.position = budPosition;
        
        Destroy(gameObject);
    }
}