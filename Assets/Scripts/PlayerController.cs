using System.Collections;
using DG.Tweening;
using NUnit.Framework;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //GLOBAL VARIABLES
    public Rigidbody2D playerBody;// Body of the Player
    public float playerSpeed = .009f; //Speed of the Player
    public float jumpHeight = 15;// Force applied to the jump
    public bool isGround; //To check if player has contact with the ground
    private Vector3 currentRespawnPoint; //find the position of current respawn point
    public SpriteRenderer visual; //find the sprite renderer visual
    public bool isFlipped; //boolean for the invisible flip
    public bool isMoving; //boolean to check if player is moving
    private bool previousIsMoving;
    public float invisibleFlipDuration = 1;

    //"Flip" Facing direction variables
    public bool flippedLeft; //Keep track of which way our sprite is currently facing
    public bool facingLeft; //Keep track of which way our sprite should be facing

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentRespawnPoint = transform.position; //spawn at the current position
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(); //call MovePlayer constantly
        Jump(); //call Jump constantly

       
    }

    public void SetRespawnPoint(Vector3 newPoint) //setting position of checkpoint
    {
        //Debug.Log(newPoint.ToString());
        currentRespawnPoint = newPoint; //change the old respawn point to the new checkpoint
    }

    private void MovePlayer() //this private void is to move the player
    {
        Vector3 newPos = transform.position; //Current position of the player

        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) //if you press "A" and not "D" change position 
        {
            newPos.x -= playerSpeed; //When "A" is pressed go Left
            facingLeft = true; //set the boolean to true when facing left
            Flip(facingLeft); //call the Flip Facing Left void
            ChangeMoving(true); //change moving boolean to true
        }
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)) //if you press "D" and "A" change position
        {
            newPos.x += playerSpeed; //when "D" is pressed go right
            facingLeft = false; //set the boolean to false when facing right
            Flip(facingLeft); //call the Flip Facing left void
            ChangeMoving(true); //change moving boolean to true
        }

        else  //If both A & D are pressed simultaneously or you're not pressing anything
        {
            
            ChangeMoving(false); //change moving boolean to false

        }

        transform.position = newPos; //close the loop of the if statements to move player
    }

    private void Jump() //this private void is for the Player to Jump
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround) //if isJumping is true and you press "Spacebar" change position
        {
            playerBody.AddForce(new Vector3(0, Mathf.Sqrt(2 * jumpHeight * playerBody.gravityScale), 0), ForceMode2D.Impulse); //Add jump force to the player to change new vertical postion
            isGround = false; //change boolean to false so you are unable to jump
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //when anything collides with this object
    {
        if (collision.gameObject.tag == "Surface") //when you collide with the object named Surface
        {

            isGround = true; //change boolean to true so you can jump again
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

    

    void InvisbleFlip(bool isFlipped) //Cancels any current flip and starts a new one
    {
       
        DOTween.Kill(visual.transform); //Kill any exisiting Flip Tween

        if (isFlipped) //if we want to be flipped
        {
            visual.transform.DOLocalRotate(new Vector3(0, 90, 0), invisibleFlipDuration); //Rotate smoothly to 90 degrees
        }

        else //if you do not want to be flipped
        {
            visual.transform.DOLocalRotate(new Vector3(0, 0, 0), invisibleFlipDuration); //Rotate smoothly to default
        }
    }

    public void Respawn() //Respawn the player at the current respawn
    {
        transform.position = currentRespawnPoint; //change position of the player to the current respawn point
    }

    private void ChangeMoving(bool newIsMoving) //this function is called everyframe
    {
        isMoving = newIsMoving; //Update the current
        if (isMoving != previousIsMoving) //if your current isMoving is different from previous
        {
            previousIsMoving = isMoving; //Update the previous isMoving to current
            OnMoveChange(isMoving); //Call the OnMoveChange the instant that isMoving changes
        }
    }

    private void OnMoveChange(bool newIsMoving) //called once
    {
        if (newIsMoving) //if you start moving then flip to normal
        {
            InvisbleFlip(false); 
            //Debug.Log("Moving");
        }
        else //if you stop moving then flip to Invisible
        {
            InvisbleFlip(true); 
            //Debug.Log("Stopped");
        }
    }
}
