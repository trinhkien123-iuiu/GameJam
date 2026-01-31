using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform player;
    public float minSpawnDistance = 10f;
    public float spawnRange = 10f;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);

            Vector3 spawnPosition;
            int safety = 0;

            do
            {
                spawnPosition = new Vector3(
                    Random.Range(-spawnRange, spawnRange),
                    Random.Range(-spawnRange, spawnRange),
                    0
                );
                safety++;
            }
            while (Vector3.Distance(spawnPosition, player.position) < minSpawnDistance
                   && safety < 20); // tránh loop vô hạn

            Instantiate(enemyPrefabs[enemyIndex], spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }
}
