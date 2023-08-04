using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickManager : MonoBehaviour
{
    public List <float> AutoClicker = new List<float>();

    public int AutoClickerPrice;
    public TextMeshProUGUI AutoClickerQuantity;

    void Update()
    {
        for(int i = 0; i < AutoClicker.Count; i++){
            // is it time to click
            if(Time.time - AutoClicker[i] >= 1){
                AutoClicker[i] = Time.time;
                EnemyManager.instance.CurEnemy.Damage();
            }
        }
    }

    public void OnBuyAutoClicker(){
        if(GameManager.instance.Money >+ AutoClickerPrice) {
            GameManager.instance.TakeMoney(AutoClickerPrice);
            AutoClicker.Add(Time.time);

            AutoClickerQuantity.text = AutoClicker.Count.ToString();
        }
    }
}
