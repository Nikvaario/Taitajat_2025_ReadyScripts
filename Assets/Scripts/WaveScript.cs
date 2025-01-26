using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    [SerializeField] private List<enemy> enemies; // List of enemies
    private List<GameObject> enemiesToSpawn = new List<GameObject>(); // Enemies to be spawned on wave

    public int waveValue; // How much enemies on wave in value
    public int currentWave; // Current wave
    private float spawnTimer = 0.1f; // How many seconds between spawning enemies

    // Function called when the first/next wave begins
    public void NextWave()
    {
        currentWave++;
        waveValue += 5;
        GenerateEnemies();
    }

    // Function called to decide what enemies are going to be spawned
    void GenerateEnemies()
    {
        while (waveValue > 0)
        {
            // Decide a random enemy
            enemy chosenEnemy = enemies[Random.Range(0, enemies.Count)];
            int chosenCost = chosenEnemy.cost;

            // If there is enough value left in wave, spawn enemy
            // When all value spent, stop generating enemies
            if (waveValue - chosenCost > 0) 
            {
                enemiesToSpawn.Add(chosenEnemy.enemyPrefab);
                waveValue -= chosenCost;
            }
            else if (waveValue <= 0)
            {
                break;
            }
        }

        SpawnEnemies();
    }

    // Function called to spawn all the decided enemies
    IEnumerable SpawnEnemies()
    {
        for (int i = 0; i < enemiesToSpawn.Count; i++)
        {
            Instantiate(enemiesToSpawn[i]);
            yield return new WaitForSeconds(spawnTimer);
        }
        enemiesToSpawn.Clear();
    }
}

[System.Serializable]

public class enemy
{
    public GameObject enemyPrefab;
    public int cost;
}
