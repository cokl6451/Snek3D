using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Movement Variables
    //SerializeField makes it appear in the menu in Unity

    [SerializeField] float moveSpeed = 7.2f;

    // Start is called before the first frame update
    void Start()
    {                       //x,y,z
        transform.Translate(0,0,0);
        printInstructions();
    }

    // Update is called once per frame (dependent on computer hardware!!!!)
    void Update()
    {    
        movePlayer();
    }


    //Methods
    //================================================================================
    void printInstructions()
    {
        //print how to play to the console
        Debug.Log("Pretty fucking clear how to play the game.");
        Debug.Log("Go hit a wall to test my shit out!");
    }

    void movePlayer()
    {
        //multiply by Time.deltaTime to make movement indenpendent from frame rate (it will result in xValue = 1)
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(xValue, 0, zValue);
    }

}
