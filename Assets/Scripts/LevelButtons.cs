using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelButtons : MonoBehaviour
{
    [SerializeField] int levelNumber;
    [SerializeField] Image Lock;
    private Button button0;

    void Start()
    {
        button0 = GetComponent<Button>();
        if (levelNumber <= PlayerPrefs.GetInt("LastLevel"))
        {
            button0.interactable= true;
            Lock.enabled= false;
        }
        else
        {
            button0.interactable= false;
            Lock.enabled= true;
        }
    }


}
