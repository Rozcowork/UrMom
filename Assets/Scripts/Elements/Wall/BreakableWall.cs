using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if(gameObject.tag == "Obstacle") //check to see if chaser hit it
        Destroy(gameObject); //then it gets destroyed
    }
}
