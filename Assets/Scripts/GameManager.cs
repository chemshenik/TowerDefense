using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text coins;
    public Text Wave;
    public Text duration;
    public GameObject player;

    public Transform SpawnPoint;

    public Wave[] waves;

    int indexWave;
    Wave currentWave;

    float spawnCooldown;

    float durationWave;

    bool End = false;
    // Start is called before the first frame update
    void Start()
    {
        indexWave = 1;
        StartWave(indexWave - 1);
        coins.text = Getcoins().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (End)
            return;
        spawnCooldown -= Time.deltaTime;
        if (spawnCooldown <= 0)
                SpawnEnemy();
        durationWave -= Time.deltaTime;
        UpdateUI();
        if (durationWave <= 0)
        {
            if (indexWave != waves.Length)
                StartNextWave();
            else
                End = true;
        }
    }

    public void UpdateUI() {
        duration.text = durationWave.ToString();
        Wave.text = indexWave.ToString();
    }

    public void AddCoins(int count) {
        player.GetComponent<Player>().gold += count;
        coins.text = Getcoins().ToString();
    }
    public void RemoveCoins(int count) {
        player.GetComponent<Player>().gold -= count;
        coins.text = Getcoins().ToString();
    }
    public int Getcoins() {
        return player.GetComponent<Player>().gold;
    }
    public void StartNextWave()
    {
        indexWave++;
        currentWave = waves[indexWave-1];
        durationWave = currentWave.duration;
        SpawnEnemy();
    }
    public void StartWave(int index) {
        currentWave = waves[index];
        durationWave = currentWave.duration;
        SpawnEnemy();
    }
    public void SpawnEnemy() {
        GameObject temp = (GameObject)Instantiate(currentWave.enemyPrefab, SpawnPoint.position, currentWave.enemyPrefab.transform.rotation);
        temp.GetComponent<EnemyStats>().UpdateStats(currentWave.enemies[Random.Range(0, currentWave.enemies.Length)]);
        spawnCooldown = currentWave.spawnInterval;
    }
}
