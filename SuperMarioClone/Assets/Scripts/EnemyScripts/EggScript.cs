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
            collision.gameObject.GetComponent<PlayerDamage>().DealDamageToPlayer();
        }
        gameObject.SetActive(false);
    }














}// CLASS
