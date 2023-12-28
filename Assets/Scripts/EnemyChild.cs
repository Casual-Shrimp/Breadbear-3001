using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyChild : MonoBehaviour
{
    public AudioSource explosion;
    public bool alreadyPlayed;

    private void Update()
    {
        
            if(!transform.parent)
            {
                if (!alreadyPlayed)
                {
                    explosion.Play();
                    alreadyPlayed = true;
                }
                Destroy(this.GameObject(), 3);
            }
        
    }

}
