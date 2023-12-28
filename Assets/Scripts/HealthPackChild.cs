using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class HealthPackChild : MonoBehaviour
{
    public AudioSource healthEffect;
    public bool alreadyPlayed;

    public void Update()
    {
        
        if(!transform.parent)
        {
            if (!alreadyPlayed)
            {
                
                healthEffect.Play();
                alreadyPlayed = true;
            }
            Destroy(this.gameObject, 3);
        }
        
    }
}
