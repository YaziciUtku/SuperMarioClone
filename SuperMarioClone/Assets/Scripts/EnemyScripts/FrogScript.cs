using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D frogRB;
    private bool animation_Started, animation_Finished;
    private int jumpedTimes;
    private bool jumpLeft = true;
    private string coroutine_Name = "FrogJump";
    PlayerDamage playerDamage;
    public LayerMask playerLayer;
    private void Awake()
    {
        playerDamage = GameObject.Find("Player").GetComponent<PlayerDamage>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        StartCoroutine(coroutine_Name);
    }
    private void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.5f, playerLayer))
        {
            playerDamage.DealDamageToPlayer();
        }
    }

    void LateUpdate()
    {
        if(animation_Finished && animation_Started)
        {
            animation_Started = false;
            transform.parent.position = transform.position;
            transform.localPosition = Vector3.zero;
        }
    }

    IEnumerator FrogJump()
    {
        yield return new WaitForSeconds(Random.Range(1f, 4f));
        animation_Started = true;
        animation_Finished = false;

        jumpedTimes++;

        if (jumpLeft)
        {
            anim.Play("FrogJumpLeft");
        }
        else
        {
            anim.Play("FrogJumpRight");
        }
        StartCoroutine(coroutine_Name);
    }

    void AnimationFinished()
    {
        animation_Finished = true;

        if (jumpLeft)
        {
            anim.Play("FrogIdleLeft");
        }
        else
        {
            anim.Play("FrogIdleRight");
        }

        if(jumpedTimes == 3)
        {
            jumpedTimes = 0;
            Vector3 tempScale = transform.localScale;
            tempScale *= -1;
            transform.localScale = tempScale;
            jumpLeft = !jumpLeft;
        }
    }










}//CLASS
