using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickManager : MonoBehaviour
{
    public List <float> AutoClicker = new List<float>();

    private double AutoClickerPrice = 10;
    private int AutoClickerAmount = 0;
    public TextMeshProUGUI AutoClickerQuantity;
    private double PlayerDamagePrice = 10;
    public TextMeshProUGUI PlayerDamageQuantity;
    public TextMeshProUGUI AutoClickerPriceText;
    public TextMeshProUGUI PlayerDamagePriceText;


    void Start()
    {
        AutoClickerQuantity.text = "Auto Clicker Damage : " + AutoClickerAmount.ToString();
        PlayerDamageQuantity.text = "Click Damage: " + GameManager.instance.ClickPower.ToString();
        AutoClickerPriceText.text = AutoClickerPrice.ToString();
        PlayerDamagePriceText.text = PlayerDamagePrice.ToString();
    }
    void Update()
    {
        for(int i = 0; i < AutoClicker.Count; i++){
            // is it time to click
            if(Time.time - AutoClicker[i] >= 1){
                AutoClicker[i] = Time.time;
                EnemyManager.instance.CurEnemy.DamageAuto();
            }
        }
    }

    public void OnBuyAutoClicker(){
        if(GameManager.instance.Money >= AutoClickerPrice) {
            GameManager.instance.TakeMoney(AutoClickerPrice);
            AutoClickerAmount++;
            AutoClicker.Add(Time.time);
            AutoClickerPrice = (int)(AutoClickerPrice * 1.25);
            AutoClickerPriceText.text = AutoClickerPrice.ToString();
            AutoClickerQuantity.text = "Auto Clicker Damage : " + AutoClicker.Count.ToString();
        }
    }

    public void OnBuyPlayerDmg(){
        if(GameManager.instance.Money >= PlayerDamagePrice) {
            GameManager.instance.TakeMoney(PlayerDamagePrice);
            GameManager.instance.ClickPower++;
            if (GameManager.instance.ClickPower == 50){
                GameManager.instance.ClickPower = GameManager.instance.ClickPower * 2;
            }
            PlayerDamagePrice = (int)(PlayerDamagePrice *1.25);
            PlayerDamagePriceText.text = PlayerDamagePrice.ToString();
            PlayerDamageQuantity.text = "Click Damage: " + GameManager.instance.ClickPower.ToString();
        }
    }

}
