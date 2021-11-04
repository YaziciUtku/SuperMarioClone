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
                    snailRB.velocity = new Vector2(15f, snailRB.velocity.y);
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
                    snailRB.velocity = new Vector2(-15f, snailRB.velocity.y);
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
            tempScale.x = -tempScale.x;
            left_Collusion.position = right_Collusion_Position;
            right_Collusion.position = left_Collusion_Position;
           
        }
        transform.localScale = tempScale;
    }


}// Class
