using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aubergine : MonoBehaviour
{
    private float _aubergineSpeed = 10.0f;
    
    void Update()
    {
       transform.Translate(Vector3.up * _aubergineSpeed * Time.deltaTime);

        if(transform.position.y > 6)
        {
            Destroy(this.gameObject);
        }       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
                if(other.tag == "Enemy")
        {
                Destroy(this.gameObject);
        }
    }
    
}
