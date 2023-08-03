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

    public void Damage() {
        curHp--;
        HealthbarFill.fillAmount = (float)curHp / (float)MaxHp;

        if (curHp <= 0) {
            Defeated();
        }
    }

    public void Defeated(){
        //Add Money
        GameManager.instance.AddMoney(MoneyToGive);
        //Remove Enemy
        EnemyManager.instance.ReplaceEnemy(gameObject);
    }
}
