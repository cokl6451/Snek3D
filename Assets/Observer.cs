using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Newtonsoft.Json;
using System.IO;
public class Observer : MonoBehaviour
{

   //  Observer Implementation!!

}

// Some of the code for this implementaion came from
// https://refactoring.guru/design-patterns/observer/csharp/example

public class Publisher
{
    private List<ISubscriber> subscribers = new List<ISubscriber>();

    public void Subscribe(ISubscriber subscriber)
    {
        subscribers.Add(subscriber);
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        subscribers.Remove(subscriber);
    }

    public void Notify(string score)
    {
        foreach (ISubscriber subscriber in subscribers)
        {
            subscriber.Update(score);
        }
    }
}


// Interface for Subscriber 
public interface ISubscriber
{
    void Update(string score);
}

public class ScoreData
{
    public int score { get; set; }
}


public class Subscriber : ISubscriber
{
    private string name;

    public Subscriber(string name)
    {
        this.name = name;
    }

    public void Update(string score)
    {
        // PUSH TO JSON Database if score is highscore

        string filePath = "db.json";
        

        // IF file does not exist create one and put the score in it
        if (!File.Exists(filePath))
        {
            Debug.Log(" file! does not exist");
            var data = new
            {
                score = score,
            };

            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, data);
                Debug.Log("Created file!");
            }
        }

        // If it does exist then compare the current score and store it if the value is higher
        else if (File.Exists(filePath))
        {
            Debug.Log("file exists!");
            int currentScore = 0;
            int newScore = System.Convert.ToInt32(score);

            using (StreamReader file = File.OpenText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                ScoreData data = (ScoreData)serializer.Deserialize(file, typeof(ScoreData));
                currentScore = System.Convert.ToInt32(data.score);
                
            }

            if (newScore > currentScore)
            {
                var updatedData = new
                {
                    score = newScore,
                };

                using (StreamWriter file = File.CreateText(filePath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, updatedData);
                    Debug.Log(" overwrote file!");

                }
            }
        }

        
    }
}
