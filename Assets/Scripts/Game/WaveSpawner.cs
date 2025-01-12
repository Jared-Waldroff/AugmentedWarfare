using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float timeBetweenWaves = 5f;

    private int waveNumber = 1;
    private bool spawningWave = false;

    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        while (true)
        {
            if (!spawningWave)
            {
                spawningWave = true;

                for (int i = 0; i < waveNumber; i++)
                {
                    SpawnEnemy();
                    yield return new WaitForSeconds(1f); // Delay between enemies in the same wave
                }

                waveNumber++;
                spawningWave = false;
                yield return new WaitForSeconds(timeBetweenWaves); // Delay before the next wave
            }
            else
            {
                yield return null;
            }
        }
    }

    void SpawnEnemy()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}