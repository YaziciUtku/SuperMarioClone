using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggScript : MonoBehaviour
{
  
    void Start()
    {
        
    }

    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == MyTags.PLAYER_TAG)
        {
            // DAMAGE PLAYER
        }
        gameObject.SetActive(false);
    }














}// CLASS
