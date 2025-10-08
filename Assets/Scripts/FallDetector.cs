using UnityEngine;

public class FallDetector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other) //when any pbject collides with the trigger of this object 
    {
        if (other.CompareTag("Player")) //if that object is the Player
        {
            PlayerController playerRespawn = other.GetComponent<PlayerController>(); // grab the player controller script from the object
            if (playerRespawn != null) //if the player controller script exists on that object
            {
                playerRespawn.KillPlayer(); //Respawn the player
            }
        }
    }
}
