using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//STRATEGY PATTERN FOR FOOD EFFECT LOGIC
//create an interface to handle effects
public interface IFoodEffect
{
    //return an int to represent score of each food effect
    int ApplyEffect(PlayerController playerController, PlayerTail playerTail);
}

//Concrete strategies
public class RegularFoodEffect : IFoodEffect
{
    public int ApplyEffect(PlayerController playerController, PlayerTail playerTail)
    {
        //Add 25 tail prefabs for a normal food
        for(int i = 0; i < 25; i++){
            playerTail.GrowTail();
        }
        return 1;
    }
}

public class SpeedFoodEffect : IFoodEffect
{
    public int ApplyEffect(PlayerController playerController, PlayerTail playerTail)
    {
        //Add 25 tail prefabs
        for(int i = 0; i < 25; i++){
            playerTail.GrowTail();
        }
        playerController.moveSpeed *= 2;
        playerController.Invoke("ResetSpeed", 5f);
        return 1;
    }
}

public class SuperFoodEffect : IFoodEffect
{
    public int ApplyEffect(PlayerController playerController, PlayerTail playerTail)
    {
        //Add 100 tail prefabs for a super food
        for(int i = 0; i < 100; i++){
            playerTail.GrowTail();
        }
        return 4;
    }
}
