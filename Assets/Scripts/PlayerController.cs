using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //GLOBAL VARIABLES
    public Rigidbody2D playerBody;// Body of the Player
    public float playerSpeed = .009f; //Speed of the Player
    public float jumpHeight = 15;// Force applied to the jump
    public bool isGround; //To check if player has contact with the ground
    private Vector3 currentRespawnPoint;
    public SpriteRenderer visual;
    public bool isFlipped;
    private Coroutine flipCoroutine;

    //"Flip" Facing direction variables
    public bool flippedLeft; //Keep track of which way our sprite is currently facing
    public bool facingLeft; //Keep track of which way our sprite should be facing

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentRespawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(); //call MovePlayer constantly
        Jump(); //call Jump constantly
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            InvisbleFlip(!isFlipped);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("FallDetector"))
        {
            transform.position = currentRespawnPoint;
        }
    }

    public void SetRespawnPoint(Vector3 newPoint)
    {
        Debug.Log(newPoint.ToString());
        currentRespawnPoint = newPoint;
    }

    private void MovePlayer() //this private void is to move the player
    {
        Vector3 newPos = transform.position; //Current position of the player
      
        if (Input.GetKey(KeyCode.A)) //if you press "A" change position
        {
            newPos.x -= playerSpeed; //When "A" is pressed go Left
            facingLeft = true; //set the boolean to true when facing left
            Flip(facingLeft); //call the Flip Facing Left void
        }
        else if (Input.GetKey(KeyCode.D)) //if you press "D" change position
        {
            newPos.x += playerSpeed; //when "D" is pressed go right
            facingLeft = false; //set the boolean to false when facing right
            Flip(facingLeft); //call the Flip Facing left void
        }

        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            Debug.Log("Not Moving");
        }

        transform.position = newPos; //close the loop of the if statements to move player
    }

    private void Jump() //this private void is for the Player to Jump
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround) //if isJumping is true and you press "Spacebar" change position
        {
            playerBody.AddForce(new Vector3(0, Mathf.Sqrt(2*jumpHeight*playerBody.gravityScale), 0),ForceMode2D.Impulse); //Add jump force to the player to change new vertical postion
            isGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //when the player collides with this object
    {
        if (collision.gameObject.tag == "Surface") //if the player collides with the object called surface
        {
            
            isGround = true;
        }
    }
    void Flip(bool facingLeft) //this void flips the character
    {
        if (facingLeft && !flippedLeft) //if facingLeft is true and the flippedLeft is false rotate the player
        {
            visual.flipX = true; //change the way the player is facing to the left
            flippedLeft = true; //set the boolean to true
        }

        if (flippedLeft && !facingLeft) //if flippedLeft is true and the facingLeft is false rotate the plaer
        {
            visual.flipX = false; //change the way the player is facing to the right
            flippedLeft = false; //set the boolean to false
        }
    }

    IEnumerator FlipCoroutine(bool isFlipped)
    {
        this.isFlipped = isFlipped; //sets the global variable
        if (isFlipped)
        {
            float rotation = 0; // Start at 0
            float duration = 1; // Finish at 1 sec
            for (float time = 0; time < duration; time += Time.deltaTime) //over the time rotate to 90
            {
                rotation = time / duration * 90; //fraction we are till 90 based on our time
                visual.transform.localRotation = Quaternion.Euler(0, rotation, 0); //setting our rotation
                yield return null; //wait 1 Frame
            }
            visual.transform.localRotation = Quaternion.Euler(0, 90, 0); //set new rotation to 90
        }

        else
        {
            float rotation = 90; //Start at 90
            float duration = 1; //Finsih at 1 sec
            for (float time = 0; time < duration; time += Time.deltaTime) //over the time rotate 
            {
                rotation = 90 - time / duration * 90; //90 minus the fraction we are till we are the original position
                visual.transform.localRotation = Quaternion.Euler(0, rotation, 0); //setting our rotation
                yield return null; //wait 1 Frame
            }
            visual.transform.localRotation = Quaternion.Euler(0, 0, 0); //set new rotation to original
        }

        flipCoroutine = null; //end the coroutine
    }

    void InvisbleFlip(bool isFlipped)
    {
        if (flipCoroutine != null)
        {
            StopCoroutine(flipCoroutine); // Cancel all existing coroutines
            flipCoroutine = null;
        }
        flipCoroutine = StartCoroutine(FlipCoroutine(isFlipped));
    }
}
