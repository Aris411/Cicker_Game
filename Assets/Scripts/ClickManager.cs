using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickManager : MonoBehaviour
{
    public TextMeshProUGUI PlayerDamageQuantity;
    public TextMeshProUGUI AutoClickerPriceText;
    public TextMeshProUGUI PlayerDamagePriceText;
    public TextMeshProUGUI DpsText;

    private double PlayerDamagePrice = 10;
    private int PlayerPurchased = 0;

    private float AutoClicker1Timer = 1.0f;
    private double AutoClicker1Price = 10;
    public TextMeshProUGUI AutoClicker1PriceText;
    private int AutoClicker1purchases = 0;
    public GameObject BuyAutoClicker1;

    private float AutoClicker2Timer = 1.0f;
    private double AutoClicker2Price = 80;
    public TextMeshProUGUI AutoClicker2PriceText;
    public GameObject BuyAutoClicker2;

    void Start()
    {
        PlayerDamageQuantity.text = "Click Damage: " + GameManager.instance.ClickPower.ToString();
        PlayerDamagePriceText.text = PlayerDamagePrice.ToString();
        UpdateDpsText();
        upadteShopText();
        BuyAutoClicker2.SetActive(false);
        BuyAutoClicker1.SetActive(false);
    }
    void Update()
    {
        if(PlayerPurchased >= 10){
            BuyAutoClicker1.SetActive(true);
        }
        if(AutoClicker1purchases >= 5){
            BuyAutoClicker2.SetActive(true);
        }
        if(GameManager.instance.getAutoClicker1Damage() > 0){
            AutoClicker1Timer -= Time.deltaTime;
            if (AutoClicker1Timer <= 0.0f){
                AutoClicker1Timer = 1.0f;
                EnemyManager.instance.CurEnemy.DamageAuto(GameManager.instance.getAutoClicker1Damage());
            }
        }
        if(GameManager.instance.getAutoClicker2Damage() > 0){
            AutoClicker2Timer -= Time.deltaTime;
            if (AutoClicker2Timer <= 0.0f){
                AutoClicker2Timer = 1.0f;
                EnemyManager.instance.CurEnemy.DamageAuto(GameManager.instance.getAutoClicker2Damage());
            }
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
            PlayerPurchased++;
        }
    }

    public void OnBuyAutoClicker1(){
        if(GameManager.instance.Money >= AutoClicker1Price) {
            GameManager.instance.TakeMoney(AutoClicker1Price);
            GameManager.instance.IncrementAutoClicker1Damage();
            AutoClicker1Price = (int)(AutoClicker1Price * 1.25);
            AutoClicker1PriceText.text = AutoClicker1Price.ToString(); 
            AutoClicker1purchases++;
            UpdateDpsText();
        }
    }

    public void OnBuyAutoClicker2(){
        if(GameManager.instance.Money >= AutoClicker2Price) {
            GameManager.instance.TakeMoney(AutoClicker2Price);
            GameManager.instance.IncrementAutoClicker2Damage();
            AutoClicker2Price = (int)(AutoClicker2Price * 1.35);
            AutoClicker2PriceText.text = AutoClicker2Price.ToString(); 
            UpdateDpsText();
        }
    }

    public void UpdateDpsText(){
        DpsText.text = "DPS: " + (GameManager.instance.getAutoClicker1Damage() + GameManager.instance.getAutoClicker2Damage()).ToString();
    }

    public void upadteShopText(){
        AutoClickerPriceText.text = AutoClicker1Price.ToString();
        AutoClicker2PriceText.text = AutoClicker2Price.ToString();
    }
}
