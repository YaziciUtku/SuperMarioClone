using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailScript : MonoBehaviour
{
    public float snailSpeed = 1f;
    private Rigidbody2D snailRB;
    private Animator anim;
    private bool moveLeft;
    public Transform down_Collusion;
    
    void Start()
    {
        snailRB =GetComponent<Rigidbody2D>();
    }

    
    void Update()
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


}// Class
