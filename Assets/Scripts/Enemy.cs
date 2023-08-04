using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int curHp;
    public int MaxHp;
    public int MoneyToGive;
    public Image HealthbarFill;

    public void DamageAuto() {
        curHp--;
        HealthbarFill.fillAmount = (float)curHp / (float)MaxHp;

        if (curHp <= 0) {
            Defeated();
        }
    }

    public void Damage(){
        curHp -= GameManager.instance.ClickPower;
        HealthbarFill.fillAmount = (float)curHp / (float)MaxHp;

        if (curHp <= 0) {
            Defeated();
        }
    }

    public void Defeated(){
        GameManager.instance.AddMoney(MoneyToGive);
        EnemyManager.instance.ReplaceEnemy(gameObject);
    }
}
