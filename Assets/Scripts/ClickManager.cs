using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickManager : MonoBehaviour
{
    public List <float> AutoClicker = new List<float>();

    private int AutoClickerPrice = 10;
    public TextMeshProUGUI AutoClickerQuantity;
    private int PlayerDamagePrice = 10;
    public TextMeshProUGUI PlayerDamageQuantity;


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
            AutoClicker.Add(Time.time);
            AutoClickerPrice *= 2;

            AutoClickerQuantity.text = AutoClicker.Count.ToString();
        }
    }

    public void OnBuyPlayerDmg(){
        if(GameManager.instance.Money >= PlayerDamagePrice) {
            GameManager.instance.TakeMoney(PlayerDamagePrice);
            GameManager.instance.ClickPower++;
            PlayerDamagePrice *= 2;

            PlayerDamageQuantity.text = GameManager.instance.ClickPower.ToString();
        }
    }

}
