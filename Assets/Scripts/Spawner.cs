using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Wave[] waves;
    public EnemyController enemy;

    int enemiesRemainingToSpawn;
    float nextSpawnTime;

    int currentWaveNumber;
    Wave currentWave;

    private void Start()
    {
        NextWave();
    }

    private void Update()
    {
        if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime) {
            enemiesRemainingToSpawn--;
            nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;

            EnemyController spawnedEnemy = Instantiate(enemy, Vector3.zero, Quaternion.identity) as EnemyController;
        }
    }

    void NextWave() {
        currentWaveNumber++;
        currentWave = waves[currentWaveNumber - 1];
        enemiesRemainingToSpawn = currentWave.enemyCount;
    }

    [System.Serializable]
    public class Wave {
        public int enemyCount;
        public float timeBetweenSpawns;
    }

}
