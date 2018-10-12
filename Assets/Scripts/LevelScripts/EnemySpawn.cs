using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject enemy;
    public float enemyTimer = 2.0f;
    public int maxEnemies = 20;

    private float timeTillSpawn = 0f;
    private int enemyCount = 0;
	void Update ()
    {
        float updateTime = Time.deltaTime;
        timeTillSpawn += updateTime;
	    if(timeTillSpawn > enemyTimer)
        {
            GameObject newEnemy = Instantiate(enemy);
            newEnemy.transform.position = transform.position;
            enemyCount++;
            timeTillSpawn = 0;
        }
	}

    void EnemyDead()
    {
        enemyCount--;
    }
}
