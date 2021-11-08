using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    private TextMeshProUGUI lifeText;
    private int lifeScore;
    private bool canDamage;
    private Rigidbody2D playerRB;
    Collider2D colliderPlayer;
    Animator anim;
    public bool isAlive;

    private void Awake()
    {
        lifeText = GameObject.Find("Life Text").GetComponent<TextMeshProUGUI>();
        lifeScore = 3;
        lifeText.text = "x" + lifeScore;
        canDamage = true;
        playerRB = GetComponent<Rigidbody2D>();
        colliderPlayer = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        isAlive = true;
    }

    public void DealDamageToPlayer()
    {
        if (canDamage)
        {
            lifeScore--;

            if (lifeScore >= 0)
            {
                lifeText.text = "x" + lifeScore;
            }

            if (lifeScore == 0)
            {
                isAlive = false;
                playerRB.AddForce(new Vector2(0, 10f), ForceMode2D.Impulse);
                transform.Rotate(0, 0, 90);
                anim.Play("PlayerDead");
                colliderPlayer.isTrigger = true;
               
                StartCoroutine(RestartGame());
                
            }

            canDamage = false;
            StartCoroutine(WaitForDamage());
        }
    }

    IEnumerator WaitForDamage()
    {
        yield return new WaitForSeconds(2);
        canDamage = true;
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }























}//CALSS



