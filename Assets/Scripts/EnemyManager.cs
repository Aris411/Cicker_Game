using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyManager : MonoBehaviour
{
    public GameObject [] EnemyPrefabsLvL1;
    public GameObject [] EnemyPrefabsLvL5;

    public GameObject [] BossPrefabs;

    public Enemy CurEnemy;

    public Transform canvas;

    public static EnemyManager instance;
    
    public Image BossTimerFill;
    public TextMeshProUGUI BossTimerText;
    private float maxBossTimer = 30.0f;
    private float currentBossTimer;
    private bool isBossTimerActive = false;

    void Start()
    {
        SpawnEnemy();
    }
    void Awake() {
        instance = this;
    }

    void Update(){
         if (isBossTimerActive)
    {
        currentBossTimer -= Time.deltaTime;

        
        // Update the boss timer bar fill amount
        BossTimerFill.fillAmount = currentBossTimer / maxBossTimer;

        // Update the boss timer text
        BossTimerText.text = Mathf.Ceil(currentBossTimer).ToString();

        if (currentBossTimer <= 0.0f)
        {
            // Boss timer has expired, reset variables
            isBossTimerActive = false;
            currentBossTimer = 0.0f;
            BossTimerFill.gameObject.SetActive(false);
            BossTimerText.gameObject.SetActive(false); 

            // Spawn a new enemy when the boss timer expires
            GameManager.instance.SetDefeated(1);
            GameManager.instance.UpdateStageText();
            ReplaceEnemy(CurEnemy.gameObject);
        }
    }
    }
    // Spawn Enemy
    public void SpawnEnemy(){
        if (GameManager.instance.GetDefeated() == 10) {
            GameObject BossToSpawn = BossPrefabs[Random.Range(0, BossPrefabs.Length)];
            GameObject obj = Instantiate(BossToSpawn, canvas);
            CurEnemy = obj.GetComponent<Enemy>();

            //start boss timer
            BossTimerFill.gameObject.SetActive(true);
            BossTimerText.gameObject.SetActive(true);
            currentBossTimer = maxBossTimer;
            isBossTimerActive = true;
        } 
        if (GameManager.instance.GetLvL() <= 4 && GameManager.instance.GetDefeated() < 10){
            GameObject EnemyToSpawn = EnemyPrefabsLvL1[Random.Range(0, EnemyPrefabsLvL1.Length)];
            GameObject obj = Instantiate(EnemyToSpawn, canvas);
            CurEnemy = obj.GetComponent<Enemy>();

            BossTimerFill.gameObject.SetActive(false);
            BossTimerText.gameObject.SetActive(false);
        }
        if (GameManager.instance.GetLvL() >= 5 && GameManager.instance.GetDefeated() < 10) {
            GameObject EnemyToSpawn = EnemyPrefabsLvL5[Random.Range(0, EnemyPrefabsLvL5.Length)];
            GameObject obj = Instantiate(EnemyToSpawn, canvas);
            CurEnemy = obj.GetComponent<Enemy>();

            BossTimerFill.gameObject.SetActive(false);
            BossTimerText.gameObject.SetActive(false);
        }
    }
    // Replace Enemy
    public void ReplaceEnemy(GameObject Enemy){
        Destroy(Enemy);
        SpawnEnemy();
    }

}
