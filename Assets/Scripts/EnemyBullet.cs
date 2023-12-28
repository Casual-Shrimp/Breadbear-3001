using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    void Start()
    {
        transform.Rotate(new Vector3(0, 0, 180));
    }

    private readonly float _bulletSpeed = -10.0f;
    
    void Update()
    {
       transform.Translate(new Vector2(0 , -1  * _bulletSpeed * Time.deltaTime)); 

       if(transform.position.y < -7)
       {
        Destroy(this.gameObject);
       }
    }
}
