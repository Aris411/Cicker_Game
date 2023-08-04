using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    //private int MaxHp = 10;
    private int curHp;
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

    HealthbarFill.fillAmount = (float)curHp / (float)GameManager.instance.GetMaxHp();
    UpdateHPText();
    }
    public void DamageAuto() {
        curHp--;
        HealthbarFill.fillAmount = (float)curHp / (float)GameManager.instance.GetMaxHp();
        UpdateHPText();

        if (curHp <= 0) {
            Defeated();
        }
    }

    public void Damage(){
        curHp -= GameManager.instance.ClickPower;
        HealthbarFill.fillAmount = (float)curHp / (float)GameManager.instance.GetMaxHp();
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

    private void UpdateHPText()
    {
        HPText.text = curHp.ToString();
    }
    
}
