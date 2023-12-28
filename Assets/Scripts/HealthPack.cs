using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{

    private readonly float _fallSpeed = 2.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, -1 * _fallSpeed *Time.deltaTime));
    }
}
