using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{

    private float _bulletSpeed = 10.0f;
    
    void Update()
    {
       transform.Translate(Vector2.down * _bulletSpeed * Time.deltaTime); 

       if(transform.position.y < -7)
       {
        Destroy(this.gameObject);
       }
    }
}
