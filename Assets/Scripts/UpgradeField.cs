using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeField : MonoBehaviour
{
    private enum upgradeType
    {
        upgradeTimer,
        upgradeDrawTime,
        upgradeCoinDropRate,
        upgradeBasketSize
    }
    [SerializeField] upgradeType type = upgradeType.upgradeTimer;

    private int playerTimer;
    private float playerDrawTime;
    private int playerCoinDropRate;
    private float playerBasketSize;

    [SerializeField] TextMeshProUGUI coinText;

    void Start()
    {
        playerTimer = PlayerPrefs.GetInt("GameTimer");
        playerDrawTime = PlayerPrefs.GetFloat("DrawTimer");
        playerCoinDropRate = PlayerPrefs.GetInt("CoinDropRate");
        playerBasketSize = PlayerPrefs.GetFloat("BasketSize");
        CheckMaxed();



    }
    public void OnButtonPress()
    {
        switch (type)
        {
            case upgradeType.upgradeTimer:
                if (playerTimer < 60 && PlayerMoney.Instance.TryRemoveMoney(40))
                {
                    playerTimer += 10;
                    Debug.Log(playerTimer.ToString());
                    PlayerPrefs.SetInt("GameTimer", playerTimer);
                }
                CheckMaxed();
                break;

            case upgradeType.upgradeDrawTime:
                if (playerDrawTime < 3f && PlayerMoney.Instance.TryRemoveMoney(40))
                {
                    playerDrawTime += .2f;
                    Debug.Log(playerDrawTime.ToString());
                    PlayerPrefs.SetFloat("DrawTimer", playerDrawTime);
                }
                CheckMaxed();

                break;
            case upgradeType.upgradeCoinDropRate:
                if (playerCoinDropRate > 5 && PlayerMoney.Instance.TryRemoveMoney(40))
                {
                    playerCoinDropRate -= 1;
                    Debug.Log(playerCoinDropRate.ToString());
                    PlayerPrefs.SetInt("CoinDropRate", playerCoinDropRate);
                }
                CheckMaxed();

                break;
            case upgradeType.upgradeBasketSize:
                if (playerBasketSize < 2f && PlayerMoney.Instance.TryRemoveMoney(40))
                {
                    playerBasketSize += .01f;
                    Debug.Log(playerBasketSize.ToString());
                    PlayerPrefs.SetFloat("BasketSize", playerBasketSize);
                }
                CheckMaxed();
                break;
        }

    }

    private void CheckMaxed()
    {
        switch (type)
        {
            case upgradeType.upgradeTimer:
                if (playerTimer >= 60)
                {
                    coinText.text = "MAX";
                }
                break;
            
            case upgradeType.upgradeDrawTime:
                if (playerDrawTime >= 3f)
                {
                    coinText.text = "MAX";
                }
                break; 
            
            case upgradeType.upgradeCoinDropRate:
                if (playerCoinDropRate <= 5)
                {
                    coinText.text = "MAX";
                }
                break;
            case upgradeType.upgradeBasketSize:
                if (playerBasketSize >= .2f)
                {
                    coinText.text = "MAX";
                }
                break;
        }
        
        
        
    }
}
