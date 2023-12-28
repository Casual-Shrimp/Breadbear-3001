using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaveExplode : MonoBehaviour
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
            
        }
        
    }
}

