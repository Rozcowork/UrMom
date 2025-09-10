using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    //Global Variables
    public string GameSceneName; //Target Scene to change whenever

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
        SceneManager.LoadScene(GameSceneName);
    }
}
