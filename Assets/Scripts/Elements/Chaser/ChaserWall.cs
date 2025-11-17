using UnityEngine;

public class ChaserWall : MonoBehaviour
{
    public GameObject BreakableWall; //connects to the actual wall to check to destroy

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D  other) //when any pbject collides with the trigger of this object 
    {

        if (other.CompareTag("Player")) //if that object is the Player
        {
            Destroy(BreakableWall); //destroy the wall object

            PlayerController playerRespawn = other.GetComponent<PlayerController>(); // grab the player controller script from the object
            if (playerRespawn != null) //if the player controller script exists on that object
            {
                playerRespawn.TryKillPlayer(); //Respawn the player
            }
        }
        if (other.CompareTag("Obstacle")) //if that object is the Player
        {
        }
    }
}
