using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private IslandPackageManager islandPackageManager;
    void Start()
    {
        islandPackageManager = FindObjectOfType<IslandPackageManager>();
    }
    public void SpawnNewEnemy()
    {
        if (PlayerPrefs.GetString("CurrentShift") == "Day")
        {
            Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)],
                islandPackageManager.islands[Random.Range(0,
                islandPackageManager.islands.Count)].transform.position + new Vector3(0, 5),
                Quaternion.identity);
        }
        else
        {
            int randomChance = Random.Range(1, 3);

            for (int i = 0; i < randomChance; i++)
            {
                Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)],
                    islandPackageManager.islands[Random.Range(0,
                    islandPackageManager.islands.Count)].transform.position + new Vector3(Random.Range(-3f, 3f), 5),
                    Quaternion.identity);
            }
        }
    }
}
