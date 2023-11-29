using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    //Time specific
    private float _respawnTimeEnemy;
    private float _respawnRateEnemy = 3.6f;
    private float _spawnRateHealth = 10;
    private float _spawnTimeHealth;

    //Component related
    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private GameObject _healthPack;


    void Start()
    {
        transform.position = new Vector2(0, 5.5f);
    }

    void Update()
    {
        enemySpawn();
        healthSpawn();

    }

    void enemySpawn()
    {
        
        if(Time.time > _respawnTimeEnemy)
        {
            transform.position = new Vector2(Random.Range(-7, 7), transform.position.y);
            Instantiate(_enemy, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            _respawnTimeEnemy = Time.time + _respawnRateEnemy;
        }
    }

    void healthSpawn()
    {
        if(Time.time > _spawnTimeHealth)
        {
            Debug.Log("Object spawned");
            Debug.Log(_spawnRateHealth);
            Instantiate(_healthPack, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            _spawnRateHealth = Random.Range(10, 15);
            _spawnTimeHealth = Time.time + _spawnRateHealth;
            
            
        }
        
    }
}
