using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int Money;
    public TextMeshProUGUI MoneyText;
    public static GameManager instance;

    void Awake() {
        instance = this;
    }

    public void AddMoney(int amount){
        Money += amount;
        MoneyText.text = Money.ToString();
    }

    public void TakeMoney(int amount){
        Money -= amount;
        MoneyText.text = Money.ToString();
    }
}
