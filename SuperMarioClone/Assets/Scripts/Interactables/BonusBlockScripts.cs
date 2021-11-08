using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlockScripts : MonoBehaviour
{
    private Animator anim;
    private Vector3 startPos;
    private Vector3 jumpedPos;
    public Transform rayCastPos;
    public LayerMask playerLayer;
    [SerializeField] Vector3 moveUpSpeed = new Vector3(0, 10, 0);
    private bool canAnimate;
    private bool startAnim;
    

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        startPos = transform.position;
        jumpedPos = startPos + new Vector3(0, .30f, 0);
        canAnimate = true;
    }



    private void Update()
    {
        CheckHit();
        AnimateUpAndDown();

        
      
    }

    void CheckHit()
    {
        if (canAnimate)
        {
            RaycastHit2D hit = Physics2D.Raycast(rayCastPos.position, Vector2.down, 0.15f, playerLayer);
            if (hit)
            {
                startAnim = true;
                anim.Play("BlockHit");
                canAnimate = false;
            }
        }
    }

    void AnimateUpAndDown()
    {
        if (startAnim)
        {
            transform.Translate(moveUpSpeed * Time.smoothDeltaTime * 2);

            if(transform.position.y >= jumpedPos.y)
            {
                moveUpSpeed = -moveUpSpeed;
            }
            else if(transform.position.y <= startPos.y)
            {
                startAnim = false;
            }
        }



    }






















}//CLASS
