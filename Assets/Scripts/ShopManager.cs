using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    private int playerMoney;
    private const string prefMoney = "prefMoney";
    [SerializeField] private TextMeshProUGUI playerMoneyText;

    void Start()
    {
        playerMoney = PlayerPrefs.GetInt(prefMoney);
        //playerMoneyText.text = playerMoney.ToString();
    }


    void Update()
    {
        playerMoneyText.text = PlayerMoney.Instance.playerMoney.ToString();
    }
}
