using UnityEngine;
using UnityEngine.SceneManagement; //using the scene manager

public class TitleScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() //Changes Scene to the Target Scene
    {
        SceneManager.LoadScene(1); //load the gameplay scene
    }
}
