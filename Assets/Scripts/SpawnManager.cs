using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    //Time specific
    private float _respawnTimeEnemy;
    private float _respawnRateEnemy;
    private float _spawnRateHealth = 10;
    private float _spawnTimeHealth;

    //Component related
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject healthPack;


    void Start()
    {
        _spawnTimeHealth = 15;
        _respawnTimeEnemy = 3;
        transform.position = new Vector2(0, 5.5f);
    }

    void Update()
    {
        EnemySpawn();
        HealthSpawn();

    }

    public void EnemySpawn()
    {
        
        if(Time.time > _respawnTimeEnemy)
        {
            transform.position = new Vector2(Random.Range(-7, 7), transform.position.y);
            Instantiate(enemy, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            _respawnRateEnemy = Random.Range(2, 4);
            _respawnTimeEnemy = Time.time + _respawnRateEnemy;
        }
    }

    public void HealthSpawn()
    {
        if(Time.time > _spawnTimeHealth)
        {
            Instantiate(healthPack, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            _spawnRateHealth = Random.Range(20, 40);
            _spawnTimeHealth = Time.time + _spawnRateHealth;
            
            
        }
        
    }
}
