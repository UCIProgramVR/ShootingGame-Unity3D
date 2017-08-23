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

    public ArrayList spawnTargetNomiatedPlaces = new ArrayList();

    void Start()
    {
        spawnTargetNomiatedPlaces.Add(GameObject.FindGameObjectWithTag("SpawnPlace1").transform.position);
        spawnTargetNomiatedPlaces.Add(GameObject.FindGameObjectWithTag("SpawnPlace2").transform.position);
        spawnTargetNomiatedPlaces.Add(GameObject.FindGameObjectWithTag("SpawnPlace3").transform.position);
        spawnTargetNomiatedPlaces.Add(GameObject.FindGameObjectWithTag("SpawnPlace4").transform.position);

        NextWave();
    }

    private void Update()
    {
        if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime) {
            enemiesRemainingToSpawn--;
            nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;

            EnemyController spawnedEnemy = Instantiate(enemy, (UnityEngine.Vector3)spawnTargetNomiatedPlaces[Random.Range(0, 3)], Quaternion.identity) as EnemyController;
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
