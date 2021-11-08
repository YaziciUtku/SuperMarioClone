using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScript : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D spiderRB;
    private Vector3 moveDirection = Vector3.down;
    private string coroutine_Name = "ChangeSpiderDirection";


    private void Awake()
    {
        anim = GetComponent<Animator>();
        spiderRB = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        StartCoroutine(coroutine_Name);
    }


    void Update()
    {
        MoveSpider();
    }

    void MoveSpider()
    {
        transform.Translate(moveDirection * Time.smoothDeltaTime);
    }


    IEnumerator ChangeSpiderDirection()
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        if(moveDirection == Vector3.down)
        {
            moveDirection = Vector3.up;
        }
        else
        {
            moveDirection = Vector3.down;
        }
        StartCoroutine(coroutine_Name);
    }

    IEnumerator SpiderDead()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == MyTags.BULLET_TAG)
        {
            anim.Play("SpiderDead");
            spiderRB.bodyType = RigidbodyType2D.Dynamic;
            StartCoroutine(SpiderDead());
            StopCoroutine(coroutine_Name);
        }
        if(collision.tag == MyTags.PLAYER_TAG)
        {
            collision.gameObject.GetComponent<PlayerDamage>().DealDamageToPlayer();
        }
    }












}//CLASS
