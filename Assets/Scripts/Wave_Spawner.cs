
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wave_Spawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform[] enemyPrefabs;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5.5f;
    private float coutdown = 2f;

    public Text waveCountdownText;
    public Text currentWaveText;

    GameObject[] enemies;

    private int waveIndex = 0;
    
    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Trigger Next Wave
        if (enemies.Length <=0 && coutdown <= 0f)
        {
            coutdown = timeBetweenWaves;
            StartCoroutine(SpawnWave());
        }
        //if (coutdown <= 0f)
        //{
        //    StartCoroutine(SpawnWave());
        //    coutdown = timeBetweenWaves; // reset countdown in preparation for next wave
        //}

        // Countdown to Next wave 
        if(enemies.Length <= 0)
        { 
            coutdown -= Time.deltaTime; // countodwn-- once every second
            waveCountdownText.text = "Next Wave:" + Mathf.Round(coutdown).ToString();
        }
    }

    IEnumerator SpawnWave ()
    {
        waveIndex++;
        currentWaveText.text = "Wave: " + Mathf.Round(waveIndex).ToString();
        //  Debug.Log("Spawn Wave");

        // Create 1 enemyPrefab untill loop ends, curently 20mob per wave
        for (int i = 0; i < 20; i++) 
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        if(waveIndex > enemyPrefabs.Length)
        {
            Debug.Log("GAME OVER YOU WIN");
            Time.timeScale = 0;
        }
        else
        { 
        Instantiate(enemyPrefabs[waveIndex], spawnPoint.position, spawnPoint.rotation);
        }
    }
}
