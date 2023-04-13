using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    MeshRenderer Renderer;
    Rigidbody Body;

    bool timePrinted = false;
    [SerializeField] float waitTime = 3;

    private void Start() 
    {
        //Make cube invisible at first
        Renderer = GetComponent<MeshRenderer>();
        Renderer.enabled = false;

        Body = GetComponent<Rigidbody>();
        Body.useGravity = false;
    }
    //we wanna drop a cube after three seconds
    private void Update() 
    {
        //when we hit 3 seconds, flip the bool
        if(Time.time >= waitTime && timePrinted == false){
            timePrinted = true;
            Body.useGravity = true;
            Renderer.enabled = true;
            
        }
        //else if(Time.time >= waitTime + 1 && makeKinematic == false){
        //     //needs to be kinematic for the collision detection for some reason
        //     Body.isKinematic = true;
        //     makeKinematic = true;
        // }
        
    }
}
