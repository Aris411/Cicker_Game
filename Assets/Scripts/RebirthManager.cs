using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebirthManager : MonoBehaviour
{
    private int rebirthCount = 0;

    public static RebirthManager instance;

    void Update()
    {
        if (GameManager.instance.GetLvL() == 11 && rebirthCount == 0)
        {
            Rebirth();
        }
        if (GameManager.instance.GetLvL() == 21 && rebirthCount == 1)
        {
            Rebirth();
        }
        if (GameManager.instance.GetLvL() == 31 && rebirthCount == 2)
        {
            Rebirth();
        }
        if (GameManager.instance.GetLvL() == 41 && rebirthCount == 3)
        {
            Rebirth();
        }
    }

    void Awake()
    {
        instance = this;
    }

    public void Rebirth()
    {  
        GameObject currentEnemy = EnemyManager.instance.GetEnemy();
        if (currentEnemy != null)
        {
            Destroy(currentEnemy);
        }
        rebirthCount++;
        Debug.Log("Rebirth Count: " + rebirthCount);
        ClickManager.instance.ResetClickManager();
        GameManager.instance.ResetGameManager();
        TextManager.instance.showText(rebirthCount);
        ClickManager.instance.hidePlayerButton();
        //EnemyManager.instance.SpawnEnemy();
    }

    public int GetRebirthCount()
    {
        return rebirthCount;
    }

    // Rebirth 1 = 2x Click Damage
    // Rebirth 2 = 0.5x Clicker Damage Price   
    // Rebirth 3 = 2x Auto Clicker Damage
    // Rebirth 4 = 0.5x Auto Clicker Damage Price
}
