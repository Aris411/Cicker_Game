using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
  
    public double Money;
    public TextMeshProUGUI MoneyText;
    public static GameManager instance;
    public double ClickPower = 1;
    private int CountDefeated = 1;
    private double MaxHp = 10;
    public TextMeshProUGUI LvLText;
    private int LvL = 1;
    public TextMeshProUGUI StageText;
    private int MoneyToGive = 10;
    private double BossHP = 100;
    private int BossMoneyToGive = 100;
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
        MaxHp = (int)(MaxHp * 1.5);
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
        BossHP = (int)(BossHP * 1.75);
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
}
