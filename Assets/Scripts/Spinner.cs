using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float spinX = 0;
    [SerializeField] float spinY = 1;
    [SerializeField] float spinZ = 0;

    // Update is called once per frame
    void Update()
    {
        //each update adds one degree of rotation to each axis
        transform.Rotate(spinX,spinY,spinZ);
    }
}
