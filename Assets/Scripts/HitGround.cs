using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitGround : MonoBehaviour
{
    //Define the object's body for collision
    Rigidbody Body;

    private void Start() 
    {
        Body = GetComponent<Rigidbody>();
    }

    //when a collision event takes place, do this
    private void OnCollisionEnter(Collision other) 
    {
        //switch the falling object to be kinematic once it hits the ground, this avoids the detection bug
        if(other.gameObject.CompareTag("Untagged")){
            Body.isKinematic = true;
        }
    }
}
