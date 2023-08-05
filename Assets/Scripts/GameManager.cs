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
    public int ClickPower = 1;
    private int CountDefeated = 1;
    private int MaxHp = 10;
    public TextMeshProUGUI LvLText;
    private int LvL = 1;
    public TextMeshProUGUI StageText;
    private int MoneyToGive = 10;
    private int BossHP = 100;
    private int BossMoneyToGive = 100;

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

    public int GetMaxHp(){
        return MaxHp;
    }

    public void doubleMaxHP(){
        MaxHp = MaxHp * 2;
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

    public int GetBossHP(){
        return BossHP;
    }

    public void DoubleBossHP(){
        BossHP = BossHP * 2;
    }

    public void DoubleBossMoneyToGive(){
        BossMoneyToGive = BossMoneyToGive * 2;
    }

    public int GetBossMoneyToGive(){
        return BossMoneyToGive;
    }
}
