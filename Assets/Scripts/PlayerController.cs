using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //GLOBAL VARIABLES
    public Rigidbody2D playerBody;// Body of the Player
    public float playerSpeed = .009f; //Speed of the Player
    public float jumpHeight = 15;// Force applied to the jump
    public bool isGround; //To check if player has contact with the ground
    private Vector3 currentRespawnPoint;

    //"Flip" direction variables
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

        //else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        //{
            //newPos = Vector3.zero;
            //Debug.Log("Not Moving");
        //}

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Surface")
        {
            
            isGround = true;
        }
    }
    void Flip(bool facingLeft) //this void flips the character
    {
        if (facingLeft && !flippedLeft) //if facingLeft is true and the flippedLeft is false rotate the player
        {
            transform.Rotate(0, -180, 0); //change the way the player is facing to the left
            flippedLeft = true; //set the boolean to true
        }

        if (flippedLeft && !facingLeft) //if flippedLeft is true and the facingLeft is false rotate the plaer
        {
            transform.Rotate(0, 180, 0); //change the way the player is facing to the right
            flippedLeft = false; //set the boolean to false
        }
    }
}
