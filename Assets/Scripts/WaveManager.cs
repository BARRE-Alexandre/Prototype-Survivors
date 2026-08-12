using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject[] enemiesList;
    private readonly float xBounds = 30.0f;
    private readonly float zBounds = 30.0f;
    private float spawnRate = 2.0f;
    private int waveNumber = 1;
    private bool spawningWave = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemyWave());
    }

    // Update is called once per frame
    void Update()
    {
        int enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemiesLeft == 0 && !spawningWave)
        {
            waveNumber++;
            StartCoroutine(SpawnEnemyWave());
        }
    }
    private IEnumerator SpawnEnemyWave()
    {
        spawningWave = true;

        int enemiesToSpawn = 10*waveNumber;

        for(int i = 0; i < enemiesToSpawn; i++)
        {
            SpawnManager();
            yield return new WaitForSeconds(spawnRate);
        }
    
        spawningWave = false;
    }
    private void SpawnManager()
    {
        int enemyIndex = Random.Range(0, enemiesList.Length);
        Vector3 randomSpawnPos = new Vector3(Random.Range(-xBounds, xBounds), 1, Random.Range(-zBounds, zBounds));
        Instantiate(enemiesList[enemyIndex], randomSpawnPos, enemiesList[enemyIndex].transform.rotation);
    }
}
