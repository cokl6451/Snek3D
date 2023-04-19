using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    public int numberOfFoodObjects = 10;

    private SphereCollider sphereCollider;

    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();

        if (sphereCollider == null)
        {
            Debug.LogError("SphereCollider not found on the spherical world object.");
            return;
        }

        for (int i = 0; i < numberOfFoodObjects; i++)
        {
            SpawnFood();
        }
    }

    public void SpawnFood()
    {
        Vector3 randomDirection = Random.onUnitSphere;
        Vector3 spawnPosition = transform.position + randomDirection * (sphereCollider.radius * transform.localScale.x);

        GameObject newFood = Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
        newFood.transform.SetParent(transform);

        // Orient the food object towards the center of the sphere
        newFood.transform.up = -randomDirection;
    }
}
