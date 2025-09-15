using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public PlayerController player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerController playerRespawn = other.GetComponent<PlayerController>();
            if (playerRespawn != null)
            {
                playerRespawn.SetRespawnPoint(transform.position);
            }
        }
    }
}
