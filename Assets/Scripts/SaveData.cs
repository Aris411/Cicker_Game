using UnityEngine;

[System.Serializable]
public class SaveData
{
    public static SaveData instance;

    public int LVL;
    public int CountDefeated;
    
    public double Money;
    public double PlayerDamagePrice;
    public int PlayerPurchased;
    
    public double AutoClicker1Price;
    public int AutoClicker1purchases;

    public double AutoClicker2Price;
    public int AutpClicker2purchases;

    public int rebirthCount;

    public double ClickPower;
    public double AutoClicker1Damage;
    public double AutoClicker2Damage;

    public double MaxHp;
    public int MoneyToGive;
    public double BossHP;
    public int BossMoneyToGive;

    public void CopyData(){
        LVL = GameManager.instance.GetLvL();
        CountDefeated = GameManager.instance.GetDefeated();

        Money = GameManager.instance.Money;
        PlayerDamagePrice = ClickManager.instance.GetPlayerDamagePrice();
        PlayerPurchased = ClickManager.instance.GetPlayerPurchased();

        AutoClicker1Price = ClickManager.instance.GetAutoClicker1Price();
        AutoClicker1purchases = ClickManager.instance.GetAutoClicker1purchases();

        AutoClicker2Price = ClickManager.instance.GetAutoClicker2Price();
        AutpClicker2purchases = ClickManager.instance.GetAutpClicker2purchases();

        rebirthCount = RebirthManager.instance.GetRebirthCount();

        ClickPower = GameManager.instance.ClickPower;
        AutoClicker1Damage = GameManager.instance.getAutoClicker1Damage();
        AutoClicker2Damage = GameManager.instance.getAutoClicker2Damage();

        MaxHp = GameManager.instance.GetMaxHp();
        MoneyToGive = GameManager.instance.GetMoneyToGive();
        BossHP = GameManager.instance.GetBossHP();
        BossMoneyToGive = GameManager.instance.GetBossMoneyToGive();   
        Debug.Log("Data copied");
    }

    public void CopyFrom(SaveData other){
        LVL = other.LVL;
        CountDefeated = other.CountDefeated;

        Money = other.Money;
        PlayerDamagePrice = other.PlayerDamagePrice;
        PlayerPurchased = other.PlayerPurchased;

        AutoClicker1Price = other.AutoClicker1Price;
        AutoClicker1purchases = other.AutoClicker1purchases;

        AutoClicker2Price = other.AutoClicker2Price;
        AutpClicker2purchases = other.AutpClicker2purchases;

        rebirthCount = other.rebirthCount;

        ClickPower = other.ClickPower;
        AutoClicker1Damage = other.AutoClicker1Damage;
        AutoClicker2Damage = other.AutoClicker2Damage;

        MaxHp = other.MaxHp;
        MoneyToGive = other.MoneyToGive;
        BossHP = other.BossHP;
        BossMoneyToGive = other.BossMoneyToGive;   
    }

    public int GetLvL(){
        return LVL;
    }

    public int GetDefeated(){
        return CountDefeated;
    }

    public double GetMoney(){
        return Money;
    }

    public double GetPlayerDamagePrice(){
        return PlayerDamagePrice;
    }

    public int GetPlayerPurchased(){
        return PlayerPurchased;
    }

    public double GetAutoClicker1Price(){
        return AutoClicker1Price;
    }

    public int GetAutoClicker1purchases(){
        return AutoClicker1purchases;
    }
    
    public double GetAutoClicker2Price(){
        return AutoClicker2Price;
    }

    public int GetAutpClicker2purchases(){
        return AutpClicker2purchases;
    }

    public int GetRebirthCount(){
        return rebirthCount;
    }

    public double GetClickPower(){
        return ClickPower;
    }

    public double GetAutoClicker1Damage(){
        return AutoClicker1Damage;
    }

    public double GetAutoClicker2Damage(){
        return AutoClicker2Damage;
    }

    public double GetMaxHp(){
        return MaxHp;
    }

    public int GetMoneyToGive(){
        return MoneyToGive;
    }

    public double GetBossHP(){
        return BossHP;
    }

    public int GetBossMoneyToGive(){
        return BossMoneyToGive;
    }
}
