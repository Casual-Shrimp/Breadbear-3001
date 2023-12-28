using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aubergine : MonoBehaviour
{
    private readonly float _aubergineSpeed = 8.0f;
    public GameObject impact;
    
    void Update()
    {
       transform.Translate(new Vector3(0, 1 * _aubergineSpeed * Time.deltaTime,  0));

        if(transform.position.y > 6)
        {
            Destroy(this.gameObject);
        }       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            Instantiate(impact, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    
}
