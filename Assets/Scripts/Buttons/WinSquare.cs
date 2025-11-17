using UnityEngine;
using UnityEngine.SceneManagement; //using the scene manager

public class WinSquare : MonoBehaviour
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
            SceneManager.LoadScene(2); //load the end scene
        }
    }
}
