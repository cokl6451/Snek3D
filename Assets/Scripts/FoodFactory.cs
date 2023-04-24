using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodFactory : MonoBehaviour
{
    public GameObject regFoodPrefab;
    public GameObject speedFoodPrefab;
    public GameObject superFoodPrefab;

    public GameObject CreateFood(string foodType)
    {
        GameObject foodPrefab;
        switch (foodType)
        {
            case "Regular":
                foodPrefab = regFoodPrefab;
                break;
            case "Speed":
                foodPrefab = speedFoodPrefab;
                break;
            case "Super":
                foodPrefab = superFoodPrefab;
                break;
            default:
                Debug.LogError("Invalid food type.");
                foodPrefab = null;
                break;
        }

        return foodPrefab;
    }
}
