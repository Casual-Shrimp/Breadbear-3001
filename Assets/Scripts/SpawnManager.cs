using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    //Time specific
    private float _respawnTime;
    private float _respawnRate = 3.6f;

    //Component related
    [SerializeField]
    private GameObject _enemy;


    void Start()
    {
        transform.position = new Vector2(0, 5.5f);
    }

    void Update()
    {
        if(Time.time > _respawnTime)
        {
            transform.position = new Vector2(Random.Range(-7, 7), transform.position.y);
            Instantiate(_enemy, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            _respawnTime = Time.time + _respawnRate;
        }

    }
}
