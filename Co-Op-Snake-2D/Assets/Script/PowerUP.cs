using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUP : MonoBehaviour
{
    public float multiplayer = 15.0f;
    public GameObject Player1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "snake 1" )
        {
            pickup();
        }
    }

    private void pickup()
    {
       //react
       //object desabaled
       Player1.transform.localScale*=multiplayer;
       //stop after sometime 
       Destroy(gameObject);
        Debug.Log("Yes Still it working");
    }
}
