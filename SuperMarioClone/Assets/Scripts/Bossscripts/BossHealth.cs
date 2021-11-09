using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    private int bossHealthValue = 1;
    private bool canDamage;
  
    public int BossHealthValue
    {
        get { return bossHealthValue; }
        set { bossHealthValue = value; }
    }

    private void Awake()
    {
    
        canDamage = true;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == MyTags.BULLET_TAG)
        {
            if (canDamage)
            {
                bossHealthValue--;
                print(bossHealthValue);
                StartCoroutine(AttackAgain());
            }
        }
    }

    private void Update()
    {
        
    }

    IEnumerator AttackAgain()
    {
        canDamage = false;
        yield return new WaitForSeconds(1f);
        canDamage = true;
    }

}//CLASS
