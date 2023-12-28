using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthPack : MonoBehaviour
{

    private readonly float _fallSpeed = 2.0f;
    public HealthPackChild healthPackChild;
    public GameObject healthEffect;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, -1 * _fallSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            healthPackChild.transform.SetParent(null);
            Destroy(this.GameObject(), 0.1f);
            Instantiate(healthEffect, other.transform.position, Quaternion.identity);
        }
    }
}
