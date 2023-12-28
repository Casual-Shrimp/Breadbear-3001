using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.UIElements;

public class DaveMove : MonoBehaviour
{

    //Just Variables
    readonly float _daveSpeed = 1000f;
    readonly float _maxSpeed = 50f; 
    [Range(0, 10)]readonly int _maxHealth = 10;
    private int _currentHealth;
    //Variables for game components 
    [SerializeField]
    private GameObject aubergine;
    [SerializeField]
    private GameObject hand;
    private Rigidbody2D _dave;
    public HealthBar healthBar;

    //Variables for Time
    private float _passedTime;
    public float fireRate = 0.13f;

    void Start()
    {
        transform.Rotate(0, 0, 0);
        transform.position = new Vector3(0,-4,0);
        _dave = GetComponent<Rigidbody2D>();
        if(_dave.velocity.x > _maxSpeed)
        {
            _dave.velocity = _dave.velocity.normalized * _maxSpeed;
        }
        _currentHealth = _maxHealth;
        healthBar.SetMaxHealth(_maxHealth);
    }

    void Update()
    {     
        DaveRotation();
        DaveShoot();
        DaveHealth();
    }
    private void FixedUpdate() 
    {
        DaveMoveSide();
    }

       private void DaveMoveSide()
    {

        if(Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow))
        {
            _dave.AddForce(new Vector2( -1 * _daveSpeed * Time.deltaTime, 0));
        }
        
        if(Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow))
        {
            _dave.AddForce(new Vector2( 1 * _daveSpeed * Time.deltaTime, 0));
        }   

        if (transform.position.x >= 8.5)
        {
            transform.position = new Vector3(8.5f, transform.position.y, 0);
            _dave.velocity = Vector3.zero;

        }
        else if (transform.position.x <=-8.5)
        {
            transform.position = new Vector3(-8.5f, transform.position.y, 0);
            _dave.velocity = Vector3.zero;
        }
    }
    
     
    private void DaveRotation()
    {
        if(Input.GetKeyDown(KeyCode.A) | Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, 0 + 45);
        }
        else if(Input.GetKeyDown(KeyCode.D) | Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, 0 -45);
        }

        if(Input.GetKeyUp(KeyCode.A) | Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, 0 -45);
        }
        else if(Input.GetKeyUp(KeyCode.D) | Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, 0 + 45);
        }
    }


    private void DaveShoot()
    {
        if(Input.GetKey(KeyCode.Space) && Time.time > _passedTime)
        {
            Instantiate(aubergine, new Vector2(hand.transform.position.x, hand.transform.position.y), Quaternion.identity);
            _passedTime = Time.time + fireRate;
        }

    }

    private void DaveHealth()
    {
        if(_currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy_Bullet"))
        {
            Destroy(other.gameObject);
            _currentHealth -= 1;
            healthBar.SetHealth(_currentHealth);
        }

        if(other.CompareTag("Enemy"))
        {
            _currentHealth -= 1;
            healthBar.SetHealth(_currentHealth);
        }

        if(other.CompareTag("HealthPack"))
        {
            _currentHealth += 3;
            healthBar.SetHealth(_currentHealth);
            Destroy(other.gameObject);
            
        }
    }

    
}
