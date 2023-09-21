using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    
    public void LoadLastLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("LastLevel") + 2);
    }
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex + 2);
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
