using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.UIElements;

public class Dave_Move : MonoBehaviour
{

    //Just Variables
    private float _daveSpeed = 1000f;
    private float _maxSpeed = 50f; 
    [SerializeField]
    [Range(0, 10)]private int _health = 10;
    //Variables for game components 
    [SerializeField]
    private GameObject _Aubergine;
    [SerializeField]
    private GameObject _Hand;
    private Rigidbody2D _Dave;

    //Variables for Time
    private float _passedTime = 0f;
    private float _fireRate = 0.13f;

    void Start()
    {
        transform.Rotate(0, 0, 0);
        transform.position = new Vector3(0,-4,0);
        _Dave = GetComponent<Rigidbody2D>();
        if(_Dave.velocity.x > _maxSpeed)
        {
            _Dave.velocity = _Dave.velocity.normalized * _maxSpeed;
        }
    }

    void Update()
    {     
        daveRotation();
        daveShoot();
        daveHealth();
    }
    private void FixedUpdate() 
    {
        daveMoveSide();
        daveMoveUp();
    }

    void daveMoveSide()
    {

        if(Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow))
        {
            _Dave.AddForce(Vector2.left * _daveSpeed * Time.deltaTime);
        }
        
        if(Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow))
        {
            _Dave.AddForce(Vector2.right * _daveSpeed * Time.deltaTime);
        }   

        if (transform.position.x >= 8.5)
        {
            transform.position = new Vector3(8.5f, transform.position.y, 0);
            _Dave.velocity = Vector3.zero;

        }
        else if (transform.position.x <=-8.5)
        {
            transform.position = new Vector3(-8.5f, transform.position.y, 0);
            _Dave.velocity = Vector3.zero;
        }
    }
        
    void daveMoveUp()
    {
         if(Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.UpArrow))
        {
            _Dave.AddForce(Vector2.up * _daveSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.DownArrow))
        {
            _Dave.AddForce(Vector2.down * _daveSpeed * Time.deltaTime);
        }
    }
     
    void daveRotation()
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


    void daveShoot()
    {
        if(Input.GetKey(KeyCode.Space) && Time.time > _passedTime)
        {
            Instantiate(_Aubergine, new Vector2(_Hand.transform.position.x, _Hand.transform.position.y), Quaternion.identity);
            _passedTime = Time.time + _fireRate;
        }

    }

    void daveHealth()
    {
        if(_health < 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy_Bullet")
        {
            Destroy(other.gameObject);
            _health -= 1;
        }

        if(other.tag == "Enemy")
        {
            _health -= 1;
            Destroy(other.gameObject);
        }

        if(other.tag == "HealthPack")
        {
            _health += 3;
            Destroy(other.gameObject);
        }
    }

    
}
