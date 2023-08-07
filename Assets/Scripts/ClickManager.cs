using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickManager : MonoBehaviour
{
    public static ClickManager instance;

    public TextMeshProUGUI PlayerDamageQuantity;
    public TextMeshProUGUI AutoClickerPriceText;
    public TextMeshProUGUI PlayerDamagePriceText;
    public TextMeshProUGUI DpsText;

    private double PlayerDamagePrice = 10;
    private int PlayerPurchased = 0;
    public GameObject PlayerButton;

    private float AutoClicker1Timer = 1.0f;
    private double AutoClicker1Price = 10;
    public TextMeshProUGUI AutoClicker1PriceText;
    private int AutoClicker1purchases = 0;
    public GameObject BuyAutoClicker1;

    private float AutoClicker2Timer = 1.0f;
    private double AutoClicker2Price = 80;
    public TextMeshProUGUI AutoClicker2PriceText;
    private int AutpClicker2purchases = 0;
    public GameObject BuyAutoClicker2;

    void Awake() {
        instance = this;
    }
    void Start()
    {
        PlayerDamageQuantity.text = "Click Damage: " + GameManager.instance.ClickPower.ToString();
        PlayerDamagePriceText.text = PlayerDamagePrice.ToString();
        UpdateDpsText();
        upadteShopText();
        BuyAutoClicker2.SetActive(false);
        BuyAutoClicker1.SetActive(false);
        hidePlayerButton();
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
            if (PlayerPurchased == 50){
                GameManager.instance.ClickPower = GameManager.instance.ClickPower * 2;
                PlayerPurchased = 0;
            }
            if (RebirthManager.instance.GetRebirthCount() >= 2){
                PlayerDamagePrice = (int)(PlayerDamagePrice *1.1);
            } else {
                PlayerDamagePrice = (int)(PlayerDamagePrice *1.2);
            }
            PlayerDamagePriceText.text = PlayerDamagePrice.ToString();
            PlayerDamageQuantity.text = "Click Damage: " + GameManager.instance.ClickPower.ToString();
            PlayerPurchased++;
        
            if (RebirthManager.instance.GetRebirthCount() >= 1){
                GameManager.instance.ClickPower++;
                PlayerDamagePriceText.text = PlayerDamagePrice.ToString();
                PlayerDamageQuantity.text = "Click Damage: " + GameManager.instance.ClickPower.ToString();
            }
        }
    }

    public void OnBuyAutoClicker1(){
        if(GameManager.instance.Money >= AutoClicker1Price) {
            GameManager.instance.TakeMoney(AutoClicker1Price);
            GameManager.instance.IncrementAutoClicker1Damage();
            if (RebirthManager.instance.GetRebirthCount() >= 4){
                AutoClicker1Price = (int)(AutoClicker1Price * 1.125);
            } else {
            AutoClicker1Price = (int)(AutoClicker1Price * 1.2);
            }
            AutoClicker1PriceText.text = AutoClicker1Price.ToString(); 
            if (RebirthManager.instance.GetRebirthCount() >= 3){
                GameManager.instance.IncrementAutoClicker1Damage();
            }
            AutoClicker1purchases++;
            if (AutoClicker1purchases == 50){
                GameManager.instance.DoubleAutoClicker1Damage();
                AutoClicker1purchases = 0;
            }
            UpdateDpsText();
        }
    }

    public void OnBuyAutoClicker2(){
        if(GameManager.instance.Money >= AutoClicker2Price) {
            GameManager.instance.TakeMoney(AutoClicker2Price);
            GameManager.instance.IncrementAutoClicker2Damage();
            if (RebirthManager.instance.GetRebirthCount() >= 4){
                AutoClicker2Price = (int)(AutoClicker2Price * 1.125);
            } else {
            AutoClicker2Price = (int)(AutoClicker2Price * 1.25);
            }
            if (RebirthManager.instance.GetRebirthCount() >= 3){
                GameManager.instance.IncrementAutoClicker2Damage();
            }
            AutoClicker2PriceText.text = AutoClicker2Price.ToString();
            AutpClicker2purchases++;
            if(AutpClicker2purchases == 50){
                GameManager.instance.DoubleAutpClicker2Damage();
                AutpClicker2purchases = 0;
            }
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

    public void ResetClickManager(){
        PlayerDamagePrice = 10;
        PlayerPurchased = 0;
        AutoClicker1Timer = 1.0f;
        AutoClicker1Price = 10;
        AutoClicker1purchases = 0;
        AutoClicker2Timer = 1.0f;
        AutoClicker2Price = 80;
        PlayerDamageQuantity.text = "Click Damage: " + GameManager.instance.ClickPower.ToString();
        PlayerDamagePriceText.text = PlayerDamagePrice.ToString();
        UpdateDpsText();
        upadteShopText();
        BuyAutoClicker2.SetActive(false);
        BuyAutoClicker1.SetActive(false);
    }

    public void hidePlayerButton(){
        PlayerButton.SetActive(false);
    }

    public void showPlayerButton(){
        PlayerButton.SetActive(true);
    }
}
