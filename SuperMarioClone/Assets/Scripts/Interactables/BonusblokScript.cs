using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusblokScript : MonoBehaviour
{
    private Animator anim;
    public Transform rayPos1, rayPos2;
    public LayerMask playerLayer;
    public Animator coinAnim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
       // coinAnim = GetComponent<Animator>();
       
    }
    void Start()
    {
        
    }

  
    void Update()
    {
        DetectCollusion(); 
    }

    void DetectCollusion()
    {
        bool isHit1 = Physics2D.Raycast(rayPos1.position, Vector2.down, 0.1f, playerLayer);
        bool isHit2 = Physics2D.Raycast(rayPos2.position, Vector2.down, 0.1f, playerLayer);
        if (isHit1 || isHit2)
        {
            anim.Play("BlockHit");
            coinAnim.Play("CoinRising");
           
        }

    }












}// CLASS
