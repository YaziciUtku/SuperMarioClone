using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{

    private Rigidbody2D birdRB;
    private Animator anim;
    private Vector3 moveDirection = Vector3.left;
    private Vector3 originPosition;
    private Vector3 movePosition;
    public GameObject birdEgg;
    public LayerMask playerLayer;
    private bool attacked;
    private bool canMove;
    private float birdSpeed = 2.5f;

    private void Awake()
    {
        birdRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        originPosition = transform.position;
        originPosition.x += 6f;
        movePosition = transform.position;
        movePosition.x -= 6f;
        canMove = true;
    }

   
    void Update()
    {
        MoveTheBird();
    }

    void MoveTheBird()
    {
        if (canMove)
        {
            transform.Translate(moveDirection *birdSpeed* Time.smoothDeltaTime);
          
            
            if(transform.position.x >= originPosition.x)
            {
                moveDirection = Vector3.left;
                ChangeDirection(-transform.localScale.x);
            }
            else if (transform.position.x <= movePosition.x)
            {
                moveDirection = Vector3.right;
                ChangeDirection(-transform.localScale.x);
            }
            
        }
    }

    void ChangeDirection(float direction)
    {
        Vector3 temp = transform.localScale;
        temp.x = direction;
        transform.localScale = temp;
    }








} // CLASS

