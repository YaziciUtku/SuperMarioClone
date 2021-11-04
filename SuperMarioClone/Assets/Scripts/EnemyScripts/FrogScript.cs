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
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        StartCoroutine(coroutine_Name);
    }


    void Update()
    {
        
    }

    IEnumerator FrogJump()
    {
        yield return new WaitForSeconds(Random.Range(1f, 4f));
        if (jumpLeft)
        {
            anim.Play("FrogJumpLeft");
        }
        else
        {

        }
        StartCoroutine(coroutine_Name);
    }

    void AnimationFinished()
    {
        
        anim.Play("FrogIdleLeft");
    }










}//CLASS
