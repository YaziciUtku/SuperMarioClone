using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScripts : MonoBehaviour
{
    private Rigidbody2D stoneRB;
    private PlayerDamage playerDamage;

    private void Awake()
    {
        stoneRB = GetComponent<Rigidbody2D>();
        playerDamage=GameObject.Find("Player").GetComponent<PlayerDamage>();
    }

    void Start()
    {
        Invoke("DeleteRock", 5f);
        stoneRB.AddForce(new Vector2(Random.Range(-700,-300), stoneRB.velocity.y));
    }

    
    void Update()
    {
        
    }

    void DeleteRock()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == MyTags.PLAYER_TAG)
        {
            gameObject.SetActive(false);
            playerDamage.DealDamageToPlayer();
        }
    }
}
