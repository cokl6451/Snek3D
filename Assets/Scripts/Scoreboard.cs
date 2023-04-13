using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    int hitCount = -1;
    
    private void OnCollisionEnter(Collision other) 
    {
        //increment how many times player has hit a wall
        if(other.gameObject.CompareTag("Hit"))
        {
            Debug.Log("Fuck");
        }else{
            hitCount++;
            Debug.Log("Walls Hit: " + hitCount);
        }
        
    }

}
