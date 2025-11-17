using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //GLOBAL VARIABLES
    public Transform[] patrolPoints; //List of Patrol Points
    public float moveSpeed = 4; //Movement speed of the Laser
    public int patrolDestination; //The destination for the enemy to move
    public Transform laserObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement(); //Call the enemy movement function
    }

    private void EnemyMovement() //Enemy movement to patrol points
    {
        if (patrolDestination == 0)// if player at patrol destination 0
        {
            laserObject.position = Vector3.MoveTowards(laserObject.position, patrolPoints[0].position, moveSpeed * Time.deltaTime); //move towards patrol point 0

            if (Vector3.Distance(laserObject.position, patrolPoints[0].position) < 0.5) // if at patrol point 0 move to
            {
                patrolDestination = 1; //go to patrol point 1
            }
        }

        else if (patrolDestination == 1) //if player at patrol destination 1
        {
            laserObject.position = Vector3.MoveTowards(laserObject.position, patrolPoints[1].position, moveSpeed * Time.deltaTime); //move to patrol point 1

            if (Vector3.Distance(laserObject.position, patrolPoints[1].position) < 0.5) // if at patrol point 1 move to
            {
                patrolDestination = 0; //go to patrol point 0
            }
        }
    }
}
