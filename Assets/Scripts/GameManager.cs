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
    public GameObject GeneralText;
    
    private int CountDefeated = 1;
    private int LvL = 1;
    public TextMeshProUGUI StageText;
    public TextMeshProUGUI LvLText;
    public GameObject DisplayText;

    private double MaxHp = 10;
    private int MoneyToGive = 10;
    private double BossHP = 100;
    private int BossMoneyToGive = 100;
    
    public double ClickPower = 1;
    private double AutoClicker1Damage = 0;
    private double AutoClicker2Damage = 0;

    public SaveData saveData;
    public SaveManager saveManager = SaveManager.instance;
    public GameObject LoadButton;
    public GameObject NewGameButton;
    public GameObject SaveButton;

    private void Start() {
        GeneralText.SetActive(false);
        SaveButton.SetActive(false);
    }

    public void SaveGame(){
        saveData.CopyData();
        SaveManager.instance.SaveGame(saveData);
    }

    public void LoadGame(){
        SaveData loadedData = SaveManager.instance.LoadGame();
        saveData.CopyFrom(loadedData);
        SetGame(saveData);
        LoadButton.SetActive(false);
        SaveButton.SetActive(true);
    }

    private void Update() {
        if(EnemyManager.instance.GetIsDead() == true){
            SaveGame();
        }
    }
    void Awake() {
        instance = this;
        saveData = new SaveData();
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

    public void SetLvL(int amount){
        LvL = amount;
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

    public void SetMoneyToGive(int amount){
        MoneyToGive = amount;
    }

    public double GetBossHP(){
        return BossHP;
    }

    public void SetBossHP(double amount){
        BossHP = amount;
    }

    public void SetMaxHp(double amount){
        MaxHp = amount;
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

    public void SetBossMoneyToGive(int amount){
        BossMoneyToGive = amount;
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

    public void SetPlayerDamage(double amount){
        ClickPower = amount;
    }

    public void SetAutoClicker1Damage(double amount){
        AutoClicker1Damage = amount;
    }

    public void SetAutoClicker2Damage(double amount){
        AutoClicker2Damage = amount;
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

        public void SetGame(SaveData save){
        SetLvL(save.GetLvL());
        SetDefeated(save.GetDefeated());

        Money = save.GetMoney();
        ClickManager.instance.SetPlayerDamagePrice(save.GetPlayerDamagePrice());
        ClickManager.instance.SetPlayerPurchased(save.GetPlayerPurchased());

        ClickManager.instance.SetAutoClicker1Price(save.GetAutoClicker1Price());
        ClickManager.instance.SetAutoClicker1purchases(save.GetAutoClicker1purchases());

        ClickManager.instance.SetAutoClicker2Price(save.GetAutoClicker2Price());
        ClickManager.instance.SetAutoClicker2purchases(save.GetAutpClicker2purchases());

        RebirthManager.instance.SetRebirthCount(save.GetRebirthCount());

        GeneralText.SetActive(true);

        SetPlayerDamage(save.GetClickPower());
        SetAutoClicker1Damage(save.GetAutoClicker1Damage());
        SetAutoClicker2Damage(save.GetAutoClicker2Damage());

        SetMaxHp(save.GetMaxHp());
        SetMoneyToGive(save.GetMoneyToGive());
        SetBossHP(save.GetBossHP());
        SetBossMoneyToGive(save.GetBossMoneyToGive());

        UpdateLvLText();
        UpdateStageText();
        UpdateMoneyText();

        ClickManager.instance.UpdateDpsText();
        ClickManager.instance.upadteShopText();

        NewGameButton.SetActive(false);
        LoadButton.SetActive(false);
        TextManager.instance.TextBox.SetActive(false);
        ClickManager.instance.PlayerButton.SetActive(true);
        
        TextManager.instance.fillText();
    }

    public void NewGame(){
        TextManager.instance.fillText();
        TextManager.instance.showText(0);
        NewGameButton.SetActive(false);
        LoadButton.SetActive(false);
    }
}
