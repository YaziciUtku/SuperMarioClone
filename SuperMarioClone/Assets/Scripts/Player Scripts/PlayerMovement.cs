using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D playerRB;
    private Animator anim;
    private bool isGrounded = false;
    private bool jumped;
    [SerializeField]private float jumpPower = 5f;
    public Transform groundCheckerPosition;
    public LayerMask groundLayer;
    public float playerSpeed = 5f;
    private CinemachineVirtualCamera vcam;
    private PlayerDamage playerDamage;
    

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        vcam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        playerDamage = GetComponent<PlayerDamage>();
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        ChechkIfGrounded();
        PlayerJump();
        CinemachineDontFollow();
    }

    private void FixedUpdate()
    {
        PlayerWalk();
    }

    private void PlayerWalk()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if (h > 0)
        {
            playerRB.velocity = new Vector2(playerSpeed, playerRB.velocity.y);
            ChangeDirection((int)h);
        }
        else if(h< 0)
        {
            playerRB.velocity = new Vector2(-playerSpeed, playerRB.velocity.y);
            ChangeDirection((int)h);
        }
        else
        {
            playerRB.velocity = new Vector2(0f, playerRB.velocity.y);
        }

         anim.SetInteger("Speed", Mathf.Abs((int)playerRB.velocity.x));
       
    }

    void ChangeDirection(int direction)
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x = direction;
        transform.localScale = currentScale;
    }

    void ChechkIfGrounded()
    {
        isGrounded = Physics2D.Raycast(groundCheckerPosition.position, Vector2.down, 0.1f, groundLayer);
       

        if (isGrounded)
        {
            
            if (jumped)
            {
                jumped = false;
                anim.SetBool("Jump", false);
            }
        }
    }

    void PlayerJump()
    {
        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                
                jumped = true;
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpPower);
                anim.SetBool("Jump", true);
                
            }
        }
    }

    void CinemachineDontFollow()
    {
        if (!playerDamage.isAlive)
        {
            vcam.Follow = null;
        }

    }

} // Class

