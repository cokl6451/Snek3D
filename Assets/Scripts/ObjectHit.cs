using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    //when a collision event takes place, do this
    private void OnCollisionEnter(Collision other) 
    {
        //change color of wall on collision with player and mark as hit
        if(other.gameObject.CompareTag("Player")){
            GetComponent<MeshRenderer>().material.color = Color.black;
            gameObject.tag = "Hit";
        }
    }
}
