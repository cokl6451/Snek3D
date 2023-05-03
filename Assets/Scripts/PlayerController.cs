using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10;
    private Vector3 moveDir;
    private Vector3 lastMoveDir;
    public int playerScore;
    public bool playerIsAlive = true;

    private PlayerTail playerTail;
    public Text scoreText;

    // Reference the FoodSpawner script
    private FoodSpawner foodSpawner;

    // Create an event for game over
    public static event Action OnGameOver;

    // Add a minimum distance for tail collision
    public float minTailCollisionDistance = 0.8f;


    // Create a publisher
    Publisher publisher = new Publisher();

    // Create subscribers
    Subscriber subscriber1 = new Subscriber("Subscriber 1");

    void Start()
    {
        playerTail = GetComponent<PlayerTail>();

        // Find the FoodSpawner script in the scene
        foodSpawner = FindObjectOfType<FoodSpawner>();
        if (foodSpawner == null)
        {
            Debug.LogError("FoodSpawner not found in the scene.");
        }


        // Subscribe to the publisher
        publisher.Subscribe(subscriber1);
    }

    void Update()
    {
        Vector3 inputMoveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        if(inputMoveDir != Vector3.zero){
            moveDir = inputMoveDir;
            lastMoveDir = moveDir;
        }else{
            moveDir = lastMoveDir;
        }
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);
    }

    // Detect collisions with food objects and tail
    void OnTriggerEnter(Collider other)
    {
        IFoodEffect foodEffect = null;
        
        if (other.CompareTag("RegularFood")){
            foodEffect = new RegularFoodEffect();
        }
        else if (other.CompareTag("SpeedFood")){
            foodEffect = new SpeedFoodEffect();
        }
        else if (other.CompareTag("SuperFood")){
            foodEffect = new SuperFoodEffect();
        }

        if (foodEffect != null){

            int score = foodEffect.ApplyEffect(this, playerTail);
            addScore(score);
            //Replace the food
            if (foodSpawner != null)
            {
                foodSpawner.SpawnFood();
            }

            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Tail"))
        {
            //Add a grace period so the head isn't constantly detecting the first tail object since it's embedded in the head's sphere collider
            if ((other.transform.position - transform.position).magnitude > minTailCollisionDistance)
            {
                if (OnGameOver != null)
                {
                    OnGameOver();

                    // Snek can no longer move
                    // playerIsAlive is not doing anything right now
                    // maybe there is better way to of  stopping the game instead of setting player moveSpeed to 0

                    // Notify the sub
                    publisher.Notify(playerScore.ToString());

                    playerIsAlive = false;
                    moveSpeed = 0;
                }
            }
        }
    }

    public void addScore(int score)
    {
        playerScore += score;
        scoreText.text = playerScore.ToString();
    }

    public void ResetSpeed(){
        moveSpeed /= 2;
    }      

}
