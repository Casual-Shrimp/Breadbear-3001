using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //Just Variables
    public float health = 10.0f;
    readonly float _fallSpeed = 1.0f;

    //Time specific variables
    private float _currentTime;
    private float _downTime;
    readonly float _fireRate = 1.7f;
    private float _allowedFire;

    //Game Component specific
    private Rigidbody2D _rb;
    [SerializeField] private GameObject bullet;
    public AudioSource hit;
    private Transform _trans;
    public EnemyChild enemyChild;
    public GameObject explosionParticle;
    



    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _trans = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        EnemyAI();
        Death();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            hit.Play();
            Destroy(other.gameObject);
            health = --health;
            Debug.Log(health);
        }

        if (other.CompareTag("Player"))
        {
            enemyChild.transform.SetParent(null);
            Instantiate(explosionParticle, transform.position, Quaternion.identity);
            Destroy(this.GameObject());
        }
    }

    private void EnemyAI()
    {
        _currentTime += Time.deltaTime;

        transform.Translate(new Vector2(0, -1 * Time.deltaTime * _fallSpeed));

        if (_currentTime > _downTime)
        {
            _rb.AddForce(new Vector2(Random.Range(1000, 1300) * (Random.Range(0, 2) * 2 - 1), 0) * Time.deltaTime);
            _rb.velocity = Vector2.zero;
            _downTime = Random.Range(1f, 3f);
            _currentTime = 0f;
        }

        if (transform.position.x < -8.5)
        {
            _rb.velocity = Vector2.zero;
            _trans.position = new Vector2(-8.5f, transform.position.y);

        }

        if (transform.position.x > 8.5)
        {
            _rb.velocity = Vector2.zero;
            _trans.position = new Vector2(8.5f, transform.position.y);
        }


        if (Time.time > _allowedFire)
        {
            Instantiate(bullet, new Vector2(transform.position.x, _trans.position.y), Quaternion.identity);
            _allowedFire = Time.time + _fireRate;
        }
    }

    public void Death()
    {
        if (health < 1)
        {
            enemyChild.transform.SetParent(null);
            Instantiate(explosionParticle, transform.position, Quaternion.identity);
            Destroy(this.GameObject());
        }
    }
}