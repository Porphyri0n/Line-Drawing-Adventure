using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MainManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinText,highestScoreText;
    void Start()
    {

        Time.timeScale = 1;
        highestScoreText.text = PlayerPrefs.GetInt("HighestScore").ToString();
        Application.targetFrameRate= 60;
        CreateGlobalVariables();
        coinText.text = PlayerPrefs.GetInt("prefMoney").ToString();
    }
    void Update()
    {
        
    }
    private void CreateGlobalVariables()
    {
        if (!PlayerPrefs.HasKey("GameTimer"))
        {
            PlayerPrefs.SetInt("GameTimer", 30);
        }
        if (!PlayerPrefs.HasKey("DrawTimer"))
        {
            PlayerPrefs.SetFloat("DrawTimer", 2f);
        }
        if (!PlayerPrefs.HasKey("CoinDropRate"))
        {
            PlayerPrefs.SetInt("CoinDropRate", 7);
        }
        if (!PlayerPrefs.HasKey("HighestScore"))
        {
            PlayerPrefs.SetInt("HighestScore", 0);
        }
        if (!PlayerPrefs.HasKey("LastLevel"))
        {
            PlayerPrefs.SetInt("LastLevel", 0);
        }
        if (!PlayerPrefs.HasKey("BasketSize"))
        {
            PlayerPrefs.SetFloat("BasketSize", 0.15f);
        }
    }
}
