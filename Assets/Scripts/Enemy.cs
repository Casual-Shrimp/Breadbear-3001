using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    //Just Variables
    private float _health = 10.0f;
    private float _fallSpeed = 0.3f;

    //Time specific variables
    private float _currentTime;
    private float _downTime;
    private float _fireRate = 1.0f;
    private float _allowedFire;

    //Game Component specific
    private Rigidbody2D rb;
    [SerializeField] private GameObject _bullet;
    public AudioSource hit;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        enemyAI();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Bullet")
        {
            hit.Play();
            Destroy(other.gameObject);
            _health = _health -= 1.0f;
        }
    }

    void enemyAI()
    {
        _currentTime += Time.deltaTime;

        transform.Translate(Vector2.down * _fallSpeed *Time.deltaTime);

        if(_currentTime > _downTime)
        {
            rb.AddForce(new Vector2(Random.Range(1000,1300) * (Random.Range(0,2)*2-1), 0) * Time.deltaTime);
            rb.velocity = Vector2.zero;
            _downTime = Random.Range(1f, 3f);
            _currentTime = 0f;
        }

        if(transform.position.x < -8.5)
        {
            rb.velocity = Vector2.zero;
            transform.position = new Vector2(-8.5f, transform.position.y);
            
        }
        if(transform.position.x > 8.5 )
        {
            rb.velocity = Vector2.zero;
            transform.position = new Vector2(8.5f, transform.position.y);
        }


        if(Time.time > _allowedFire)
        {
            Instantiate(_bullet, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            _allowedFire = Time.time + _fireRate;
        }


                  if(_health < 1)
        {   
            Destroy(this.gameObject);
        }
    }

   
}
