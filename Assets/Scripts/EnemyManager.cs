using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject [] EnemyPrefabs;

    public Enemy CurEnemy;

    public Transform canvas;

    public static EnemyManager instance;

    void Awake() {
        instance = this;
    }

    // Spawn Enemy
    public void SpawnEnemy(){
        GameObject EnemyToSpawn = EnemyPrefabs[Random.Range(0, EnemyPrefabs.Length)];
        GameObject obj = Instantiate(EnemyToSpawn, canvas);

        CurEnemy = obj.GetComponent<Enemy>();
    }
    // Replace Enemy
    public void ReplaceEnemy(GameObject Enemy){
        Destroy(CurEnemy);
        SpawnEnemy();
    }
}
