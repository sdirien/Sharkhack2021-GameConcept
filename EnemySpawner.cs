using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //The prefab enemy sprite
    public GameObject enemyPrefab;
    //An empty Vector3 to contain a randomly generated location for enemies to spawn in
    private Vector3 spawnPosition;

    //The time between enemy spawns
    public int startSpawnTime = 6;
    //The number of enemies to spawn at the start of the game
    public int startSpawnNum;

    // Start is called before the first frame update
    void Start()
    {
        //Spawn initial enemies
        StartCoroutine(Spawn(startSpawnTime, startSpawnNum, 5, 1, 5f, 1f, 5f));
    }

    //Spawns enemies with seconds seconds between enemies, and spawnNum number of enemies
    IEnumerator Spawn(int seconds, int spawnNum, int hp, int dmg, float spd, float shootTime, float shootSpeed)
    {
        for (int i = 0; i < spawnNum; i++)
        {
            //generate random position for enemy to spawn at
            spawnPosition.x = Random.Range(-10, 10);
            spawnPosition.y = Random.Range(-5, 5);
            spawnPosition.z = 0;

            //create new enemy
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemy.GetComponent<EnemyHandler>().baseHealth = hp;
            enemy.GetComponent<EnemyHandler>().damage = dmg;
            enemy.GetComponent<EnemyHandler>().speed = spd;
            enemy.GetComponent<EnemyHandler>().shootTime = shootTime;
            enemy.GetComponent<EnemyHandler>().shootSpeed = shootSpeed;
            yield return new WaitForSeconds(seconds); //waits seconds seconds per spawn
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
