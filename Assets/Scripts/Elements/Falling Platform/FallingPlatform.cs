using System.Data;
using UnityEngine;
public class FallingPlatform : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnCollisionStay2D(Collision2D collision) //method for checking if the player is touching the platform
    {
        if (collision.gameObject.CompareTag("Player")) //if that object is the Player
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>(); // grab the player controller script from the object
            if (player != null) //if the player controller script exists on that object
            {
                Collider2D PlatformCollider = GetComponent<Collider2D>(); //makes a variable out of the collider for the platform
                PlatformCollider.isTrigger = player.isInvisibleFlip; //makes the platform a trigger when the player is invisible
            }
        }
    }
}
