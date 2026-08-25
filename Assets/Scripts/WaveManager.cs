using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject[] enemiesList;
    public GameObject bossPrefab;
    private readonly float xBounds = 30.0f;
    private readonly float zBounds = 30.0f;
    private float spawnRate = 1.0f;
    public int waveNumber = 1;
    private bool spawningWave = false;
    // ENCAPSULATION
    public int EnemiesLeft
    {
        get; private set;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemyWave());
    }

    // Update is called once per frame
    void Update()
    {
        EnemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (EnemiesLeft == 0 && !spawningWave)
        {
            waveNumber++;
            StartCoroutine(SpawnEnemyWave());
        }
    }
    private IEnumerator SpawnEnemyWave()
    {
        spawningWave = true;

        if (waveNumber % 5 == 0)
        {
            SpawnBoss();
        }

        int enemiesToSpawn = 3*waveNumber;

        for(int i = 0; i < enemiesToSpawn; i++)
        {
            SpawnManager();
            yield return new WaitForSeconds(spawnRate);
        }
    
        spawningWave = false;
    }
    // ABSTRACTION
    private void SpawnManager()
    {
        int enemyIndex = Random.Range(0, enemiesList.Length);
        Vector3 randomSpawnPos = new Vector3(Random.Range(-xBounds, xBounds), 0.2f, Random.Range(-zBounds, zBounds));
        Instantiate(enemiesList[enemyIndex], randomSpawnPos, enemiesList[enemyIndex].transform.rotation);
    }
// ABSTRACTION
    private void SpawnBoss()
    {
        Instantiate(bossPrefab, new Vector3(0,0.5f,0), bossPrefab.transform.rotation);
    }
}
