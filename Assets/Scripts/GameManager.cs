using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] List<Sprite> backGrounds;
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private TextMeshProUGUI collectedFruitText;
    [SerializeField] private TextMeshProUGUI collectedMoneyText;
    [SerializeField] private TextMeshProUGUI remainingTime;
    [SerializeField] private TextMeshProUGUI highestScoreText,highestScoreText2;
    [SerializeField] private Animator EndPanel;
    [SerializeField] private Transform Basket;
    private int gameTimer;
    private int collectedFruits;
    private int collectedMoney = 0;
    private int prefGameTimer;
    private int prefHighestScore;
    void Start()
    {
        Time.timeScale = 1.0f;
        prefGameTimer = PlayerPrefs.GetInt("GameTimer");
        BackgroundSetter();
        Basket.localScale = new Vector3(PlayerPrefs.GetFloat("BasketSize"), 0.15f,1f);
        collectedFruits = 0;
        prefHighestScore = PlayerPrefs.GetInt("HighestScore");
        highestScoreText.text = prefHighestScore.ToString();
        highestScoreText2.text = prefHighestScore.ToString();
        collectedFruitText.text = collectedFruits.ToString();
        collectedMoneyText.text = collectedMoney.ToString();
        StartCoroutine(GameTimerCoroutine(prefGameTimer));
        instance = this;

    }
    void Update()
    {
        
    }
    public void addCollectedFruit(int FruitToAd0d) 
    {
        collectedFruits++;
        collectedFruitText.text = collectedFruits.ToString();
    }
    public void addCollectedCoin()
    {
        collectedMoney++;
        collectedMoneyText.text = collectedMoney.ToString();
    }

    public void ScaleTime(int timeScale)
    {
        Time.timeScale= timeScale;
    }
    private IEnumerator GameTimerCoroutine(int GameTimer)
    {
        for (gameTimer = GameTimer; gameTimer >= 0; gameTimer-=1)
        {
            remainingTime.text = gameTimer.ToString();
            yield return new WaitForSeconds(1f);
            if (gameTimer <= 6)
            {
                remainingTime.color= Color.red;
            }
            else
            {
                remainingTime.color = new Color(0.53f,0.53f,0.53f);
            }
        }
        
        ScaleTime(0);
        EndPanel.SetTrigger("EndMenuOpen");
        

    }
    public void IncereaseTime()
    {
        gameTimer += 5;
    }

    public void ReturnMainMenu()
    {
        if (collectedFruits > prefHighestScore)
        {
            PlayerPrefs.SetInt("HighestScore", collectedFruits);
        }
        PlayerMoney.Instance.SaveMoney(collectedMoney);
        SceneManager.LoadScene(0);
    }
    public void ReplayScene()
    {
        if(collectedFruits>prefHighestScore)
        {
            PlayerPrefs.SetInt("HighestScore", collectedFruits);
        }
        PlayerMoney.Instance.SaveMoney(collectedMoney);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void BackgroundSetter()
    {
        background.sprite = backGrounds[Random.Range(0,backGrounds.Count)];
    }

}
