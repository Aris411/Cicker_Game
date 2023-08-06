using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public double Money;
    public TextMeshProUGUI MoneyText;
    
    private int CountDefeated = 1;
    private int LvL = 1;
    public TextMeshProUGUI StageText;
    public TextMeshProUGUI LvLText;

    private double MaxHp = 10;
    private int MoneyToGive = 10;
    private double BossHP = 100;
    private int BossMoneyToGive = 100;
    
    public double ClickPower = 1;
    private double AutoClicker1Damage = 0;
    private double AutoClicker2Damage = 0;

    void Awake() {
        instance = this;
    }

    public void AddMoney(int amount){
        Money += amount;
        MoneyText.text = Money.ToString();
    }

    public void TakeMoney(double amount){
        Money -= amount;
        MoneyText.text = Money.ToString();
    }

    public void incrementDefeated(){
        CountDefeated++;
    }

    public int GetDefeated(){
        return CountDefeated;
    }

    public void SetDefeated(int amount){
        CountDefeated = amount;
    }

    public double GetMaxHp(){
        return MaxHp;
    }

    public void doubleMaxHP(){
        MaxHp = (int)(MaxHp * 1.75);
    }

    public void incrementLvL(){
        LvL++;
    }

    public int GetLvL(){
        return LvL;
    }

    public void UpdateLvLText(){
        LvLText.text = LvL.ToString();
    }

    public void UpdateStageText(){
        StageText.text = CountDefeated.ToString();
    }

    public void UpdateMoneyText(){
        MoneyText.text = Money.ToString();
    }

    public void DoubleMoneyToGive(){
        MoneyToGive = MoneyToGive * 2;
    }

    public int GetMoneyToGive(){
        return MoneyToGive;
    }

    public double GetBossHP(){
        return BossHP;
    }

    public void DoubleBossHP(){
        if (LvL == 10 || LvL == 20 || LvL == 30 || LvL == 40){
            BossHP = (int)(BossHP * 2);
        }
        BossHP = (int)(BossHP * 1.4);
    }

    public void DoubleBossMoneyToGive(){
        BossMoneyToGive = (int)(BossMoneyToGive * 2);
    }

    public int GetBossMoneyToGive(){
        return BossMoneyToGive;
    }

    public void IncrementAutoClicker1Damage(){
        AutoClicker1Damage++;
    }

    public double getAutoClicker1Damage(){
        return (int)AutoClicker1Damage;
    }

    public void IncrementAutoClicker2Damage(){
        AutoClicker2Damage += 10;
    }

    public double getAutoClicker2Damage(){
        return (int)AutoClicker2Damage;
    }

    public void DoubleAutoClicker1Damage(){
        AutoClicker1Damage = (int)(AutoClicker1Damage * 2);
    }  

    public void DoubleAutpClicker2Damage(){
        AutoClicker2Damage = (int)(AutoClicker2Damage * 2);
    }

    public void ResetGameManager(){
        Money = 0;
        ClickPower = 1;
        CountDefeated = 1;
        MaxHp = 10;
        LvL = 1;
        MoneyToGive = 10;
        BossHP = 100;
        BossMoneyToGive = 100;
        AutoClicker1Damage = 0;
        AutoClicker2Damage = 0;
        UpdateLvLText();
        UpdateStageText();
        UpdateMoneyText();
    }
}
