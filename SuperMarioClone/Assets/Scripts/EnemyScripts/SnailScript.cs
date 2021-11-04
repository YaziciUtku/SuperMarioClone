using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailScript : MonoBehaviour
{
    public float snailSpeed = 1f;
    private Rigidbody2D snailRB;
    private Animator anim;
    private bool moveLeft;
    private bool canMove;
    private bool stunned;
    public Transform left_Collusion, right_Collusion, top_Collusion, down_Collusion;
    private Vector3 left_Collusion_Position, right_Collusion_Position;
    public LayerMask PlayerLayer;

    private void Awake()
    {
        snailRB = GetComponent<Rigidbody2D>(); 
        anim = GetComponent<Animator>();
        left_Collusion_Position = left_Collusion.position;
        right_Collusion_Position = right_Collusion.position;
    }

    void Start()
    {
        moveLeft = true;
        canMove = true;
    }

    
    void Update()
    {
        CheckCollusion();
        if (canMove)
        {
            if (moveLeft)
            {
                snailRB.velocity = new Vector2(-snailSpeed, snailRB.velocity.y);
            }
            else
            {
                snailRB.velocity = new Vector2(snailSpeed, snailRB.velocity.y);
            }
        }
    }

    void CheckCollusion()
    {
        RaycastHit2D leftHit = Physics2D.Raycast(left_Collusion.position, Vector2.left, 0.1f, PlayerLayer);
        RaycastHit2D rightHit = Physics2D.Raycast(right_Collusion.position, Vector2.right, 0.1f, PlayerLayer);
        Collider2D topHit = Physics2D.OverlapCircle(top_Collusion.position, 0.2f, PlayerLayer);

        if(topHit != null)
        {
            if(topHit.gameObject.tag == MyTags.PLAYER_TAG)
            {
                if (!stunned)
                {
                    topHit.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(topHit.gameObject.GetComponent<Rigidbody2D>().velocity.x, 5f);
                    canMove = false;
                    snailRB.velocity = new Vector2(0, 0);
                    anim.Play("SnailStunned");
                    stunned = true;

                    // BEETLE CODE HERE

                    if(tag == MyTags.BEETLE_TAG)
                    {
                        anim.Play("SnailStunned");
                        StartCoroutine(Dead(0.5f));
                    }
                }
            }
        }

        if (leftHit)
        {
            if( leftHit.collider.gameObject.tag == MyTags.PLAYER_TAG)
            {
                if (!stunned)
                {
                    
                    // Apply Damage To The Player
                    print("Damage From Left");
                }
                else
                {
                    if (gameObject.tag != MyTags.BEETLE_TAG)
                    {
                        snailRB.velocity = new Vector2(15f, snailRB.velocity.y);
                        StartCoroutine(Dead(3f));
                    }
                }
            }
        }

        if (rightHit)
        {
            if(rightHit.collider.gameObject.tag == MyTags.PLAYER_TAG)
            {
                if (!stunned)
                {
                    // Apply Damage To The Player
                    print("Damage From Right");
                }
                else
                {
                    if (gameObject.tag != MyTags.BEETLE_TAG)
                    {
                        snailRB.velocity = new Vector2(-15f, snailRB.velocity.y);
                        StartCoroutine(Dead(3f));
                    }

                }
            }
        }

       if(!Physics2D.Raycast(down_Collusion.position, Vector2.down, 0.1f))
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        moveLeft = !moveLeft;
        Vector3 tempScale = transform.localScale;
        if (moveLeft)
        {
            tempScale.x = Mathf.Abs(tempScale.x);
            left_Collusion.position = left_Collusion_Position;
            right_Collusion.position = right_Collusion_Position;
        }
        else
        {
            tempScale.x = -Mathf.Abs(tempScale.x);
            left_Collusion.position = right_Collusion_Position;
            right_Collusion.position = left_Collusion_Position;
           
        }
        transform.localScale = tempScale;
    }


    IEnumerator Dead(float timer)
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == MyTags.BULLET_TAG)
        {
            if(tag == MyTags.BEETLE_TAG)
            {
                anim.Play(MyTags.STUNNED);
                canMove = false;
                snailRB.velocity = new Vector2(0, 0);
                StartCoroutine(Dead(0.4f));
            }
            if (tag == MyTags.SNAIL_TAG)
            {
                if (!stunned)
                {
                    anim.Play(MyTags.STUNNED);
                    stunned = true;
                    canMove = false;
                    snailRB.velocity = new Vector2(0, 0);
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
        }
       
    }

}// Class
