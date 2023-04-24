using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    public int numberOfFoodObjects = 10;

    private SphereCollider sphereCollider;
    private FoodFactory foodFactory;

    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        foodFactory = GetComponent<FoodFactory>();

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
        //generate a random number to control probability for each food type
        int num = Random.Range(0, 10);
        string foodType;
        //80% should be normal
        if(num <= 7){
            foodType = "Regular";
        }else if(num == 8){
            foodType = "Speed";
        }else{
            foodType = "Super";
        }

        //spawn a food prefab
        GameObject foodPrefab = foodFactory.CreateFood(foodType);

        Vector3 randomDirection = Random.onUnitSphere;
        Vector3 spawnPosition = transform.position + randomDirection * (sphereCollider.radius * transform.localScale.x);

        GameObject newFood = Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
        newFood.transform.SetParent(transform);
    }
}
