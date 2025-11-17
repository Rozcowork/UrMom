using UnityEngine;

public class ChaserCheck : MonoBehaviour
{

    public bool CollEnter = false; //collision checker
    public int Timer = 1000; //'on' timer


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CollEnter == true) //allows the timer to tick down to 0, moving the chaser object
        {
            Timer--;
        }

        if (Timer == 0) //when timer hits 0, stops chaser from moving
        {
            CollEnter = false;
            Timer = 1000;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CollEnter = true; // if player collides with the trigger, then the chaser will give chase

        }
    }
}
