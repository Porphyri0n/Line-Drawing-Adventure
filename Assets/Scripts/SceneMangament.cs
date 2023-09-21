using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMangament : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadEndlessGameScene()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadShop()
    {
        SceneManager.LoadScene(1);
    }
    public void Loadlevels()
    {
        SceneManager.LoadScene(2);
    }
}
