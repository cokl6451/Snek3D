using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTail : MonoBehaviour
{
    public GameObject tailPrefab;
    public float tailDistance = 1.0f;
    private List<Transform> tail;

    private Vector3 lastTailPosition;

    void Start()
    {
        tail = new List<Transform>();
        lastTailPosition = transform.position;
    }

    void Update()
    {
        if (tail.Count > 0)
        {
            if (Vector3.Distance(lastTailPosition, transform.position) > tailDistance)
            {
                // Move the last tail part to the new position
                Transform lastTailPart = tail[tail.Count - 1];
                lastTailPosition = lastTailPart.position;
                lastTailPart.position = transform.position;

                // Update the tail list
                tail.RemoveAt(tail.Count - 1);
                tail.Insert(0, lastTailPart);
            }
        }
        else
        {
            lastTailPosition = transform.position;
        }
    }

    public void GrowTail()
    {
        GameObject newTail = Instantiate(tailPrefab, lastTailPosition, Quaternion.identity);
        tail.Add(newTail.transform);
    }
}
