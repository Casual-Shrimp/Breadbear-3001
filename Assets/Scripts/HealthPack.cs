using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{

    private float _fallSpeed = 2.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * _fallSpeed *Time.deltaTime);
    }
}
