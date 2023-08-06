using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    //private int MaxHp = 10;
    private double curHp;
    public Image HealthbarFill;
    public TextMeshProUGUI HPText;
    


    public void Start() {
       if (GameManager.instance.GetDefeated() == 10)
    {
        curHp = GameManager.instance.GetBossHP();
    }
    else
    {
        curHp = GameManager.instance.GetMaxHp();
    }

    UpdateHealthbar();
    UpdateHPText();
    }
    public void DamageAuto(double damage) {
        curHp -= damage;
        UpdateHealthbar();
        UpdateHPText();

        if (curHp <= 0) {
            Defeated();
        }
    }

    public void Damage(){
        curHp -= GameManager.instance.ClickPower;
        UpdateHealthbar();
        UpdateHPText();

        if (curHp <= 0) {
            Defeated();
        }
    }

    public void Defeated(){
        GameManager.instance.incrementDefeated();
        GameManager.instance.AddMoney(GameManager.instance.GetMoneyToGive());
        Debug.Log("Enemy Defeated " + GameManager.instance.GetDefeated());
        if(GameManager.instance.GetDefeated() == 10){
            curHp = GameManager.instance.GetBossHP();
            Debug.Log("Boss fight");
        }
        if(GameManager.instance.GetDefeated() == 11){
            GameManager.instance.AddMoney(GameManager.instance.GetBossMoneyToGive());
            GameManager.instance.DoubleBossMoneyToGive();
            LvLUp();
            GameManager.instance.SetDefeated(1);
            Debug.Log("Defeated reset to" + GameManager.instance.GetDefeated());
       }
        GameManager.instance.UpdateStageText();
        EnemyManager.instance.ReplaceEnemy(gameObject);
    }

    public void LvLUp(){
        GameManager.instance.doubleMaxHP();
        curHp = GameManager.instance.GetMaxHp();
        GameManager.instance.DoubleBossHP();  
        GameManager.instance.DoubleMoneyToGive();
        HealthbarFill.fillAmount = (float)curHp / (float)GameManager.instance.GetMaxHp();
        GameManager.instance.incrementLvL();
        GameManager.instance.UpdateLvLText();
    }

    private void UpdateHPText(){
        HPText.text = curHp.ToString();
    }
    
    private void UpdateHealthbar(){
        if (GameManager.instance.GetDefeated() == 10) {
            HealthbarFill.fillAmount = (float)curHp / (float)GameManager.instance.GetBossHP();
        } else {
            HealthbarFill.fillAmount = (float)curHp / (float)GameManager.instance.GetMaxHp();
        }
    }
}
